using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace CustomViews
{
	public class ExampleView : LinearLayout
	{
		/// <summary>
		/// Button part of view.
		/// </summary>
		Button _button;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomViews.ExampleView"/> class.
		/// </summary>
		/// <param name='context'>
		/// Context.
		/// </param>
		/// <param name='attrs'>
		/// (Optionally) Attribute set.
		/// </param>
		// Attribute set parameter is needed when
		// using custom views in AXML.
		public ExampleView (Context context, IAttributeSet attrs = null) :
			base (context, attrs)
		{
			Initialize ();
		}
		

		/// <summary>
		/// Initialize the custom view
		/// </summary>
		private void Initialize ()
		{
			Orientation = Orientation.Vertical;
			
			var layoutInflater = Context.GetLayoutInflater();
			layoutInflater.Inflate(Resource.Layout.ExampleView,this);
			_button = FindViewById<Button>(Resource.Id.myButton);
		}
		
		/// <summary>
		/// Occurs when view's button was clicked.
		/// </summary>
		public event EventHandler ButtonClick {
			add {
				_button.Click += value;
			}
			remove {
				_button.Click -= value;
			}
		}
	}
}

