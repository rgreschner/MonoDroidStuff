using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TinyIoCExample
{
	/// <summary>
	/// Controller (MVC) for DemoActivity.
	/// </summary>
	public class DemoActivityController 
	{
		/// <summary>
		/// Activity instance (view).
		/// </summary>
		private DemoActivity _activity;
		
		/// <summary>
		/// Count of button clicks (model).
		/// </summary>
		private int count = 1;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="DemoActivityController"/> class.
		/// </summary>
		/// <param name='activity'>
		/// Activity instance (view).
		/// </param>
		public DemoActivityController(DemoActivity activity)
		{
			#region Assign fields.
			_activity = activity;
			#endregion
		}
		
		/// <summary>
		/// Handler for button clicks on view.
		/// </summary>
		public void OnButtonClick(object sender, EventArgs e)
		{
			_activity.ButtonText = string.Format ("{0} clicks!", count++);
		}
	}
}


