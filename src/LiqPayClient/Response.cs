// 
//  Response.cs
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
using System.Xml.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace Magnis.Web.Services.LiqPay
{
	/// <summary>
	/// Base class for the operation response.
	/// </summary>
	public abstract class Response
    {
        protected const string VersionNodeName             = "version";
        protected const string StatusNodeName              = "status";
        protected const string CodeNodeName                = "code";
        protected const string ResponseDescriptionNodeName = "response_description";
        protected const string ActionNodeName              = "action";
        protected static char[] ResponseTrimChars          = new char[] { ' ', '\t', '\r', '\n', '|' };
		
		/// <summary>
		/// Gets response text received from the server.
		/// </summary>
        public string ResponseText { get; protected set; }
		
		/// <summary>
		/// Gets version of the API used.
		/// </summary>
        public string ApiVersion { get; protected set; }
		
		/// <summary>
		/// Gets operation status.
		/// </summary>
        public string Status { get; protected set; }
		
		/// <summary>
		/// Gets error code or empty string if operation processed successfully.
		/// </summary>
        public string Code { get; protected set; }
		
		/// <summary>
		/// Gets response description. In case of operation failure contains error description.
		/// </summary>
        public string ResponseDescription { get; protected set; }
		
		/// <summary>
		/// Gets action name.
		/// </summary>
        public string Action { get; protected set; }
		
		/// <summary>
		/// Determines if operation processed successfully.
		/// </summary>
        public virtual bool Success
        {
            get { return this.Status.Equals(ActionStatus.Success, StringComparison.InvariantCultureIgnoreCase); }
        }

        internal Response()
        {
        }
		
		/// <summary>
		/// Parses server operation response XML and creates instance of class derived from Response which describes concrete response.
		/// </summary>
		/// <param name="operationXml">
		/// Operation response XML returned by server
		/// </param>
		/// <returns>
		/// Instance of class derived from Response which represents parsed operation response
		/// </returns>
        public static Response Create(string operationXml)
        {
            Response response;

            try
            {
                XElement operationXmlElement = XElement.Parse(operationXml);
                string action = operationXmlElement.Element(ActionNodeName).Value.Trim();
                switch (action.ToLower(CultureInfo.InvariantCulture))
                {
                    case LiqPayAction.SendMoney:
                        response = SendMoneyResponse.FromXml(operationXmlElement);
                        break;
                    case LiqPayAction.ViewBalance:
                        response = ViewBalanceResponse.FromXml(operationXmlElement);
                        break;
                    case LiqPayAction.ViewTransaction:
                        response = ViewTransactionResponse.FromXml(operationXmlElement);
                        break;
					case LiqPayAction.PhoneCredit:
						response = PhoneCreditResponse.FromXml(operationXmlElement);
						break;
                    default:
                        throw new LiqPayException(ErrorCode.UnknownAction, string.Format(CultureInfo.InvariantCulture, "Unknown LiqPay action: '{0}'.", action), operationXml);
                }
                response.Action = action;
                response.ApiVersion = operationXmlElement.Element(VersionNodeName).Value.Trim();
                response.Status = operationXmlElement.Element(StatusNodeName).Value.Trim();
                if (!response.Success)
                {
                    response.Code = operationXmlElement.Element(CodeNodeName).Value.Trim(ResponseTrimChars);
                    response.ResponseDescription = operationXmlElement.Element(ResponseDescriptionNodeName).Value.Trim(ResponseTrimChars);
                }
            }
            catch
            {
                response = new InvalidResponse();
                response.ResponseDescription = "Response xml is not well formed.";
            }
            response.ResponseText = operationXml;

            return response;
        }
    }
	
	
	/// <summary>
	/// Represents invalid operation response.
	/// </summary>
	public sealed class InvalidResponse : Response
    {
		/// <summary>
		/// Overriden. Always returns false.
		/// </summary>
        public override bool Success
        {
            get { return false; }
        }

        #region Constructors
		
		/// <summary>
		/// Creates an instance of InvalidResponse class.
		/// </summary>
        public InvalidResponse()
        {
        }
		
		/// <summary>
		/// Initializes instance of InvalidResponse class.
		/// </summary>
		/// <param name="errorCode">
		/// Error code.
		/// </param>
		/// <param name="description">
		/// Detailed error description.
		/// </param>
		/// <param name="responseText">
		/// Response text returned by server.
		/// </param>
        public InvalidResponse(string errorCode, string description, string responseText)
        {
            this.Code = errorCode;
            this.ResponseDescription = description;
            this.ResponseText = responseText;
        }

        #endregion
    }
	
	
	/// <summary>
	/// Represent send money operation response.
	/// </summary>
    public class SendMoneyResponse : Response
    {
        protected const string KindNodeName          = "kind";
        protected const string MerchantIdNodeName    = "merchant_id";
        protected const string OrderIdNodeName       = "order_id";
        protected const string RecipientNodeName     = "to";
        protected const string AmountNodeName        = "amount";
        protected const string CurrencyNodeName      = "currency";
        protected const string DescriptionNodeName   = "description";
        protected const string TransactionIdNodeName = "transaction_id";
		
		/// <summary>
		/// Gets kind of transfer.
		/// </summary>
        public string Kind { get; protected set; }
		
		/// <summary>
		/// Gets merchant identifier.
		/// </summary>
        public string MerchantId { get; protected set; }
		
		/// <summary>
		/// Gets order identifier.
		/// </summary>
        public string OrderId { get; protected set; }
		
		/// <summary>
		/// Get payee merchant phone number.
		/// </summary>
        public string To { get; protected set; }
		
		/// <summary>
		/// Gets sent amount.
		/// </summary>
        public double Amount { get; protected set; }
		
		/// <summary>
		/// Gets currency name.
		/// </summary>
        public string Currency { get; protected set; }
		
		/// <summary>
		/// Gets transaction description.
		/// </summary>
        public string Description { get; protected set; }
		
		/// <summary>
		/// Gets transaction identifier.
		/// </summary>
        public string TransactionId { get; protected set; }
		
		/// <summary>
		/// Instantiates SendMoneyResponse class using operation response XML.
		/// </summary>
		/// <param name="xml">
		/// Send money operation response XML.
		/// </param>
		/// <returns>
		/// A SendMoneyResponse object.
		/// </returns>
        public static SendMoneyResponse FromXml(XContainer xml)
        {
            SendMoneyResponse response = new SendMoneyResponse()
            {
                Kind          = xml.Element(KindNodeName).Value.Trim(),
                MerchantId    = xml.Element(MerchantIdNodeName).Value.Trim(),
                OrderId       = xml.Element(OrderIdNodeName).Value.Trim(),
                To            = xml.Element(RecipientNodeName).Value.Trim(),
                Amount        = double.Parse(xml.Element(AmountNodeName).Value.Trim(), CultureInfo.InvariantCulture),
                Currency      = xml.Element(CurrencyNodeName).Value.Trim(),
                Description   = xml.Element(DescriptionNodeName).Value.Trim(),
                TransactionId = xml.Element(TransactionIdNodeName).Value.Trim()
            };

            return response;
        }
    }
	

	/// <summary>
	/// Represents view balance operation response.
	/// </summary>
    public class ViewBalanceResponse : Response
    {
        protected const string MerchantIdNodeName = "merchant_id";
        protected const string BalanceNodeName    = "balances";

        /// <summary>
        /// Gets merchant identifier.
        /// </summary>
		public string MerchantId { get; protected set; }
		
		/// <summary>
		/// Gets merchant's balance in form of dictionary where key is currency and value is amount.
		/// </summary>
        public Dictionary<string, double> Balance { get; protected set; }
		
		/// <summary>
		/// Instantiates ViewBalanceResponse class using specified operation xml.
		/// </summary>
		/// <param name="xml">
		/// XML that contains view balance operation response
		/// </param>
		/// <returns>
		/// A ViewBalanceResponse object.
		/// </returns>
        public static ViewBalanceResponse FromXml(XContainer xml)
        {
            ViewBalanceResponse response = new ViewBalanceResponse()
            {
                MerchantId = xml.Element(MerchantIdNodeName).Value.Trim(),
                Balance = new Dictionary<string, double>()
            };
            XElement balanceElement = xml.Element(BalanceNodeName);
            if (balanceElement != null && balanceElement.HasElements)
            {
                foreach (XElement element in balanceElement.Elements())
                {
                    response.Balance.Add(element.Name.ToString(), double.Parse(element.Value.Trim(), CultureInfo.InvariantCulture));
                }
            }

            return response;
        }
    }
	

	/// <summary>
	/// Represents view transaction operation response.
	/// </summary>
    public class ViewTransactionResponse : Response
    {
        protected const string MerchantIdNodeName    = "merchant_id";
        protected const string TransactionNodeName   = "transaction";
        protected const string TransactionIdNodeName = "id";
        protected const string AmountNodeName        = "amount";
        protected const string CurrencyNodeName      = "currency";
        protected const string DescriptionNodeName   = "description";
        protected const string OrderIdNodeName       = "order_id";
        protected const string FromNodeName          = "from";
        protected const string ToNodeName            = "to";
        protected const string ReferrerUrlNodeName   = "referer_url";
		
		/// <summary>
		/// Gets merchant identifier.
		/// </summary>
        public string MerchantId { get; protected set; }
		
		/// <summary>
		/// Gets transaction information.
		/// </summary>
        public Transaction TransactionInfo { get; protected set; }
		
		/// <summary>
		/// Instantiates ViewTransactionResponse class.
		/// </summary>
		/// <param name="xml">
		/// View transaction operation response in XML format.
		/// </param>
		/// <returns>
		/// A <see cref="ViewTransactionResponse"/> object.
		/// </returns>
        public static ViewTransactionResponse FromXml(XContainer xml)
        {
            ViewTransactionResponse response = new ViewTransactionResponse()
            {
                MerchantId = xml.Element(MerchantIdNodeName).Value.Trim()
            };
            XElement transactionElement = xml.Element(TransactionNodeName);
            if (transactionElement != null)
            {
                Transaction transaction = new Transaction();
                transaction.Id				   = transactionElement.Element(TransactionIdNodeName).Value.Trim();
                transaction.OrderId			   = transactionElement.Element(OrderIdNodeName).Value.Trim();
                transaction.Amount             = double.Parse(transactionElement.Element(AmountNodeName).Value.Trim(), CultureInfo.InvariantCulture);
                transaction.Currency           = transactionElement.Element(CurrencyNodeName).Value.Trim();
                transaction.Description        = transactionElement.Element(DescriptionNodeName).Value.Trim();
                transaction.From               = transactionElement.Element(FromNodeName).Value.Trim();
                transaction.To                 = transactionElement.Element(ToNodeName).Value.Trim();
                transaction.RefererAddress     = transactionElement.Element(ReferrerUrlNodeName).Value.Trim();
                response.TransactionInfo = transaction;
            }
            else
                throw new LiqPayException(ErrorCode.ResponseIsNotWellFormed, "Transaction element is not found in the response.", xml.ToString());

            return response;
        }
    }
	
	
	/// <summary>
	/// Represents phone credit operation response.
	/// </summary>
	public class PhoneCreditResponse : Response
	{
		protected const string MerchantIdNodeName	= "merchant_id";
		protected const string AmountNodeName		= "amount";
		protected const string CurrencyNodeName		= "currency";
		protected const string PhoneNodeName		= "phone";
		protected const string OrderIdNodeName		= "order_id";
		
		#region Properties
		
		/// <summary>
		/// Gets/Sets merchant identifier.
		/// </summary>
		public string MerchantId { get; protected set; }
		
		/// <summary>
		/// Gets amount value.
		/// </summary>
		public double Amount { get; protected set; }
		
		/// <summary>
		/// Gets name of currency.
		/// </summary>
		public string Currency { get; protected set; }
		
		/// <summary>
		/// Gets phone number.
		/// </summary>
		public string Phone { get; protected set; }
		
		/// <summary>
		/// Gets order identifier .
		/// </summary>
		public string OrderId { get; protected set; }
		
		#endregion
		
		/// <summary>
		/// Instantiates PhoneCreditResponse class and initializes using data in response xml.
		/// </summary>
		/// <param name="xml">
		/// A <see cref="XContainer"/> that represents response in XML format.
		/// </param>
		/// <returns>
		/// A <see cref="PhoneCreditResponse"/> object.
		/// </returns>
		public static PhoneCreditResponse FromXml(XContainer xml)
		{
			PhoneCreditResponse response = new PhoneCreditResponse()
			{
				MerchantId = xml.Element(MerchantIdNodeName).Value.Trim(),
				Amount = double.Parse(xml.Element(AmountNodeName).Value),
				Currency = xml.Element(CurrencyNodeName).Value.Trim(),
				Phone = xml.Element(PhoneNodeName).Value.Trim(),
				OrderId = xml.Element(OrderIdNodeName).Value.Trim()
			};
			
			return response;
		}
	}
}

