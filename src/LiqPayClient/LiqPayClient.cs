// 
//  LiqPayClient.cs
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
using System.Globalization;

namespace Magnis.Web.Services.LiqPay
{
	/// <summary>
	/// Provides common methods to work with LiqPay operations.
	/// </summary>
    public class LiqPayClient
    {
		/// <summary>
		///  Gets merchant identifier.
		/// </summary>
        public string MerchantId { get; private set; }
		
        protected string SendMoneySign { get; set; }
		protected string OtherOperationsSign { get; set; }
        protected SignatureProvider SendMoneySignatureProvider { get; set; }
		protected SignatureProvider OtherOperationsSignatureProvider { get; set; }
		
		/// <summary>
		/// Creates a new instance of LiqPayClient class
		/// </summary>
		/// <param name="merchantId">
		/// Merchant identifier.
		/// </param>
		/// <param name="sendMoneySign">
		/// Signature for send money operations.
		/// </param>
		/// <param name="otherOperationsSign">
		/// Signature for other operations.
		/// </param>
        public LiqPayClient(string merchantId, string sendMoneySign, string otherOperationsSign)
        {
            this.MerchantId = merchantId;
            this.SendMoneySign = sendMoneySign;
			this.OtherOperationsSign = otherOperationsSign;
            this.SendMoneySignatureProvider = new SignatureProvider(this.SendMoneySign);
			this.OtherOperationsSignatureProvider = new SignatureProvider(this.OtherOperationsSign);
        }
		
		/// <summary>
		/// Gets merchant balance information.
		/// </summary>
		/// <returns>
		/// Dictionary<string, double> where key is currency and value is amount.
		/// </returns>
        public Dictionary<string, double> ViewBalance()
        {
            ViewBalanceOperation operation = new ViewBalanceOperation(this.MerchantId);
            Response response = ProcessOperation(operation);

            return ((ViewBalanceResponse)response).Balance;
        }
		
		/// <summary>
		/// Sends money to other merchant.
		/// </summary>
		/// <param name="to">
		/// Phone/Card number of payee merchant.
		/// </param>
		/// <param name="amount">
		/// Amount to send.
		/// </param>
		/// <param name="currency">
		/// Currency name.
		/// </param>
		/// <param name="kind">
		/// Kind of transfer.
		/// </param>
		/// <param name="description">
		/// Transaction description.
		/// </param>
		/// <param name="orderId">
		/// Order identifier.
		/// </param>
		/// <returns>
		/// Transaction identifier.
		/// </returns>
        public string SendMoney(string to, double amount, string currency, string kind, string description, string orderId)
        {
            if (string.IsNullOrEmpty(to))
                throw new ArgumentException("to");
            if (amount <= 0)
                throw new ArgumentException("amount");
            if (string.IsNullOrEmpty(currency))
                throw new ArgumentException("currency");
            if (string.IsNullOrEmpty(kind))
                throw new ArgumentException("kind");
            if (string.IsNullOrEmpty(orderId))
                throw new ArgumentException("orderId");

            SendMoneyOperation operation = new SendMoneyOperation()
            {
                MerchantId  = this.MerchantId,
                Amount      = amount,
                Currency    = currency,
                Description = description,
                Kind        = kind,
                OrderId     = orderId,
                To          = to
            };
            SendMoneyResponse response = (SendMoneyResponse)ProcessOperation(operation);

            return response.TransactionId;
        }
		
		/// <summary>
		/// Gets transaction information using transaction identifier.
		/// </summary>
		/// <param name="transactionId">
		/// Transaction identifier.
		/// </param>
		/// <returns>
		/// A <see cref="Transaction"/> object.
		/// </returns>
        public Transaction ViewTransactionByTransactionId(string transactionId)
        {
            ViewTransactionOperation operation = new ViewTransactionOperation()
            {
                MerchantId    = this.MerchantId,
                TransactionId = transactionId
            };
            ViewTransactionResponse response = (ViewTransactionResponse)ProcessOperation(operation);

            return response.TransactionInfo;
        }
		
		/// <summary>
		/// Gets transaction information using order identifier.
		/// </summary>
		/// <param name="orderId">
		/// Order identifier.
		/// </param>
		/// <returns>
		/// A <see cref="Transaction"/> object.
		/// </returns>
        public Transaction ViewTransactionByOrderId(string orderId)
        {
            ViewTransactionOperation operation = new ViewTransactionOperation()
            {
                MerchantId         = this.MerchantId,
                TransactionOrderId = orderId
            };
            ViewTransactionResponse response = (ViewTransactionResponse)ProcessOperation(operation);

            return response.TransactionInfo;
        }
		
		/// <summary>
		/// Implements phone credit operation.
		/// </summary>
		/// <param name="phone">
		/// Phone number.
		/// </param>
		/// <param name="amount">
		/// Amount value.
		/// </param>
		/// <param name="currency">
		/// Currency name.
		/// </param>
		/// <param name="orderId">
		/// Order identifier.
		/// </param>
		public void PhoneCredit(string phone, double amount, string currency, string orderId)
		{
			PhoneCreditOperation operation = new PhoneCreditOperation()
			{
				MerchantId = this.MerchantId,
				Phone = phone,
				Amount = amount,
				Currency = currency,
				OrderId = orderId
			};
			ProcessOperation(operation);
		}

        protected virtual Response ProcessOperation(Operation operation)
        {
            Request request = new Request();
            request.SignatureProvider = (operation is SendMoneyOperation) ? this.SendMoneySignatureProvider : this.OtherOperationsSignatureProvider;
            request.Operations.Add(operation);
            Response[] responses = request.GetResponses();
            if (responses.Length == 0)
                throw new LiqPayException(ErrorCode.ResponseNotFound, "Response is not found in result.", string.Empty);
            else if (responses.Length == 1)
            {
                if (!responses[0].Success)
                    throw new LiqPayException(responses[0].Code, responses[0].ResponseDescription, responses[0].ResponseText);
            }
            else
            {
                throw new LiqPayException(
                    ErrorCode.TooManyResponses, 
                    string.Format(CultureInfo.InvariantCulture, "Too many responses found. Expected 1 response but got {0}.", responses.Length), 
                    string.Empty);
            }

            return responses[0];
        }
    }

}

