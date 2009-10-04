#region License
// Copyright 2005-2009 Paul Kohler (http://pksoftware.net/MiniSqlQuery/). All rights reserved.
// This source code is made available under the terms of the Microsoft Public License (Ms-PL)
// http://minisqlquery.codeplex.com/license
#endregion
using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using MiniSqlQuery.Core;

namespace MiniSqlQuery.PlugIns.DatabaseInspector.Commands
{
	public class TruncateTableCommand : GenerateStatementCommandBase
	{
		public TruncateTableCommand()
			: base("Truncate Table")
		{
			SmallImage = ImageResource.table_delete;
		}

		public override void Execute()
		{
			IHostWindow hostWindow = Services.HostWindow;
			string tableName = hostWindow.DatabaseInspector.RightClickedTableName;

			if (tableName != null &&
			    MessageBox.Show("Delete all table data, are you sure?", "Truncate Table Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) ==
			    DialogResult.Yes)
			{
				DbConnection dbConnection;
				DbCommand cmd = null;

				try
				{
					hostWindow.SetPointerState(Cursors.WaitCursor);
					dbConnection = Settings.GetOpenConnection();
					cmd = dbConnection.CreateCommand();
					cmd.CommandText = "DELETE FROM " + tableName;
					cmd.CommandType = CommandType.Text;
					cmd.ExecuteNonQuery();
					Services.PostMessage(SystemMessage.TableTruncated, tableName);
				}
				catch (DbException dbExp)
				{
					hostWindow.DisplaySimpleMessageBox(null, dbExp.Message, "Error");
				}
				catch (InvalidOperationException invalidExp)
				{
					hostWindow.DisplaySimpleMessageBox(null, invalidExp.Message, "Error");
				}
				finally
				{
					if (cmd != null)
					{
						cmd.Dispose();
					}
					hostWindow.SetPointerState(Cursors.Default);
				}
			}
		}
	}
}