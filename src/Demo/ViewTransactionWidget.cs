// 
//  ViewTransactionWidget.cs
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
using Magnis.Web.Services.LiqPay;

namespace LiqPayDemo
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ViewTransactionWidget : Gtk.Bin
	{
		public ViewTransactionWidget ()
		{
			this.Build ();
			InitializeControls();
		}
		
		void InitializeControls()
		{
			merchantIdEntry.Text = UserSettings.SharedSettings.MerchantId;
			pwdEntry.Text = UserSettings.SharedSettings.OtherPassword;
		}
		
		void SaveSettings()
		{
			try
			{
				UserSettings.SharedSettings.Save();
			}
			catch
			{
				
			}
		}
		
		bool Validate()
		{
			if (merchantIdEntry.Text.Trim() == string.Empty)
			{
				merchantIdEntry.GrabFocus();
				DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Enter merchant identifier.");
				
				return false;
			}
			if (pwdEntry.Text.Trim() == string.Empty)
			{
				pwdEntry.GrabFocus();
				DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Enter password.");
				
				return false;
			}
			if (searchTransactionIdEntry.Text.Trim() == string.Empty && searchOrderIdEntry.Text.Trim() == string.Empty)
			{
				DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Enter transaction or order identifier.");
				
				return false;
			}
			
			return true;
		}
		
		#region Event handlers
		
		protected virtual void OnViewTransactionClicked (object sender, System.EventArgs e)
		{
			if (Validate())
			{
				transactionIDEntry.Text = string.Empty;
				orderIdEntry.Text = string.Empty;
				fromEntry.Text = string.Empty;
				toEntry.Text = string.Empty;
				amountEntry.Text = string.Empty;
				currencyEntry.Text = string.Empty;
				descriptionEntry.Text = string.Empty;
				refererEntry.Text = string.Empty;
				
				string transactionId = searchTransactionIdEntry.Text.Trim();
				string orderId = searchOrderIdEntry.Text.Trim();
				string merchantId = merchantIdEntry.Text.Trim();
				string pwd = pwdEntry.Text.Trim();
				try
				{
					
					LiqPayClient client = new LiqPayClient(merchantId, string.Empty, pwd);
					Transaction transaction = string.IsNullOrEmpty(transactionId) ? client.ViewTransactionByOrderId(orderId) : client.ViewTransactionByTransactionId(transactionId);
					transactionIDEntry.Text = transaction.Id;
					orderIdEntry.Text = transaction.OrderId;
					fromEntry.Text = transaction.From;
					toEntry.Text = transaction.To;
					amountEntry.Text = transaction.Amount.ToString();
					currencyEntry.Text = transaction.Currency;
					descriptionEntry.Text = transaction.Description;
					
					// Save settings
					UserSettings.SharedSettings.MerchantId = merchantId;
					UserSettings.SharedSettings.OtherPassword = pwd;
					SaveSettings();
				}
				catch (Exception ex)
				{
					DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "View transaction failed. Error: " + ex.Message);
				}
			}
		}
		
		#endregion
	}
}