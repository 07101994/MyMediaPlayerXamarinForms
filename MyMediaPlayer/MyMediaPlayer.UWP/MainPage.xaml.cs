using Plugin.MediaManager.Forms.UWP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MyMediaPlayer.UWP
{
	public sealed partial class MainPage
	{
		public MainPage()
		{
			this.InitializeComponent();
			//VideoViewRenderer.Init();
			//C:\\Users\\Tushar\\Videos\\intro_lesson_1.Introduction.mp4
			LoadApplication(new MyMediaPlayer.App("http://techslides.com/demos/sample-videos/small.mp4"));
		}
	}
}
