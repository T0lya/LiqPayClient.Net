// 
//  DialogHelper.cs
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
namespace LiqPayDemo
{
	public static class DialogHelper
	{
		public static void DisplayError(Window parent, string message)
		{
			MessageDialog dlg = new MessageDialog(parent, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, message);
			dlg.Run();
			dlg.Destroy();
		}
	}
}

