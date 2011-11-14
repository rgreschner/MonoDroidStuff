using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using ManagedUrbanAirshipForMonoDroid.Push;

namespace ManagedUrbanAirshipForMonoDroid.Sample
{

	
	[Application]
	public class MyApplication : Application
	{
		public MyApplication (IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
		{
			
		}
		
		public override void OnCreate ()
		{
			base.OnCreate ();
			var configOptions = AirshipConfigOptions.LoadDefaultOptions(this);
			
			UAirship.TakeOff(this, configOptions);
	
			//object nb = null;
			PushManager.Shared.SetNotificationBuilder(new BasicPushNotificationBuilder());
			PushManager.Shared.SetIntentReceiver(typeof(IntentReceiver));
			PushManager.EnablePush();
			var prefs = PushManager.Shared.GetPreferences();
			
			Log.Info(String.Empty,"MyApplication onCreate - App APID: " + prefs.GetPushId());
		}
	}
}

