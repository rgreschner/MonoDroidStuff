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
	public class PushManager : Java.Lang.Object {
		
		static IntPtr id_static_field_actionPushReceived;
		
		
		
		/// <summary>
		/// IntPtr to class reference.
		/// </summary>
		internal static IntPtr class_ref = JNIEnv.FindClass ("com/urbanairship/push/PushManager");
		
		
		IntPtr id_getPushPreferences;
		static IntPtr id_getShared;
		static IntPtr id_static_field_getExtraNotificationId;
		static IntPtr id_static_field_extraAlert;
		static IntPtr id_setIntentReceiver;
		static IntPtr id_enablePush;
		static IntPtr id_setPushNotificationBuilder;
		
		public PushManager (IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
		{
			
		}
		
		public static void EnablePush(){
			if (id_enablePush == IntPtr.Zero)
			{
				id_enablePush = JNIEnv.GetStaticMethodID (class_ref, "enablePush", "()V");
			}
			
			JNIEnv.CallStaticVoidMethod(class_ref, id_enablePush);
		}
		
		public PushPreferences GetPreferences ()
		{
			if (id_getPushPreferences == IntPtr.Zero)
			{
				id_getPushPreferences = JNIEnv.GetMethodID (class_ref, "getPreferences", "()Lcom/urbanairship/push/PushPreferences;");
			}
			
			var handle = JNIEnv.CallObjectMethod(Handle, id_getPushPreferences);
			return new PushPreferences(handle, JniHandleOwnership.DoNotTransfer);
		}
		
		public void SetIntentReceiver (Java.Lang.Class par1)
		{
			if (IntPtr.Zero == id_setIntentReceiver)
			{
				id_setIntentReceiver = JNIEnv.GetMethodID(class_ref, "setIntentReceiver","(Ljava/lang/Class;)V");
			}
			JNIEnv.CallVoidMethod(Handle, id_setIntentReceiver, new JValue(par1));
		}
	
		public void SetIntentReceiver (Type par1)
		{
			SetIntentReceiver(Java.Lang.Class.FromType(par1));
		}
	
		public void SetNotificationBuilder (IPushNotificationBuilder nb)
		{
			if (IntPtr.Zero == id_setPushNotificationBuilder)
			{
				id_setPushNotificationBuilder = JNIEnv.GetMethodID(class_ref, "setNotificationBuilder","(Lcom/urbanairship/push/PushNotificationBuilder;)V");
			}
			JNIEnv.CallVoidMethod(class_ref, id_setPushNotificationBuilder, new JValue(nb));
		}
		
		public static PushManager Shared {
			get {
				if (id_getShared == IntPtr.Zero)
				{
					id_getShared = JNIEnv.GetStaticMethodID (class_ref, "shared", "()Lcom/urbanairship/push/PushManager;");
				}
				
				var handle = JNIEnv.CallStaticObjectMethod(class_ref, id_getShared);
				return new PushManager(handle, JniHandleOwnership.DoNotTransfer);
			}
		}
		
		// TODO: Replace strings by constant expressions? :\
		// Probably better, there are constants for field names anyway...
		
		public static String ExtraNotificationId  {
			get {
				if (id_static_field_getExtraNotificationId == IntPtr.Zero)
				{
					id_static_field_getExtraNotificationId = JNIEnv.GetStaticFieldID(class_ref, "EXTRA_NOTIFICATION_ID", "Ljava/lang/String;");
					
				}
				
				var handle = JNIEnv.GetStaticObjectField (class_ref, id_static_field_getExtraNotificationId);
				return JNIEnv.GetString(handle, JniHandleOwnership.TransferGlobalRef);
			}
		}
		
		public static String ExtraAlert  {
			get {
				if (id_static_field_extraAlert == IntPtr.Zero)
				{
					id_static_field_extraAlert = JNIEnv.GetStaticFieldID(class_ref, "EXTRA_ALERT", "Ljava/lang/String;");
					
				}
				
				var handle = JNIEnv.GetStaticObjectField (class_ref, id_static_field_extraAlert);
				return JNIEnv.GetString(handle, JniHandleOwnership.DoNotTransfer);
			}
		}
		
		
		public static String ActionPushReceived {
			get {
			
				if (id_static_field_actionPushReceived == IntPtr.Zero)
				{
					id_static_field_actionPushReceived = JNIEnv.GetStaticFieldID(class_ref, "ACTION_PUSH_RECEIVED", "Ljava/lang/String;");
				}
				
				var handle = JNIEnv.GetStaticObjectField (class_ref, id_static_field_actionPushReceived);
				return JNIEnv.GetString(handle, JniHandleOwnership.TransferGlobalRef);
		
			}
		}
		
		// Yeah, been too lazy...
		
		public static String ActionNotificationOpened  {
			get {
				return String.Empty;
			}
		}
		
		public static String ActionRegistrationFinished  {
			get {
				return String.Empty;
			}
		}
		
		public static String ExtraAPID  {
			get {
				return String.Empty;
			}
		}
		public static String ExtraPushId  {
			get {
				return String.Empty;
			}
		}
		public static String ExtraRegistrationValid  {
			get {
				return String.Empty;
			}
		}
	}
}

