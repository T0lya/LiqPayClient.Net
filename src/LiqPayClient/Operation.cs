// 
//  Action.cs
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
using System.Text;
using System.Xml.Linq;

namespace Magnis.Web.Services.LiqPay
{
	/// <summary>
    /// Provides base functionality for LiqPay operations
    /// </summary>
    public abstract class Operation
    {
        public const string ApiVersion                   = "1.2";
        protected const string RootNodeName              = "request";
        protected const string VersionNodeName           = "version";
        protected const string ActionNodeName            = "action";
        protected const string OperationEnvelopeNodeName = "operation_envelope";
        protected const string OperationXmlNodeName      = "operation_xml";
        protected const string SignatureNodeName         = "signature";

		/// <summary>
		/// Gets action name of operation
		/// </summary>
        public string Action { get; protected set; }

        /// <summary>
        /// Generates an XML representation of current operation.
        /// </summary>
        /// <returns>When overriden in a derived class, returns an XML representation of current operation.</returns>
        public virtual XElement ToXml()
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Generates an XML representation of operation envelope.
        /// </summary>
        /// <param name="signatureProvider">A signature provider object to calculate signature for operation.</param>
        /// <returns>An XMl representation of operation envelope.</returns>
        public virtual XElement ToOperationEnvelopeXml(SignatureProvider signatureProvider)
        {
            return
                new XElement(OperationEnvelopeNodeName,
                    new XElement(OperationXmlNodeName, Convert.ToBase64String(Encoding.ASCII.GetBytes(ToXml().ToString()))),
                    new XElement(SignatureNodeName, signatureProvider.GenerateSignature(this.ToXml().ToString()))
                );
        }
    }
	
	
	/// <summary>
    /// Represents send money operation
    /// </summary>
    public class SendMoneyOperation : Operation
    {
        protected const string KindNodeName        = "kind";
        protected const string MerchantIdNodeName  = "merchant_id";
        protected const string OrderIdNodeName     = "order_id";
        protected const string ToNodeName          = "to";
        protected const string AmountNodeName      = "amount";
        protected const string CurrencyNodeName    = "currency";
        protected const string DescriptionNodeName = "description";

        /// <summary>
        /// Gets/Sets sender merchant identifier.
        /// </summary>
        public string MerchantId { get; set; }
		
        /// <summary>
        /// Gets/Sets kind of transfer. See TransferKind for available values.
        /// </summary>
        public string Kind { get; set; }
		
        /// <summary>
        /// Gets/Sets payee phone/card number.
        /// </summary>
        public string To { get; set; }
		
        /// <summary>
        /// Gets/Sets amount to send.
        /// </summary>
        public double Amount { get; set; }
		
        /// <summary>
        /// Gets/Sets name of currency.
        /// </summary>
        public string Currency { get; set; }
		
        /// <summary>
        /// Gets/Sets operation description.
        /// </summary>
        public string Description { get; set; }
		
        /// <summary>
        /// Gets/Sets order identifier.
        /// </summary>
        public string OrderId { get; set; }

        #region Constructors

        /// <summary>
        /// Initalizes a new instance of SendMoneyOperation class.
        /// </summary>
        public SendMoneyOperation()
        {
            base.Action = LiqPayAction.SendMoney;
        }
				
        #endregion

        /// <summary>
        /// Generates an XML representation of operation.
        /// </summary>
        /// <returns>An XML representation of operation.</returns>
        public override XElement ToXml()
        {
            return
                new XElement(RootNodeName,
                    new XElement(VersionNodeName, ApiVersion),
                    new XElement(ActionNodeName, this.Action),
                    new XElement(KindNodeName, this.Kind),
                    new XElement(MerchantIdNodeName, this.MerchantId),
                    new XElement(OrderIdNodeName, this.OrderId),
                    new XElement(ToNodeName, this.To),
                    new XElement(AmountNodeName, this.Amount),
                    new XElement(CurrencyNodeName, this.Currency),
                    new XElement(DescriptionNodeName, this.Description)
                );
        }
    }
	
	
	/// <summary>
    /// Represents view balance operation
    /// </summary>    
    public class ViewBalanceOperation : Operation
    {
        protected const string MerchantIdNodeName = "merchant_id";
		
		/// <summary>
		/// Gets/Sets merchant identifier
		/// </summary>
        public string MerchantId { get; set; }

        #region Constructors
		
		/// <summary>
		/// Initializes a new instance of ViewBalanceOperation class.
		/// </summary>
        public ViewBalanceOperation()
        {
            base.Action = LiqPayAction.ViewBalance;
        }
		
		/// <summary>
		/// Initializes a new instance of ViewBalanceOperation class with merchant identifier.
		/// </summary>
		/// <param name="merchantId">
		/// Merchant identifier
		/// </param>
        public ViewBalanceOperation(string merchantId)
            : this()
        {
            this.MerchantId = merchantId;
        }

        #endregion
		
		/// <summary>
		/// Generates an XML representation of operation
		/// </summary>
		/// <returns>
		/// XML representation of operation
		/// </returns>
        public override XElement ToXml()
        {
            return
                new XElement(RootNodeName,
                    new XElement(VersionNodeName, ApiVersion),
                    new XElement(ActionNodeName, this.Action),
                    new XElement(MerchantIdNodeName, this.MerchantId)
                );
        }
    }
	
	
	/// <summary>
	/// Represents view transaction operation
	/// </summary>
	public class ViewTransactionOperation : Operation
    {
        protected const string MerchantIdNodeName         = "merchant_id";
        protected const string TransactionIdNodeName      = "transaction_id";
        protected const string TransactionOrderIdNodeName = "transaction_order_id";
		
		/// <summary>
		/// Gets/Sets merchant identifier
		/// </summary>
        public string MerchantId { get; set; }
		
		/// <summary>
		/// Gets/Sets transaction identifier. It has more priority than TransactionOrderId.
		/// </summary>
        public string TransactionId { get; set; }
		
		/// <summary>
		/// Gets/Sets transaction order identifier. It is processed if TransactionId is not specified.
		/// </summary>
        public string TransactionOrderId { get; set; }

        #region Constructors
		
		/// <summary>
		/// Initializes a new instance of ViewTransactionOperation class.
		/// </summary>
        public ViewTransactionOperation()
        {
            base.Action = LiqPayAction.ViewTransaction;
        }

        #endregion
		
		/// <summary>
		/// Generates an XML representation of view transaction operation.
		/// </summary>
		/// <returns>
		/// XML representation of view transaction operation.
		/// </returns>
        public override XElement ToXml()
        {
            return
                new XElement(RootNodeName,
                    new XElement(VersionNodeName, ApiVersion),
                    new XElement(ActionNodeName, this.Action),
                    new XElement(MerchantIdNodeName, this.MerchantId),
                    new XElement(TransactionIdNodeName, this.TransactionId),
                    new XElement(TransactionOrderIdNodeName, this.TransactionOrderId)
                );
        }
    }
	
	
	/// <summary>
	/// Represents credit phone operation.
	/// </summary>
	public class PhoneCreditOperation : Operation
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
		public string MerchantId { get; set; }
		
		/// <summary>
		/// Gets/Sets amount to credit.
		/// </summary>
		public double Amount { get; set; }
		
		/// <summary>
		/// Gets/Sets name of currency.
		/// </summary>
		public string Currency { get; set; }
		
		/// <summary>
		/// Gets/Sets phone number.
		/// </summary>
		public string Phone { get; set; }
		
		/// <summary>
		/// Gets/Sets order identifier .
		/// </summary>
		public string OrderId { get; set; }
		
		#endregion
		
		/// <summary>
		/// Initializes a new instance of CreditPhone class.
		/// </summary>
		public PhoneCreditOperation()
		{
			base.Action = LiqPayAction.PhoneCredit;
		}
		
		/// <summary>
		/// Generates an XML representation of phone credit operation.
		/// </summary>
		/// <returns>
		/// XElement which represents phone credit operation.
		/// </returns>
		public override XElement ToXml()
		{
			return 
				new XElement(RootNodeName,
				    new XElement(VersionNodeName, ApiVersion),
				    new XElement(ActionNodeName, this.Action),
				    new XElement(MerchantIdNodeName, this.MerchantId),
				    new XElement(AmountNodeName, this.Amount),
				    new XElement(CurrencyNodeName, this.Currency),
				    new XElement(PhoneNodeName, this.Phone),
				    new XElement(OrderIdNodeName, this.OrderId)
				);
		}
	}
}