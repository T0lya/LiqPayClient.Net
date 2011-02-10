// 
//  PhoneCreditWidget.cs
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
	public partial class PhoneCreditWidget : Gtk.Bin
	{
		public PhoneCreditWidget ()
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
			if (amountEntry.Text.Trim() == string.Empty)
			{
				amountEntry.GrabFocus();
				DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Enter amount.");
				
				return false;
			}
			double amount;
			if (!double.TryParse(amountEntry.Text, out amount) || amount <= 0)
			{
				amountEntry.GrabFocus();
				DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Incorrect amount value.");
				
				return false;
			}
			if (currencyComboBox.ActiveText == string.Empty)
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
		
		protected virtual void OnPhoneCreditClicked (object sender, System.EventArgs e)
		{
			if (Validate())
			{
				string merchantId = merchantIdEntry.Text.Trim();
				string pwd = pwdEntry.Text.Trim();
				try
				{
					LiqPayClient client = new LiqPayClient(merchantId, string.Empty, pwd);
					client.PhoneCredit(phoneEntry.Text, 
					                   double.Parse(amountEntry.Text), 
					                   currencyComboBox.ActiveText, 
					                   orderIdEntry.Text);
					
					UserSettings.SharedSettings.MerchantId = merchantId;
					UserSettings.SharedSettings.SendMoneyPassword = pwd;
					SaveSettings();
				}
				catch (Exception ex)
				{
					DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Phone credit operation failed. Error: " + ex.Message);
				}
			}
		}

		#endregion
	}
}

