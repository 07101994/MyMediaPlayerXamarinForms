using System.IO;

namespace MyMediaPlayer.UWP
{
	public sealed partial class MainPage
	{
		private string mPath = "C:\\Users\\Tushar\\Videos\\intro_lesson_1.Introduction.mp4";

		public MainPage()
		{
			this.InitializeComponent();
			
			//if (File.Exists(mPath))
			//{
				LoadApplication(new MyMediaPlayer.App(mPath));
			//}
		}

		private bool FileExists()
		{
			return File.Exists(mPath);
		}
	}
}
