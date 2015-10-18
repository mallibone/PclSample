using UIKit;
using System;
using PclSample.Core;

namespace PclSample.iOS
{
	public class Application
	{
		private static Lazy<ViewModelLocator> _locator = new Lazy<ViewModelLocator>(() => new ViewModelLocator());
		public static ViewModelLocator Locator => _locator.Value;
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "AppDelegate");
		}
	}
}
