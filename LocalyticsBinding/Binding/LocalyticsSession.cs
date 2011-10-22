using System;
using Android.App;
using Android.Runtime;
using Android.Content;
using System.Collections.Generic;

namespace LocalyticsBinding.Binding
{
	/// <summary>
	/// Wrapper for LocalyticsSession.
	/// </summary>
	public class LocalyticsSession : Java.Lang.Object {
		
		/// <summary>
		/// IntPtr to class reference.
		/// </summary>
		internal static IntPtr class_ref = JNIEnv.FindClass ("com/localytics/android/LocalyticsSession");
		/// <summary>
		/// IntPtr to open method.
		/// </summary>
		internal static IntPtr id_open;
		/// <summary>
		/// IntPtr to close method.
		/// </summary>
		internal static IntPtr id_close;
		/// <summary>
		/// IntPtr to ctor.
		/// </summary>
		internal static IntPtr id_ctor;
		/// <summary>
		/// IntPtr to upload method.
		/// </summary>
		internal static IntPtr id_upload;
		/// <summary>
		/// IntPtr to setOptOut method.
		/// </summary>
		internal static IntPtr id_setOptOut;
		/// <summary>
		/// IntPtr to tagEvent(String event) method.
		/// </summary>
		internal static IntPtr id_tagEvent_Ljava_lang_String;
		/// <summary>
		/// IntPtr to tagScreen method.
		/// </summary>
		internal static IntPtr id_tagScreen_Ljava_lang_String;
		/// <summary>
		/// IntPtr to tagEvent(String event, Map attributes) method.
		/// </summary>
		internal static IntPtr id_tagEvent_Ljava_lang_StringLjava_util_Map;
		
		/// <summary>
		/// Is session enabled?
		/// </summary>
		public bool IsEnabled { get; set; }
		
		/// <summary>
		/// Constructs a new {@link LocalyticsSession} object.
		/// </summary>
		/// <param name="context">The context used to access resources on behalf of the app. It is recommended to use
        /// {@link Context#getApplicationContext()} to avoid the potential memory leak incurred by maintaining references to
        /// {@code Activity} instances. Cannot be null.</param>
		/// <param name="key">The key unique for each application generated at www.localytics.com. Cannot be null or empty.</param>
		public LocalyticsSession 
			(
				Context context,
				String key
			)
		{
			if (null == context)
				throw new ArgumentNullException("context");
				
			if (String.IsNullOrWhiteSpace(key))
				throw new ArgumentNullException("key");
			
			if (IntPtr.Zero.Equals(id_ctor))
			{
				id_ctor = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Ljava/lang/String;)V");
			}
			
			var keyIntPtr = JNIEnv.NewString(key);
			base.SetHandle (JNIEnv.NewObject (class_ref, id_ctor, new JValue[]{ new JValue(context), new JValue(keyIntPtr) }), true);
			JNIEnv.DeleteLocalRef(keyIntPtr);
			
			IsEnabled = true;
		
		}
		
		/// <summary>
        /// Opens the Localytics session. The session time as presented on the website is the time between the first <code>open</code>
        /// and the final <code>close</code> so it is recommended to open the session as early as possible, and close it at the last
        /// moment. The session must be opened before {@link #tagEvent(String)} or {@link #tagEvent(String, Map)} can be called, so
        /// this call should be placed in {@code Activity#onCreate(Bundle)}.
        /// <p>
        /// If for any reason this is called more than once without an intervening call to {@link #close()}, subsequent calls to open
        /// will be ignored.
        /// <p>
        /// For applications with multiple Activities, every Activity should call <code>open</code> in <code>onCreate</code>. This will
        /// cause each Activity to reconnect to the currently running session.
        /// </summary>
		public void Open(){
			
			if (!IsEnabled)
				return;
			
			if (id_open == IntPtr.Zero)
			{
				id_open = JNIEnv.GetMethodID (class_ref, "open", "()V");
			}
	
			JNIEnv.CallVoidMethod (base.Handle, id_open);
		}
		
        /// <summary>
        /// Closes the Localytics session. This should be done when the application or activity is ending. Because of the way the
        /// Android lifecycle works, this call could end up in a place which gets called multiple times (such as <code>onPause</code>
        /// which is the recommended location). This is fine because only the last close is processed by the server. <br>
        /// Closing does not cause the session to stop collecting data. This is a result of the application life cycle. It is possible
        /// for onPause to be called long before the application is actually ready to close the session.
        /// </summary>
		public void Close(){
			
			if (!IsEnabled)
				return;
			
			if (id_close == IntPtr.Zero)
			{
				id_close = JNIEnv.GetMethodID (class_ref, "close", "()V");
			}
	
			JNIEnv.CallVoidMethod (base.Handle, id_close);
		}
		
		/// <summary>
        /// Sets the Localytics opt-out state for this application. This call is not necessary and is provided for people who wish to
        /// allow their users the ability to opt out of data collection. It can be called at any time. Passing true causes all further
        /// data collection to stop, and an opt-out event to be sent to the server so the user's data is removed from the charts. <br>
        /// There are very serious implications to the quality of your data when providing an opt out option. For example, users who
        /// have opted out will appear as never returning, causing your new/returning chart to skew. <br>
        /// If two instances of the same application are running, and one is opted in and the second opts out, the first will also
        /// become opted out, and neither will collect any more data. <br>
        /// If a session was started while the app was opted out, the session open event has already been lost. For this reason, all
        /// sessions started while opted out will not collect data even after the user opts back in or else it taints the comparisons
        /// of session lengths and other metrics.
        /// </summary>
        /// <param name="isOptedOut">True if the user should be be opted out and have all his Localytics data deleted.</param>
		public void SetOptOut(bool isOptedOut)
		{
			if (!IsEnabled)
				return;
			
			if (id_setOptOut == IntPtr.Zero)
			{
				id_setOptOut = JNIEnv.GetMethodID (class_ref, "setOptOut", "(Z)V");
			}
	
			JNIEnv.CallVoidMethod (base.Handle, id_setOptOut, new JValue(isOptedOut));
		}
		
		/// <summary>
	    /// Initiates an upload of any Localytics data for this session's API key. This should be done early in the process life in
	    /// order to guarantee as much time as possible for slow connections to complete. It is necessary to do this even if the user
	    /// has opted out because this is how the opt out is transported to the webservice.
	    /// </summary>
		public void Upload(){
			
			if (!IsEnabled)
				return;
			
			if (id_upload == IntPtr.Zero)
			{
				id_upload = JNIEnv.GetMethodID (class_ref, "upload", "()V");
			}
	
			JNIEnv.CallVoidMethod (base.Handle, id_upload);
		}
		
		
		/// <summary>
        /// Allows a session to tag a particular event as having occurred. For example, if a view has three buttons, it might make
        /// sense to tag each button click with the name of the button which was clicked. For another example, in a game with many
        /// levels it might be valuable to create a new tag every time the user gets to a new level in order to determine how far the
        /// average user is progressing in the game. <br>
        /// <strong>Tagging Best Practices</strong>
        /// <ul>
        /// <li>DO NOT use tags to record personally identifiable information.</li>
        /// <li>The best way to use tags is to create all the tag strings as predefined constants and only use those. This is more
        /// efficient and removes the risk of collecting personal information.</li>
        /// <li>Do not set tags inside loops or any other place which gets called frequently. This can cause a lot of data to be stored
        /// and uploaded.</li>
        /// </ul>
        /// <br>
        /// </summary>
        /// <param name="event">The name of the event which occurred. Cannot be null or empty string.</param>
		public void TagEvent(String @event){
			
			if (!IsEnabled)
				return;
			
			if (String.IsNullOrWhiteSpace(@event))
				throw new ArgumentNullException("event");
			
			if (id_tagEvent_Ljava_lang_String == IntPtr.Zero)
			{
				id_tagEvent_Ljava_lang_String = JNIEnv.GetMethodID (class_ref, "tagEvent", "(Ljava/lang/String;)V");
			}
			
			var ptrEvent = JNIEnv.NewString(@event);
	
			JNIEnv.CallVoidMethod (base.Handle, id_tagEvent_Ljava_lang_String, new JValue(ptrEvent));
			
			JNIEnv.DeleteLocalRef(ptrEvent);
		}
		
        /// <summary>
        /// Allows a session to tag a particular event as having occurred, and optionally attach a collection of attributes to it. For
        /// example, if a view has three buttons, it might make sense to tag each button with the name of the button which was clicked.
        /// For another example, in a game with many levels it might be valuable to create a new tag every time the user gets to a new
        /// level in order to determine how far the average user is progressing in the game. <br>
        /// <strong>Tagging Best Practices</strong>
        /// <ul>
        /// <li>DO NOT use tags to record personally identifiable information.</li>
        /// <li>The best way to use tags is to create all the tag strings as predefined constants and only use those. This is more
        /// efficient and removes the risk of collecting personal information.</li>
        /// <li>Do not set tags inside loops or any other place which gets called frequently. This can cause a lot of data to be stored
        /// and uploaded.</li>
        /// </ul>
        /// <br>
        /// </summary>
        /// <param name="event">The name of the event which occurred.</param>
        /// <param name="attributes">The collection of attributes for this particular event. If this parameter is null or empty, then calling
        ///            this method has the same effect as calling {@link #tagEvent(String)}. This parameter may not contain null or
        ///            empty keys or values.
		public void TagEvent(String @event, IDictionary<String, String> attributes){
			
			if (!IsEnabled)
				return;
			
			if (String.IsNullOrWhiteSpace(@event))
				throw new ArgumentNullException("event");
			
			if (null == attributes)
				throw new ArgumentNullException("attributes");
			
			if (id_tagEvent_Ljava_lang_StringLjava_util_Map == IntPtr.Zero)
			{
				id_tagEvent_Ljava_lang_StringLjava_util_Map = JNIEnv.GetMethodID (class_ref, "tagEvent", "(Ljava/lang/String;Ljava/util/Map;)V");
			}
			
			var attributesJava = new JavaDictionary<String, String>(attributes);
			
			var ptrEvent = JNIEnv.NewString(@event);

			JNIEnv.CallVoidMethod (base.Handle, id_tagEvent_Ljava_lang_StringLjava_util_Map, new JValue(ptrEvent), new JValue(attributesJava));
			
			JNIEnv.DeleteLocalRef(ptrEvent);
		}
		
        /// <summary>
        /// Note: This implementation will perform duplicate suppression on two identical screen events that occur in a row within a
        /// single session. For example, in the set of screens {"Screen 1", "Screen 1"} the second screen would be suppressed. However
        /// in the set {"Screen 1", "Screen 2", "Screen 1"}, no duplicate suppression would occur.
        /// </summary>
        /// <param name="screen">Name of the screen that was entered. Cannot be null or the empty string.</param>
		public void TagScreen(String screen){
			
			if (!IsEnabled)
				return;
			
			if (String.IsNullOrWhiteSpace(@screen))
				throw new ArgumentNullException("screen");
			
			if (id_tagScreen_Ljava_lang_String == IntPtr.Zero)
			{
				id_tagScreen_Ljava_lang_String = JNIEnv.GetMethodID (class_ref, "tagScreen", "(Ljava/lang/String;)V");
			}
			
			var ptrEvent = JNIEnv.NewString(screen);
	
			JNIEnv.CallVoidMethod (base.Handle, id_tagScreen_Ljava_lang_String, new JValue(ptrEvent));
			
			JNIEnv.DeleteLocalRef(ptrEvent);
		}
		
        /// <summary>
        /// Tag screen using type of activity as name.
        /// </summary>
        /// <param name="activity">Activity which's type name to use for TagScreen.</param>
		public void TagScreen(Activity activity){
			if (!IsEnabled)
				return;
			if (null == activity)
				throw new ArgumentNullException("activity");
			
			var activityType = activity.GetType();
			var screen = activityType.Name;
			TagScreen(screen);
		}
	}
	

}

