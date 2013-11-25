﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Optimization;
using Roadkill.Core.Configuration;

namespace Roadkill.Core.Mvc
{
	public class Bundles
	{
		public static string CssFilename { get; private set; }
		public static string JsFilename { get; private set; }

		public static void Register()
		{
			CssFilename = string.Format("roadkill{0}.css", ApplicationSettings.ProductVersion);
			JsFilename = string.Format("roadkill{0}.js", ApplicationSettings.ProductVersion);

			// Bundle all CSS/JS files into a single file		
			StyleBundle cssBundle = new StyleBundle("~/Assets/CSS/" + CssFilename);
			cssBundle.IncludeDirectory("~/Assets/CSS/", "*.css");

			ScriptBundle defaultJsBundle = new ScriptBundle("~/Assets/Scripts/" + JsFilename);
			defaultJsBundle.Include("~/Assets/Scripts/*.js");
			defaultJsBundle.Include("~/Assets/Scripts/jquery/*.js");
			defaultJsBundle.Include("~/Assets/Scripts/roadkill/*.js");
			defaultJsBundle.Include("~/Assets/Scripts/roadkill/filemanager/*.js");

			BundleTable.Bundles.Add(cssBundle);
			BundleTable.Bundles.Add(defaultJsBundle);

			// Ignore all Javascript testing framework autogenerated files
			BundleTable.Bundles.IgnoreList.Ignore("_Chutzpah*", OptimizationMode.Always);

			// Ignore the installer CSS as it's referenced by file
			BundleTable.Bundles.IgnoreList.Ignore("roadkill.installer.css");
		}
	}
}
