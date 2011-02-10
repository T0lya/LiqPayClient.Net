// 
//  Classes.cs
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
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace Magnis.Web.Services.LiqPay
{
	/// <summary>
	/// Provides available operation names.
	/// </summary>
	public static class LiqPayAction
    {
		/// <summary>
		/// Represents send money operation name.
		/// </summary>
        public const string SendMoney       = "send_money";
		
		/// <summary>
		/// Represents view merchant balance operation name.
		/// </summary>
        public const string ViewBalance     = "view_balance";
		
		/// <summary>
		/// Represents credit phone operation name.
		/// </summary>
		public const string PhoneCredit		= "phone_credit";
		
		/// <summary>
		/// Represents view transaction operation name
		/// </summary>
        public const string ViewTransaction = "view_transaction";
    }
	
	
	/// <summary>
	/// Provides LiqPay operation status names
	/// </summary>
    public static class ActionStatus
    {
		/// <summary>
		/// Represents success status name.
		/// </summary>
        public const string Success = "success";
		
		/// <summary>
		/// Represents failure status name.
		/// </summary>
        public const string Failure = "failure";
    }
	
	
	/// <summary>
	/// Provides transfer type names.
	/// </summary>
	public static class TransferKind
    {
		/// <summary>
		/// Represents send money to merchant account transfer kind.
		/// </summary>
        public const string Phone = "phone";
		
		/// <summary>
		/// Represents send money to VISA card transfer kind.
		/// </summary>
        public const string Card  = "card";
    }
	
	
	/// <summary>
	/// Provides currency names.
	/// </summary>
	public static class Currency
    {
        public const string UAH = "UAH";
        public const string EUR = "EUR";
        public const string USD = "USD";
        public const string RUR = "RUR";
		
		/// <summary>
		/// Gets array of available currencies.
		/// </summary>
		public static string[] Names
		{
			get
			{
				return new string[] {
					UAH,
					EUR,
					USD,
					RUR
				};
			}
		}
    }
	
	
	/// <summary>
	/// Represents transaction information
	/// </summary>
	public class Transaction
    {
		/// <summary>
		/// Gets/Sets transaction identifier.
		/// </summary>
        public string Id { get; set; }
		
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
		/// Gets/Sets transaction description.
		/// </summary>
        public string Description { get; set; }
		
		/// <summary>
		/// Gets/Sets sender merchant phone number.
		/// </summary>
        public string From { get; set; }
		
		/// <summary>
		/// Gets/Sets payee merchant phone number.
		/// </summary>
        public string To { get; set; }
		
		/// <summary>
		/// Gets/Sets referer url address.
		/// </summary>
        public string RefererAddress { get; set; }
    }
	
	
	/// <summary>
	/// Provides common methods for receiving exchanges information.
	/// </summary>
	public static class Exchange
    {
        private const string GetExchangesUrl = "https://liqpay.com/exchanges/exchanges.cgi";
		
		/// <summary>
		/// Retrieves exchanges rates from the server.
		/// </summary>
		/// <returns>
		/// A dictionary of exchange rates where key is currency and value is a dictionary of currency and rate.
		/// </returns>
        public static Dictionary<string, Dictionary<string, double>> GetExchangeRates()
        {
            var rates = new Dictionary<string, Dictionary<string, double>>();

            // Load exchange rates from liqpay's site
            XDocument xml = XDocument.Load(GetExchangesUrl);
            if (xml.Root.HasElements)
            {
                foreach (XElement unitElement in xml.Root.Elements())
                {
                    Dictionary<string, double> exchanges = new Dictionary<string, double>();
                    rates.Add(unitElement.Name.ToString(), exchanges);
                    if (unitElement.HasElements)
                    {
                        foreach (XElement exchange in unitElement.Elements())
                            exchanges.Add(exchange.Name.ToString(), double.Parse(exchange.Value, System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
            }

            return rates;
        }
    }
	
	
	/// <summary>
	/// Provides common methods to work with signature.
	/// </summary>
    public sealed class SignatureProvider
    {
        private string Password { get; set; }
		
		/// <summary>
		/// Initializes a new instance of SignatureProvider class with merchant password.
		/// </summary>
		/// <param name="merchantPassword">
		/// Merchant password
		/// </param>
        public SignatureProvider(string password)
        {
            this.Password = password;
        }
		
		/// <summary>
		/// Generates signature for specified data.
		/// </summary>
		/// <param name="data">
		/// The data to generate signature for.
		/// </param>
		/// <returns>
		/// A string containing generated signature.
		/// </returns>
        public string GenerateSignature(string data)
        {
            string text = this.Password + data + this.Password;
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            {
                byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));

                return Convert.ToBase64String(hash);
            }
        }
    }
	
	
	/// <summary>
	/// Provides error code names.
	/// </summary>
	public static class ErrorCode
    {
        public const string ResponseNotFound        = "response_not_found";
        public const string SignatureError          = "signature_error";
        public const string TooManyResponses        = "too_many_responses";
        public const string UnknownAction           = "unknown_action";
        public const string ResponseIsNotWellFormed = "response_is_not_well_formed";
	}
	
	
	/// <summary>
	/// Provides exception class for LiqPay operations
	/// </summary>
	[Serializable]
    public class LiqPayException : Exception
    {
        protected const string CodeKey     = "Code";
        protected const string ResponseKey = "Response";

        public string Code { get; set; }
        public string Response { get; set; }

        #region Constructors

        public LiqPayException()
        {

        }

        public LiqPayException(string message)
            : base(message)
        {

        }

        public LiqPayException(string message, Exception innerException)
            :base(message, innerException)
        {

        }

        public LiqPayException(string code, string message, string response)
            : this(message)
        {
            this.Code = code;
            this.Response = response;
        }

        public LiqPayException(string code, string message, string response, Exception innerException)
            : base(message, innerException)
        {
            this.Code = code;
            this.Response = response;
        }

        protected LiqPayException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(CodeKey, this.Code);
            info.AddValue(ResponseKey, this.Response);
        }
    }

}

