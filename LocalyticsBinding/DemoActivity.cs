using System;
using System.Threading.Tasks;
using LocalyticsBinding.Binding;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace LocalyticsBinding
{
	[Activity (Label = "LocalyticsBinding", MainLauncher = true)]
	public class DemoActivity : Activity
	{
		
		private Button _button;
		
		// The used session factory.
		private LocalyticsSessionFactory _localyticsSessionFactory;
		
		// Localytics API Key for the app.
		private const String LOCALYTICS_API_KEY = "API_KEY_GOES_HERE";
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Create Localytics session factory.
			_localyticsSessionFactory = new LocalyticsSessionFactory(this, LOCALYTICS_API_KEY);
			
			// Get our button from the layout resource,
			// and attach an event to it
			_button = FindViewById<Button> (Resource.Id.myButton);
			
			_button.Click += OnDemoButtonClick;
		}
		
		private void TagTestEvent ()
		{
			var session = _localyticsSessionFactory.Create();
			session.Open();
			session.TagEvent("TestEvent");
			session.Upload();
			session.Close();
		}
		
		private void OnDemoButtonClick (object sender, EventArgs e)
		{
			new Task(() => TagTestEvent()).Start();
		}
	}
}


