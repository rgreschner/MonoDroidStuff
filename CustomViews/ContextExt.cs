using System;
using Android.Content;
using Android.Views;

namespace CustomViews
{
	/// <summary>
	/// Extension methods for Context class.
	/// </summary>
	public static class ContextExt
	{
		/// <summary>
		/// Gets a layout inflater from context.
		/// </summary>
		/// <returns>
		/// Layout inflater instance.
		/// </returns>
		/// <param name='self'>
		/// This context.
		/// </param>
		public static LayoutInflater GetLayoutInflater(this Context self)
		{
			var layoutInflater = self.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
			return layoutInflater;
		}
	}
}

