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
	/// TinyIoC singleton instance.
	/// </summary>
	public static class ContainerSingleton 
	{
		/// <summary>
		/// TinyIoC singleton instance.
		/// </summary>
		private static TinyIoCContainer _instance
			= new TinyIoCContainer();
		
		/// <summary>
		/// Public getter for TinyIoC singleton instance.
		/// </summary>
		public static TinyIoCContainer Instance
		{
			get
			{
				return _instance;
			}
		}
	}
}


