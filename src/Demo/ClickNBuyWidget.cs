// 
//  ClickNBuyWidget.cs
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
	public partial class ClickNBuyWidget : Gtk.Bin
	{
		public ClickNBuyWidget ()
		{
			this.Build ();
			InitializeControls();
		}
		
		void InitializeControls()
		{
			merchantIdEntry.Text = UserSettings.SharedSettings.MerchantId;
			pwdEntry.Text = UserSettings.SharedSettings.OtherPassword;
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
			if (orderIdEntry.Text.Trim() == string.Empty)
			{
				orderIdEntry.GrabFocus();
				DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Enter order identifier.");
				
				return false;
			}
			if (amountEntry.Text.Trim() == string.Empty)
			{
				amountEntry.GrabFocus();
				DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Enter amount value.");
				
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
			if (payWayComboBox.ActiveText.Trim() == string.Empty)
			{
				payWayComboBox.GrabFocus();
				DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Enter pay way.");
				
				return false;
			}
			
			return true;
		}
		
		#region Event handlers
		
		protected virtual void OnGenerateHtmlClicked (object sender, System.EventArgs e)
		{
			if (Validate())
			{
				string merchantId = merchantIdEntry.Text.Trim();
				string pwd = pwdEntry.Text.Trim();
				string resultUrl = resultUrlEntry.Text.Trim();
				string serverUrl = serverUrlEntry.Text.Trim();
				try
				{
					ClickNBuy clicknbuy = new ClickNBuy()
					{
						MerchantId = merchantId,
						ResultUrl = string.IsNullOrEmpty(resultUrl) ? null : new Uri(resultUrl),
						ServerUrl = string.IsNullOrEmpty(serverUrl) ? null : new Uri(serverUrl),
						Amount = double.Parse(amountEntry.Text),
						Currency = currencyComboBox.ActiveText,
						Description = descriptionEntry.Text,
						DefaultPhone = defaultPhoneEntry.Text,
						OrderId = orderIdEntry.Text,
						PayWay = payWayComboBox.ActiveText
					};
					SignatureProvider signatureProvider = new SignatureProvider(pwd);
					generatedHtmlTextView.Buffer.Text = clicknbuy.ToHtml(signatureProvider, "Pay");
					
					UserSettings.SharedSettings.MerchantId = merchantId;
					UserSettings.SharedSettings.OtherPassword = pwd;
					UserSettings.SharedSettings.Save();
				}
				catch (Exception ex)
				{
					DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Generate html for click&buy operation failed. Error: " + ex.Message);
				}
			}
		}
		
		#endregion
	}
}

