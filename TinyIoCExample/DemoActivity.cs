using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TinyIoC;

namespace TinyIoCExample
{
	/// <summary>
	/// Demo activity for TinyIoC example.
	/// </summary>
	[Activity (Label = "TinyIoCExample", MainLauncher = true)]
	public class DemoActivity : Activity
	{
		/// <summary>
		/// TinyIoC container instance.
		/// </summary>
		private TinyIoCContainer _container = ContainerSingleton.Instance;
		/// <summary>
		/// Button invoking action on controller.
		/// </summary>
		private Button _button;
		/// <summary>
		/// Is container initialized?
		/// </summary>
		private bool _containerInitialized;
		/// <summary>
		/// Controller for DemoActivity.
		/// </summary>
		private DemoActivityController _controller;
		
		/// <summary>
		/// Create new activity instance.
		/// </summary>
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			
			InitializeContainerIfNecessary();
			
			var npo = new NamedParameterOverloads();
			npo.Add("activity", this);
			_controller = _container.Resolve<DemoActivityController>(npo);
			
			// Get our button from the layout resource,
			// and attach an event to it
			_button = FindViewById<Button> (Resource.Id.myButton);
			_button.Click += _controller.OnButtonClick;
		}
		
		/// <summary>
		/// Initializes TinyIoC container if necessary.
		/// </summary>
		private void InitializeContainerIfNecessary ()
		{
			if (_containerInitialized){
				// Already initialized, exit.
				return;
			}
			
			// Register bindings on container.
			_container.Register<DemoActivityController>();
			
			_containerInitialized = true;
		}
		
		/// <summary>
		/// Gets or sets the button text.
		/// </summary>
		/// <value>
		/// The button text.
		/// </value>
		public String ButtonText 
		{
			get
			{
				return _button.Text;
			}
			set
			{
				_button.Text = value;
			}
		}

		
	}
	

	

}


