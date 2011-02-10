// 
//  ClickNBuy.cs
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
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace Magnis.Web.Services.LiqPay
{
	/// <summary>
	/// Provides common methods to prepare necessary data to use click&buy LiqPay API
	/// </summary>
    public class ClickNBuy
    {
		/// <summary>
		/// API version.
		/// </summary>
        public const string Version                 = "1.2";
		
        protected const string DefaultFormName      = "clicknbuyForm";
        protected const string ApiUrl               = "https://liqpay.com/?do=clickNbuy";
        protected const string RootNodeName         = "request";
        protected const string VersionNodeName      = "version";
        protected const string ResultUrlNodeName    = "result_url";
        protected const string ServerUrlNodeName    = "server_url";
        protected const string MerchantIdNodeName   = "merchant_id";
        protected const string OrderIdNodeName      = "order_id";
        protected const string AmountNodeName       = "amount";
        protected const string CurrencyNodeName     = "currency";
        protected const string DescriptionNodeName  = "description";
        protected const string DefaultPhoneNodeName = "default_phone";
        protected const string PayWayNodeName       = "pay_way";
		
		#region Properties
		
		/// <summary>
		/// Gets/Sets URL to redirect client to after payment completion.
		/// </summary>
        public Uri ResultUrl { get; set; }
		
		/// <summary>
		/// Gets/Sets URL to send server response to.
		/// </summary>
        public Uri ServerUrl { get; set; }
		
		/// <summary>
		/// Gets/Sets merchant identifier.
		/// </summary>
        public string MerchantId { get; set; }
		
		/// <summary>
		/// Gets/Sets order identifier.
		/// </summary>
        public string OrderId { get; set; }
		
		/// <summary>
		/// Gets/Sets amount value.
		/// </summary>
        public double Amount { get; set; }
		
		/// <summary>
		/// Gets/Sets currency.
		/// </summary>
        public string Currency { get; set; }
		
		/// <summary>
		/// Gets/Sets description.
		/// </summary>
        public string Description { get; set; }
		
		/// <summary>
		/// Gets/Sets default phone number on payment page.
		/// </summary>
        public string DefaultPhone { get; set; }
		
		/// <summary>
		/// Gets/Sets payment method (liqpay, card);
		/// </summary>
        public string PayWay { get; set; }
		
		#endregion
		
		/// <summary>
		/// Generates XML representation of click&buy request.
		/// </summary>
        public XElement ToXml()
        {
            return new XElement(
                new XElement(RootNodeName,
                    new XElement(VersionNodeName, Version),
                    new XElement(ResultUrlNodeName, this.ResultUrl == null ? string.Empty : this.ResultUrl.AbsoluteUri),
                    new XElement(ServerUrlNodeName, this.ServerUrl == null ? string.Empty : this.ServerUrl.AbsoluteUri),
                    new XElement(MerchantIdNodeName, this.MerchantId),
                    new XElement(OrderIdNodeName, this.OrderId),
                    new XElement(AmountNodeName, this.Amount),
                    new XElement(CurrencyNodeName, this.Currency),
                    new XElement(DescriptionNodeName, this.Description),
                    new XElement(DefaultPhoneNodeName, this.DefaultPhone),
                    new XElement(PayWayNodeName, this.PayWay))
                );
        }
		
		/// <summary>
		/// Generates html code for hidden field with operation xml
		/// </summary>
		/// <returns>A XElement object.</returns>
        protected XElement ToOperationHtml()
        {
            string encodedXml = Convert.ToBase64String(Encoding.ASCII.GetBytes(ToXml().ToString()));

            return new XElement(
                "input",
                new XAttribute("type", "hidden"),
                new XAttribute("name", "operation_xml"),
                new XAttribute("value", encodedXml)
                );
        }
		
		/// <summary>
		/// Generates html code for hidden field with signature xml
		/// </summary>
		/// <param name="signatureProvider">
		/// SignatureProvider object which will be used by this instance to generate signature.
		/// </param>
		/// <returns>A XElement object.</returns>
        protected XElement ToSignatureHtml(SignatureProvider signatureProvider)
        {
            string signature = signatureProvider.GenerateSignature(ToXml().ToString());
            
            return new XElement(
                "input", 
                new XAttribute("type", "hidden"), 
                new XAttribute("name", "signature"), 
                new XAttribute("value", signature));
        }
		
		/// <summary>
		/// Generates html code for click&buy request.
		/// </summary>
		/// <param name="signatureProvider">
		/// Specifies signature provider.
		/// </param>
		/// <param name="formName">
		/// The name of html form element.
		/// </param>
		/// <param name="submitButtonValue">
		/// The name of submit button.
		/// </param>
		/// <returns>
		/// Html code for click&buy request
		/// </returns>
        public virtual string ToHtml(SignatureProvider signatureProvider, string formName, string submitButtonValue)
        {
            return new XElement(
                "form", new XAttribute("name", string.IsNullOrEmpty(formName) ? DefaultFormName : formName), new XAttribute("action", ApiUrl), new XAttribute("method", "POST"),
                ToOperationHtml(),
                ToSignatureHtml(signatureProvider),
                new XElement("input", new XAttribute("type", "submit"), new XAttribute("value", submitButtonValue))
                ).ToString();
        }
		
		/// <summary>
		/// Generates html code for click&buy request.
		/// </summary>
		/// <param name="signatureProvider">
		/// Specifies signature provider.
		/// </param>
		/// <param name="submitButtonValue">
		/// The name of submit button.
		/// </param>
		/// <returns>
		/// Html code for click&buy request.
		/// </returns>
        public virtual string ToHtml(SignatureProvider signatureProvider, string submitButtonValue)
        {
            return ToHtml(signatureProvider, null, submitButtonValue);
        }
    }
	
	
	/// <summary>
	/// Represents click&buy response.
	/// </summary>
	public class ClickNBuyResponse
    {
        protected const string RootNodeName          = "response";
        protected const string VersionNodeName       = "version";
		protected const string ActionNodeName        = "action";
		protected const string MerchantIdNodeName    = "merchant_id";
		protected const string OrderIdNodeName       = "order_id";
        protected const string AmountNodeName        = "amount";
        protected const string CurrencyNodeName      = "currency";
        protected const string DescriptionNodeName   = "description";
        protected const string StatusNodeName        = "status";
        protected const string TransactionIdNodeName = "transaction_id";
        protected const string PayWayNodeName        = "pay_way";
        protected const string SenderPhoneNodeName   = "sender_phone";
		
		#region Properties
		
		/// <summary>
		/// Gets API version
		/// </summary>
        public string Version { get; protected set; }
		
		/// <summary>
		/// Gets action name.
		/// </summary>
        public string Action { get; protected set; }
		
		/// <summary>
		/// Gets amount value.
		/// </summary>
        public double Amount { get; protected set; }
		
		/// <summary>
		/// Gets currency.
		/// </summary>
        public string Currency { get; protected set; }
		
		/// <summary>
		/// Gets operation description.
		/// </summary>
        public string Description { get; protected set; }
		
		/// <summary>
		/// Gets merchant identifier.
		/// </summary>
        public string MerchantId { get; protected set; }
		
		/// <summary>
		/// Gets order identifier.
		/// </summary>
        public string OrderId { get; protected set; }
		
		/// <summary>
		/// Gets way of payment.
		/// </summary>
        public string PayWay { get; protected set; }
		
		/// <summary>
		/// Gets sender phone number.
		/// </summary>
        public string SenderPhone { get; protected set; }
		
		/// <summary>
		/// Gets operation status.
		/// </summary>
        public string Status { get; protected set; }
		
		/// <summary>
		/// Gets transaction identifier.
		/// </summary>
        public string TransactionId { get; protected set; }
		
		#endregion
		
		/// <summary>
		/// Creates an instance of ClickNBuyResponse and initializes properties using operation xml
		/// </summary>
		/// <param name="operationXml">
		/// Operation xml returned by server
		/// </param>
		/// <returns>
		/// An object that represents response for click&buy operation
		/// </returns>
        public static ClickNBuyResponse Parse(string operationXml)
        {
            ClickNBuyResponse response = new ClickNBuyResponse();
            XElement xml = XElement.Parse(operationXml);
            response.Version       = xml.Element(VersionNodeName).Value.Trim();
            response.Action        = xml.Element(ActionNodeName).Value.Trim();
            response.Status        = xml.Element(StatusNodeName).Value.Trim();
            response.Amount        = double.Parse(xml.Element(AmountNodeName).Value, CultureInfo.InvariantCulture);
            response.Currency      = xml.Element(CurrencyNodeName).Value.Trim();
            response.Description   = xml.Element(DescriptionNodeName).Value.Trim();
            response.MerchantId    = xml.Element(MerchantIdNodeName).Value.Trim();
            response.OrderId       = xml.Element(OrderIdNodeName).Value.Trim();
            response.PayWay        = xml.Element(PayWayNodeName).Value.Trim();
            response.SenderPhone   = xml.Element(SenderPhoneNodeName).Value.Trim();
            response.TransactionId = xml.Element(TransactionIdNodeName).Value.Trim();

            return response;
        }
    }
}

