// 
//  UserSettings.cs
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
using System.Configuration;

namespace LiqPayDemo
{
	public class UserSettings
	{
		const string MerchantIdKey			= "MerchantId";
		const string SendMoneyPasswordKey	= "SendMoneyPassword";
		const string OtherPasswordKey		= "OtherPassword";
		
		static readonly UserSettings sharedSettings = new UserSettings();
		Configuration config;
		
		private UserSettings ()
		{
		}
		
		public static UserSettings SharedSettings
		{
			get { return sharedSettings; }
		}
		
		#region Properties
		
		public string MerchantId
		{
			get { return GetConfigValue(MerchantIdKey); }
			set	{ SetConfigValue(MerchantIdKey, value);	}
		}
		
		public string SendMoneyPassword
		{
			get { return GetConfigValue(SendMoneyPasswordKey); }
			set { SetConfigValue(SendMoneyPasswordKey, value); }
		}
		
		public string OtherPassword
		{
			get { return GetConfigValue(OtherPasswordKey); }
			set { SetConfigValue(OtherPasswordKey, value); }
		}
		
		#endregion
		
		public string GetConfigValue(string key)
		{
			KeyValueConfigurationElement el = config.AppSettings.Settings[key];
			if (el == null)
				return string.Empty;
			
			return el.Value ?? string.Empty;
		}
		
		public void SetConfigValue(string key, string value)
		{
			config.AppSettings.Settings.Add(key, value);
		}
		
		public void Load()
		{
			config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
		}
		
		public void Save()
		{
			config.Save();
		}
	}
}

