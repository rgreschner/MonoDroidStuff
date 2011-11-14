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
	public class AirshipConfigOptions : Java.Lang.Object {
		static IntPtr class_ref = JNIEnv.FindClass("com/urbanairship/AirshipConfigOptions");
		static IntPtr id_static_loadDefaultOptions;
		
		public AirshipConfigOptions (IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
		{
			
		}
		
		public static AirshipConfigOptions LoadDefaultOptions(Context context){
			if (IntPtr.Zero == id_static_loadDefaultOptions)
			{
				id_static_loadDefaultOptions = JNIEnv.GetStaticMethodID(class_ref, "loadDefaultOptions", "(Landroid/content/Context;)Lcom/urbanairship/AirshipConfigOptions;");
			}
			var handle = JNIEnv.CallStaticObjectMethod(class_ref, id_static_loadDefaultOptions, new JValue(context));
			return new AirshipConfigOptions(handle, JniHandleOwnership.DoNotTransfer);
		}
	}
}

