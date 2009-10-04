﻿#region License
// Copyright 2005-2009 Paul Kohler (http://pksoftware.net/MiniSqlQuery/). All rights reserved.
// This source code is made available under the terms of the Microsoft Public License (Ms-PL)
// http://minisqlquery.codeplex.com/license
#endregion
using System;
using MiniSqlQuery.Core;
using MiniSqlQuery.PlugIns.TemplateViewer.Commands;

namespace MiniSqlQuery.PlugIns.TemplateViewer
{
	public class TemplateViewerLoader : PluginLoaderBase
	{
		public TemplateViewerLoader()
			: base("Template Viewer", "A Mini SQL Query Plugin for displaying template SQL items.", 50)
		{
		}

		public override void InitializePlugIn()
		{
			Services.RegisterEditor<TemplateEditorForm>(new FileEditorDescriptor("Template Editor", "mt-editor", "mt"));
			Services.RegisterComponent<TemplateHost>("TemplateHost");
			Services.RegisterSingletonComponent<TemplateData, TemplateData>("TemplateData");

			Services.RegisterComponent<TemplateViewForm>("TemplateViewForm");
			Services.HostWindow.AddPluginCommand<RunTemplateCommand>();
			Services.HostWindow.ShowToolWindow(Services.Resolve<TemplateViewForm>(), WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
		}
	}
}