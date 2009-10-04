﻿#region License
// Copyright 2005-2009 Paul Kohler (http://pksoftware.net/MiniSqlQuery/). All rights reserved.
// This source code is made available under the terms of the Microsoft Public License (Ms-PL)
// http://minisqlquery.codeplex.com/license
#endregion
using System;
using System.Windows.Forms;
using MiniSqlQuery.Core;
using MiniSqlQuery.Core.Commands;

namespace MiniSqlQuery.PlugIns.SearchTools.Commands
{
	public class ShowGoToLineFormCommand : CommandBase
	{
		public ShowGoToLineFormCommand() 
			: base("Go To Line...")
		{
			ShortcutKeys = Keys.Control | Keys.G;
		}

		public override bool Enabled
		{
			get { return HostWindow.ActiveChildForm is INavigatableDocument; }
		}

		public override void Execute()
		{
			if (Enabled)
			{
				GoToLineForm frm = Services.Resolve<GoToLineForm>();
				frm.ShowDialog(HostWindow as Form);
			}
		}
	}
}