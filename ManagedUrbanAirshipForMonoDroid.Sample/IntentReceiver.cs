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
	[BroadcastReceiver(Enabled = true, Exported = true)]
	[IntentFilterAttribute(new []{ "com.urbanairship.push.PUSH_RECEIVED" }, Categories = new []{ "managedurbanairshipformonodroid.sample"})]
	public class IntentReceiver : BroadcastReceiver
	{
		private const String logTag = "managedurbanairshipformonodroid.sample";
		
		public override void OnReceive (Context context, Intent intent)
		{
			Log.Info(logTag, "Received intent: " + intent.ToString());
			var action = intent.Action;
			
			if (PushManager.ActionPushReceived.Equals(action))
			{
				var id = intent.GetIntExtra(PushManager.ExtraNotificationId, 0);
				
				var alert = intent.GetStringExtra(PushManager.ExtraAlert);
				
				Log.Info(logTag, "Received push notification. Alert: " 
		            + alert
		            + " [NotificationID="+id+"]");

		    	LogPushExtras(intent);
			} 
			/*else if (PushManager.ActionNotificationOpened.Equals(action)) {

				Log.Info(logTag, "User clicked notification. Message: " + intent.GetStringExtra(PushManager.ExtraAlert));

				LogPushExtras(intent);

            	var launch = new Intent(Intent.ActionMain);
				launch.SetClass(UAirship.Shared.ApplicationContext, typeof(MainActivity));
				launch.SetFlags(ActivityFlags.NewTask);
			
            	UAirship.Shared.ApplicationContext.StartActivity(launch);

			} else if (PushManager.ActionRegistrationFinished.Equals(action)) {
	            Log.Info(logTag, "Registration complete. APID:" + intent.GetStringExtra(PushManager.ExtraAPID)
	                    + ". Valid: " + intent.GetBooleanExtra(PushManager.ExtraRegistrationValid, false));
			}*/
				
		}
		
		private void LogPushExtras(Intent intent) {
			
			//ignore standard C2DM extra keys
            var ignoredKeys = new []{
                    "collapse_key",//c2dm collapse key
                    "from",//c2dm sender
                    PushManager.ExtraNotificationId,//int id of generated notification (ACTION_PUSH_RECEIVED only)
                    PushManager.ExtraPushId,//internal UA push id
                    PushManager.ExtraAlert//ignore alert
			};
			
	        var keys = intent.Extras.KeySet();
	        foreach (var key in keys) {
	
	            
	            if (ignoredKeys.Contains(key)) {
	                continue;
	            }
	            Log.Info(logTag, "Push Notification Extra: ["+key+" : " + intent.GetStringExtra(key) + "]");
	        }
		}
	}
	

}

