using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using CustomerManagement.Core.Models;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using MonoTouch.Foundation;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ExtensionMethods;

namespace CustomerManagement.Touch
{
	[Register ("AppDelegate")]
	public partial class AppDelegate
        : MvxApplicationDelegate
		, IMvxServiceConsumer<IMvxStartNavigation>
	{
		// class-level declarations
		private UIWindow window;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			// initialize app for single screen iPhone display with modal support
            var presenter = new MvxModalSupportTouchViewPresenter(this, window);
   			var setup = new Setup(this, presenter);
			setup.Initialize();
			
			// start the app
			var start = this.GetService<IMvxStartNavigation>();
			start.Start();

            window.MakeKeyAndVisible();
			
            //UIDevice.CurrentDevice.BeginGeneratingDeviceOrientationNotifications();		
			
			return true;
		}
	}

/*	
	[MXTouchTabletOptions(TabletLayout.MasterPane, MasterShowsinLandscape = true, MasterShowsinPotrait = true, AllowDividerResize = false)]
	[MXTouchContainerOptions(SplashBitmap = "Images/splash.jpg")]
	[Register ("AppDelegate")]
*/
	
}