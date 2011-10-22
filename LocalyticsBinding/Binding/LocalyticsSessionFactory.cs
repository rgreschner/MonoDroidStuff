using System;
using Android.App;
using Android.Runtime;
using Android.Content;

namespace LocalyticsBinding.Binding
{
	/// <summary>
	/// Factory for LocalyticsSession objects.
	/// </summary>
	public class LocalyticsSessionFactory {
		
		/// <summary>
		/// Localytics API key for app.
		/// </summary>
		public String Key {get; set; }
		/// <summary>
		/// Context to use.
		/// </summary>
		public Context Context { get; set; }
		/// <summary>
		/// Create session objects in enabled state.
		/// </summary>
		public bool CreateEnabled { get; set; }
		
		/// <summary>
		/// Create LocalyticsSessionFactory.
		/// </summary>
		/// <param name="context">Context to use.</param>
		/// <param name="key">Localytics API key for app.</param>
		/// <param name="createEnabled">Create session objects in enabled state.</param>
		public LocalyticsSessionFactory (
				Context context,
				String key,
				bool createEnabled
			)
		{
			Context = context;
			Key = key;
			CreateEnabled = createEnabled;
		}
		
		/// <summary>
		/// Create LocalyticsSessionFactory.
		/// </summary>
		/// <param name="context">Context to use.</param>
		/// <param name="key">Localytics API key for app.</param>
		public LocalyticsSessionFactory (
				Context context, 
				String key
			)
			: this(context, key, true)
		{

		}
		
		/// <summary>
		/// Create LocalyticsSessionFactory.
		/// </summary>
		public LocalyticsSessionFactory() 
			: this(null, null, true)
		{
			
		}
		
		/// <summary>
		/// Create LocalyticsSession.
		/// </summary>
		/// <returns></returns>
		public LocalyticsSession Create()
		{
			var session = new LocalyticsSession(Context, Key);
			session.IsEnabled = CreateEnabled;
			return session;
		}
	}
}

