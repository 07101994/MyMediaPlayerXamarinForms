using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Android.Content;
using Android.Content.Res;

namespace MyMediaPlayer.Droid
{
	[Activity(Label = "MyMediaPlayer", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	[IntentFilter(new[] { Intent.ActionView }, DataScheme = "rtsp", DataHost = "*", Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable }, Icon = "@drawable/icon")]
	[IntentFilter(new[] { Intent.ActionView }, DataMimeTypes = new string[] { "video/*", "application/sdp" }, Categories = new[] { Intent.CategoryDefault }, Icon = "@drawable/icon")]
	[IntentFilter(new[] { Intent.ActionView }, DataScheme = "http", DataMimeTypes = new string[] { "video/*" }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable }, Icon = "@drawable/icon")]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
			TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
			AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironmentOnUnhandledException;

			global::Xamarin.Forms.Forms.Init(this, bundle);
			Plugin.MediaManager.Forms.Android.VideoViewRenderer.Init();

			string videoPath = GetVideoUrl();
			LoadApplication(new App(videoPath));
		}

		private void AndroidEnvironmentOnUnhandledException(object sender, RaiseThrowableEventArgs e)
		{
			e.Handled = true;
			throw new NotImplementedException();
		}

		private void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			throw new NotImplementedException();
		}

		private string GetVideoUrl()
		{
			string videoPath = null;
			if (string.IsNullOrWhiteSpace(Intent.DataString))
			{
				videoPath = "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4";
			}
			else
			{
				videoPath = Intent.DataString;
			}
			Toast.MakeText(this, videoPath, ToastLength.Long).Show();

			return videoPath;
		}
	}
}

