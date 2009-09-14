using System;

namespace MiniSqlQuery.PlugIns.TemplateViewer
{
	public class TemplateResult
	{
		public string Text { get; set; }
		public string Extension { get; set; }

		/// <summary>
		/// Converts the <see cref="Extension"/> to an Editor "Syntax Name" such as "C#".
		/// </summary>
		public string SyntaxName
		{
			get
			{
				string ext = Extension ?? "";
				switch (ext.ToLower())
				{
					case "bat":
					case "boo":
					case "coco":
					case "java":
					case "patch":
					case "php":
					case "tex":
					case "xml":
					case "sql":
					case "txt":
						return Extension;

					case "asp":
					case "aspx":
					case "htm":
					case "html":
						return "ASP/XHTML";

					case "vb":
						return "VBNET";

					case "js":
						return "JavaScript";

					case "cpp":
					case "cxx":
						return "C++.NET";

					case "cs":
						return "C#";

					default:
						return "";
				}
			}
		}
	}
}