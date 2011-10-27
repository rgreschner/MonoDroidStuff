using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace CustomViews
{
	[Activity (Label = "CustomViews", MainLauncher = true)]
	public class DemoActivity : Activity
	{
		/// <summary>
		/// Instance of our example view.
		/// </summary>
		ExampleView _exampleView;
		
		AlertDialog.Builder _alertDialogBuilder;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			
			_alertDialogBuilder = new AlertDialog.Builder(this);
			
			// Get example view from layout.
			_exampleView = FindViewById<ExampleView>(Resource.Id.myExampleView);
			
			// Assign handler for button click event.
			_exampleView.ButtonClick += OnExampleViewButtonClick;
		}
		
		/// <summary>
		/// Handler for example view button click event.
		/// </param>
		private void OnExampleViewButtonClick (object sender, EventArgs e)
		{
			var alertDialog = _alertDialogBuilder.Create();
			alertDialog.SetMessage("Hello!");
			alertDialog.Show();
		}
	}
}


