using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using ManagedUrbanAirshipForMonoDroid.Push;

namespace ManagedUrbanAirshipForMonoDroid.Sample
{
	[Activity (Label = "ManagedUrbanAirshipForMonoDroid.Sample", MainLauncher = true)]
	public class MainActivity : Activity
	{


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				//var intent = new Intent(BaseContext, UAirship.PushPreferencesActivityClass);
                //StartActivity(intent);
				var pm = PushManager.Shared;
				Log.Info("Info",PushManager.ExtraNotificationId);
			};
		}
	}
}


