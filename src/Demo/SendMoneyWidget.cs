// 
//  SendMoneyWidget.cs
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
using Gtk;
using Magnis.Web.Services.LiqPay;

namespace LiqPayDemo
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class SendMoneyWidget : Gtk.Bin
	{
		public SendMoneyWidget ()
		{
			this.Build ();
			InitializeControls();
		}
		
		void InitializeControls()
		{
			merchantIdEntry.Text = UserSettings.SharedSettings.MerchantId;
			pwdEntry.Text = UserSettings.SharedSettings.SendMoneyPassword;
			foreach (string currency in Currency.Names)
				currencyComboBox.AppendText(currency);
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
			TreeIter moneyKindIter;
			if (!kindComboBox.GetActiveIter(out moneyKindIter))
			{
				kindLabel.GrabFocus();
				DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Enter transfer kind.");
				
				return false;
			}
			if (toEntry.Text.Trim() == string.Empty)
			{
				toEntry.GrabFocus();
				DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Enter recipient.");
				
				return false;
			}
			if (amountEntry.Text.Trim() == string.Empty)
			{
				amountEntry.GrabFocus();
				DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Enter amount.");
				
				return false;
			}
			double amount;
			if (!double.TryParse(amountEntry.Text, out amount))
			{
				amountEntry.GrabFocus();
				DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Incorrect amount value.");
				
				return false;
			}
			if (currencyComboBox.ActiveText.Trim() == string.Empty)
			{
				currencyComboBox.GrabFocus();
				DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Enter currency.");
				
				return false;
			}
			if (orderIdEntry.Text.Trim() == string.Empty)
			{
				orderIdEntry.GrabFocus();
				DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Enter order identifier.");
				
				return false;
			}
			
			return true;
		}
		
		#region Event handlers
		
		protected virtual void OnSendMoneyClicked (object sender, System.EventArgs e)
		{
			transactionIdLabel.Text = string.Empty;
			if (Validate())
			{
				string merchantId = merchantIdEntry.Text.Trim();
				string pwd = pwdEntry.Text.Trim();
				try
				{
					LiqPayClient client = new LiqPayClient(merchantId, pwd, string.Empty);
					string transactionId = client.SendMoney(toEntry.Text,
					                                        double.Parse(amountEntry.Text),
					                                        currencyComboBox.ActiveText,
					                                        kindComboBox.ActiveText.ToLower(),
					                                        descriptionEntry.Text,
					                                        orderIdEntry.Text
					                                        );
					transactionIdLabel.Text = transactionId;
					
					// Save settings
					UserSettings.SharedSettings.MerchantId = merchantId;
					UserSettings.SharedSettings.SendMoneyPassword = pwd;
					SaveSettings();
				}
				catch (Exception ex)
				{
					DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Send money failed. Error: " + ex.Message);
				}
			}
		}
		
		#endregion
	}	
}

