using Plugin.MediaManager.Forms;

using Xamarin.Forms;

namespace MyMediaPlayer.Standard
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

			MainPage = new MyMediaPlayer.Standard.MainPage(videoUrl);
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
