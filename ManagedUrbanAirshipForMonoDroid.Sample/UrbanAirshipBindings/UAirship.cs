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

namespace ManagedUrbanAirshipForMonoDroid
{
	public class UAirship : Java.Lang.Object {
	
		public UAirship (IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
		{
			
		}
		
		internal static IntPtr class_ref = JNIEnv.FindClass ("com/urbanairship/UAirship");
		internal static IntPtr id_takeOff_1;
		internal static IntPtr id_takeOff_2;
		
		static IntPtr id_static_getShared;
		
		public static UAirship Shared {
			get {
				if (IntPtr.Zero == id_static_getShared)
				{
					id_static_getShared = JNIEnv.GetStaticMethodID(class_ref,"getShared","()Lcom/urbanairship/UAirship;");
				}
				var handle = JNIEnv.CallStaticObjectMethod(class_ref, id_static_getShared);
				return new UAirship(handle, JniHandleOwnership.DoNotTransfer);
			}
		}
		
	
		
		public static void TakeOff (Application arg0)
		{
			if (IntPtr.Zero == id_takeOff_1)
			{
				id_takeOff_1 = JNIEnv.GetStaticMethodID(class_ref,"takeOff","(Landroid/app/Application;)V");
			}
			JNIEnv.CallStaticVoidMethod(class_ref, id_takeOff_1, new JValue(arg0));
		}
	
		public static void TakeOff (Application arg0, AirshipConfigOptions arg1)
		{
			if (IntPtr.Zero == id_takeOff_2)
			{
				id_takeOff_2 = JNIEnv.GetStaticMethodID(class_ref,"takeOff","(Landroid/app/Application;Lcom/urbanairship/AirshipConfigOptions;)V");
			}
			JNIEnv.CallStaticVoidMethod(class_ref, id_takeOff_2, new JValue(arg0), new JValue(arg1));
		}
	}
}

