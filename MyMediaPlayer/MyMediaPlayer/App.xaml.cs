using Plugin.MediaManager.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyMediaPlayer
{
	public partial class App : Application
	{
		private App()
		{
			InitializeComponent();
		}

		public App(string videoUrl)
		{
			// Make sure it doesn't get stripped away by the linker
			var workaround = typeof(VideoView);
			InitializeComponent();

			MainPage = new MyMediaPlayer.MainPage(videoUrl);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
