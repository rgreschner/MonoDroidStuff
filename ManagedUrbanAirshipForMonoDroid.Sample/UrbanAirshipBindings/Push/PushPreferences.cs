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
	public class PushPreferences : Java.Lang.Object {
		
		/// <summary>
		/// IntPtr to class reference.
		/// </summary>
		internal static IntPtr class_ref = JNIEnv.FindClass ("com/urbanairship/push/PushPreferences");
		
		IntPtr id_getPushId;
		
		public PushPreferences (IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
		{
		}
		
		public string GetPushId ()
		{
			if (id_getPushId == IntPtr.Zero)
			{
				id_getPushId = JNIEnv.GetMethodID (class_ref, "getPushId", "()Ljava/lang/String;");
			}
			
			var handle = JNIEnv.CallObjectMethod(Handle, id_getPushId);
			return JNIEnv.GetString(handle, JniHandleOwnership.DoNotTransfer);
		}
	
	}
}

