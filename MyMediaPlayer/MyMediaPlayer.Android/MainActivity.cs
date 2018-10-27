using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using MyMediaPlayer.Standard;
using System;
using System.Threading.Tasks;

namespace MyMediaPlayer.Droid
{
	[Activity(Label = "MyMediaPlayer", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Landscape, ClearTaskOnLaunch = true, LaunchMode = LaunchMode.SingleInstance)]
	[IntentFilter(new[] { Intent.ActionView }, DataScheme = "rtsp", DataHost = "*", Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable }, Icon = "@drawable/icon")]
	[IntentFilter(new[] { Intent.ActionView }, DataMimeTypes = new string[] { "video/*", "application/sdp" }, Categories = new[] { Intent.CategoryDefault }, Icon = "@drawable/icon")]
	[IntentFilter(new[] { Intent.ActionView }, DataScheme = "http", DataMimeTypes = new string[] { "video/*" }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable }, Icon = "@drawable/icon")]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		//private IMediaManager mediaManager;

		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
			TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
			AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironmentOnUnhandledException;

			Plugin.MediaManager.Forms.Android.VideoViewRenderer.Init();
			global::Xamarin.Forms.Forms.Init(this, bundle);

			//mediaManager = CrossMediaManager.Current;

			//((MediaManagerImplementation)CrossMediaManager.Current).MediaSessionManager = new MediaSessionManager(Application.Context, typeof(ExoPlayerAudioService), CrossMediaManager.Current);
			//var exoPlayer = new ExoPlayerAudioImplementation(((MediaManagerImplementation)CrossMediaManager.Current).MediaSessionManager);
			//CrossMediaManager.Current.AudioPlayer = exoPlayer;

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
				videoPath = "http://techslides.com/demos/sample-videos/small.mp4";
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

