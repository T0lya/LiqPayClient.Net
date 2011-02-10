// 
//  ViewBalanceWidget.cs
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
using System.Text;
using Magnis.Web.Services.LiqPay;

namespace LiqPayDemo
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ViewBalanceWidget : Gtk.Bin
	{
		public ViewBalanceWidget ()
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
			
			return true;
		}
		
		#region Event handlers
		
		protected virtual void OnViewBalanceClicked (object sender, System.EventArgs e)
		{
			if (Validate())
			{
				string merchantId = merchantIdEntry.Text.Trim();
				string pwd = pwdEntry.Text.Trim();
				
				balanceTextView.Buffer.Clear();
				try
				{
					LiqPayClient client = new LiqPayClient(merchantId, string.Empty, pwd);
					Dictionary<string, double> balance = client.ViewBalance();
					StringBuilder sb = new StringBuilder();
					foreach (KeyValuePair<string, double> balancePair in balance)
					{
						sb.AppendLine(string.Format("{0}: {1}", balancePair.Key, balancePair.Value));
					}
					balanceTextView.Buffer.Text = sb.ToString();
					// Save settings
					UserSettings.SharedSettings.MerchantId = merchantId;
					UserSettings.SharedSettings.OtherPassword = pwd;
					SaveSettings();
				}
				catch (Exception ex)
				{
					DialogHelper.DisplayError((Gtk.Window)this.Toplevel, "Failed to check balance. Error: " + ex.Message);
				}
			}
		}
		
		#endregion
	}
}

