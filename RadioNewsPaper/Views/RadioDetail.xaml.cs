using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using RadioNewsPaper.Data;
using Microsoft.Phone.BackgroundAudio;

namespace RadioNewsPaper.Views
{
    public partial class RadioDetail : PhoneApplicationPage
    {
        public int NowPlaying;
        public string[] radioTitles;
        public string[] radioUris;
        RadioData rData;
        int index;
        public RadioDetail()
        {
            InitializeComponent();
            Loaded += RadioDetail_Loaded;
        }

        void RadioDetail_Loaded(object sender, RoutedEventArgs e)
        {
            //pageName.Text = "Title";
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string temp = "";

            if (NavigationContext.QueryString.TryGetValue("index", out temp))
            {
                index = Convert.ToInt32(temp);
            }
            rData = new RadioData();
            radioTitles = rData.returnTitle();
            radioUris = rData.returnUrl();
            pageName.Text = radioTitles[index];
        }

        private void playButtonTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BackgroundAudioPlayer.Instance.Track = new AudioTrack(null, radioTitles[index], null, null, null, radioUris[index], EnabledPlayerControls.Pause);
            statusBox.Text = "Playing";
            //Volume is by default set to the Maximum
            BackgroundAudioPlayer.Instance.Volume = 1.0d;

            play.Visibility = Visibility.Collapsed;
            stop.Visibility = Visibility.Visible;
        }

        private void stopButtonTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BackgroundAudioPlayer.Instance.Stop();
            statusBox.Text = "Stopped";
            play.Visibility = Visibility.Visible;
            stop.Visibility = Visibility.Collapsed;
        }

        private void nextButtonTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BackgroundAudioPlayer.Instance.Stop();
            if(index == radioUris.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
            pageName.Text = radioTitles[index];
            BackgroundAudioPlayer.Instance.Track = new AudioTrack(null, radioTitles[index], null, null, null, radioUris[index], EnabledPlayerControls.Pause);
            BackgroundAudioPlayer.Instance.Volume = 1.0d;
        }

        private void backButtonTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BackgroundAudioPlayer.Instance.Stop();
            if (index == 0)
            {
                index = radioUris.Length - 1;
            }
            else
            {
                index--;
            }
            pageName.Text = radioTitles[index];
            BackgroundAudioPlayer.Instance.Track = new AudioTrack(null, radioTitles[index], null, null, null, radioUris[index], EnabledPlayerControls.Pause);
            BackgroundAudioPlayer.Instance.Volume = 1.0d;
        }
    }
}