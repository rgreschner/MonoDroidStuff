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

namespace ManagedUrbanAirshipForMonoDroid.Push
{
	public class BasicPushNotificationBuilder : Java.Lang.Object, IPushNotificationBuilder
	{
		static IntPtr class_ref = JNIEnv.FindClass("com/urbanairship/push/BasicPushNotificationBuilder");
		static IntPtr id_ctor;
		
		public BasicPushNotificationBuilder (IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
		{
			
		}
		
		public BasicPushNotificationBuilder(){
	
			if (id_ctor == IntPtr.Zero)
			{
				id_ctor = JNIEnv.GetMethodID (class_ref, "<init>", "()V");
			}
			base.SetHandle (JNIEnv.NewObject (class_ref, id_ctor), JniHandleOwnership.TransferLocalRef);
		}
	}
}

