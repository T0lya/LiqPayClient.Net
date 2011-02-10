// 
//  Request.cs
//  
//  Author:
//       Anatoliy Dudarchuk <dudarchuk@gmail.com>
//  
//  Copyright (c) 2010 Copyright 2010 Magnis. All rights reserved.
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Xml.Linq;

namespace Magnis.Web.Services.LiqPay
{
	/// <summary>
	/// Represents LiqPay operation request.
	/// </summary>
    public class Request
    {
        protected const string OperationUrl                     = "https://liqpay.com/?do=api_xml";
        protected const string RootNodeName                     = "request";
        protected const string EnvelopeRootNodeName             = "liqpay";
        protected const string OperationEnvelopeNodeName        = "operation_envelope";
        protected const string OperationXmlNodeName             = "operation_xml";
        protected const string SignatureNodeName                = "signature";
		
		/// <summary>
		/// Gets collection of operations.
		/// </summary>
        public List<Operation> Operations { get; private set; }
		
		/// <summary>
		/// Gets/Sets SignatureProvider used by this instance to generate operation signature.
		/// </summary>
        public SignatureProvider SignatureProvider { get; set; }
		
		/// <summary>
		/// Initializes a new instance of Requst class.
		/// </summary>
        public Request()
        {
            this.Operations = new List<Operation>();
        }
		
		/// <summary>
		/// Generates an XML that represents current request.
		/// </summary>
		/// <returns>
		/// XDocument that represents request in xml format.
		/// </returns>
        public XDocument ToXml()
        {
            return
                new XDocument(
                    new XDeclaration("1.0", "UTF-8", "yes"),
                    new XElement(RootNodeName,
                        new XElement(EnvelopeRootNodeName,
				            from operation in this.Operations select operation.ToOperationEnvelopeXml(this.SignatureProvider)
                        )
                    )
                );
        }
		
		/// <summary>
		/// Creates HttpWebRequest ready to send to server.
		/// </summary>
		/// <returns>
		/// A <see cref="HttpWebRequest"/>
		/// </returns>
        private HttpWebRequest CreateWebRequest()
        {
            byte[] postData = Encoding.ASCII.GetBytes(this.ToXml().ToString());

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(OperationUrl);
            request.Method = "POST";
            request.ProtocolVersion = new Version(1, 0);
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.ContentLength = postData.Length;
            request.Accept = "text/xml";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postData, 0, postData.Length);
            requestStream.Close();

            return request;
        }
		
		/// <summary>
		/// Sends request to the server and returns responses.
		/// </summary>
		/// <returns>
		/// Array of Response returned by server.
		/// </returns>
        public Response[] GetResponses()
        {
            List<Response> responses = new List<Response>();
            HttpWebRequest request = CreateWebRequest();
            HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
            string responseText = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
            XElement responseXml = XElement.Parse(responseText);
            IEnumerable<XElement> envelopeElements = responseXml.Descendants(OperationEnvelopeNodeName);
            foreach (XElement envelope in envelopeElements)
            {
                Response liqpayResponse;
                string encodedOperationXml = envelope.Element(OperationXmlNodeName).Value.Trim();
                string operationXml = Encoding.UTF8.GetString(Convert.FromBase64String(encodedOperationXml));
                string signature = envelope.Element(SignatureNodeName).Value.Trim();
                if (this.SignatureProvider.GenerateSignature(operationXml) == signature)
                    liqpayResponse = Response.Create(operationXml);
                else
                    liqpayResponse = new InvalidResponse(ErrorCode.SignatureError, "Signatures does not match.", responseText);
                responses.Add(liqpayResponse);
            }

            return responses.ToArray();
        }
    }
}

