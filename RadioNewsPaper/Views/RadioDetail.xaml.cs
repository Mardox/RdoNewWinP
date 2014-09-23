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
using System.IO.IsolatedStorage;
using System.Windows.Threading;
using System.Diagnostics;
using GoogleAds;

namespace RadioNewsPaper.Views
{
    public partial class RadioDetail : PhoneApplicationPage
    {
        public string[] radioTitles;
        public string[] radioUris;
        RadioData rData;
        int index;
        private InterstitialAd interstitialAd;

        //constructor
        public RadioDetail()
        {
            InitializeComponent();

            rData = new RadioData();
            radioTitles = rData.returnTitle();
            radioUris = rData.returnUrl();

            Loaded += RadioDetail_Loaded;
            interstitialAd = new InterstitialAd(rData.detailInterstitial);
            AdRequest adRequest = new AdRequest();

            interstitialAd.ReceivedAd += OnAdReceived;
            interstitialAd.DismissingOverlay += interstitialAd_DismissingOverlay;
            interstitialAd.LoadAd(adRequest);

            AdView bannerAd = new AdView
            {
                Format = AdFormats.Banner,
                AdUnitID = rData.adBanner
            };
            AdRequest BanneradRequest = new AdRequest();
            // Assumes we've defined a Grid that has a name
            // directive of ContentPanel.
            mainPanel.Children.Add(bannerAd);
            bannerAd.VerticalAlignment = VerticalAlignment.Bottom;
            bannerAd.LoadAd(BanneradRequest);
        }

        void interstitialAd_DismissingOverlay(object sender, AdEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OnAdReceived(object sender, AdEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ad received successfully");
        }

        private DispatcherTimer timer;
        void RadioDetail_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize a timer to update the UI every half-second.
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromSeconds(0.5);
            this.timer.Tick += new EventHandler(this.UpdateState);

            // Changing the Instance State of the BackgroundAudioPlayer

            BackgroundAudioPlayer.Instance.PlayStateChanged += new EventHandler(this.Instance_PlayStateChanged);

            if (BackgroundAudioPlayer.Instance.PlayerState == PlayState.Playing)
            {
                this.UpdateButtons(false, true);
                this.UpdateState(null, null);

            }
        }

        private void Instance_PlayStateChanged(object sender, EventArgs e)
        {
            PlayState playState = PlayState.Unknown;
            try
            {
                playState = BackgroundAudioPlayer.Instance.PlayerState;
            }
            catch (InvalidOperationException)
            {
                playState = PlayState.Stopped;
            }

            switch (playState)
            {
                case PlayState.Playing:
                    this.UpdateState(null, null);
                    UpdateButtons(false, true);
                    this.timer.Start();
                    break;

                case PlayState.Paused:
                    this.timer.Stop();
                    this.UpdateState(null, null);
                    break;
                case PlayState.Stopped:
                    this.timer.Stop();
                    UpdateButtons(true, false);
                    this.UpdateState(null, null);
                    break;
                default:
                    break;
            }
        }

        private void UpdateState(object sender, EventArgs e)
        {
            // The code below changes the Song Name Track
            statusBox.Text = BackgroundAudioPlayer.Instance.PlayerState.ToString();

            AudioTrack audioTrack = BackgroundAudioPlayer.Instance.Track;
            if (audioTrack != null)
            {
                stationName.Text = audioTrack.Title;
                artistName.Text = audioTrack.Artist;
                bufferingProgress.IsIndeterminate = false;
            }
        }

        private void UpdateButtons(bool playButton, bool stopButton)
        {
            if (playButton)
            {
                play.Visibility = Visibility.Visible;
                stop.Visibility = Visibility.Collapsed;
            }
            else if (stopButton)
            {
                stop.Visibility = Visibility.Visible;
                play.Visibility = Visibility.Collapsed;
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string temp = "";

            if (NavigationContext.QueryString.TryGetValue("index", out temp))
            {
                index = Convert.ToInt32(temp);
            }
            if(BackgroundAudioPlayer.Instance.PlayerState != PlayState.Playing)
            {
                Play();
            }
        }

        private void playButtonTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Play();
        }

        private void stopButtonTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.timer.Stop();
            BackgroundAudioPlayer.Instance.Stop();
            UpdateButtons(true, false);
            UpdateState(null, null);
        }

        private void nextButtonTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BackgroundAudioPlayer.Instance.Stop();
            UpdateButtons(true, false);
            UpdateState(null, null);
            if(index == radioUris.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
            bufferingProgress.IsIndeterminate = true;
            BackgroundAudioPlayer.Instance.Track = new AudioTrack(null, radioTitles[index], null, null, null, radioUris[index], EnabledPlayerControls.Pause);
            BackgroundAudioPlayer.Instance.Volume = 1.0d;
            UpdateButtons(false, true);
            UpdateState(null, null);
        }

        private void backButtonTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BackgroundAudioPlayer.Instance.Stop();
            UpdateButtons(true, false);
            UpdateState(null, null);
            if (index == 0)
            {
                index = radioUris.Length - 1;
            }
            else
            {
                index--;
            }
            bufferingProgress.IsIndeterminate = true;
            BackgroundAudioPlayer.Instance.Track = new AudioTrack(null, radioTitles[index], null, null, null, radioUris[index], EnabledPlayerControls.Pause);
            BackgroundAudioPlayer.Instance.Volume = 1.0d;
            UpdateButtons(false, true);
            UpdateState(null, null);
        }

        void Play()
        {
            bufferingProgress.IsIndeterminate = true;
            BackgroundAudioPlayer.Instance.Track = new AudioTrack(null, radioTitles[index], null, null, null, radioUris[index], EnabledPlayerControls.Pause);
            //Volume is by default set to the Maximum
            BackgroundAudioPlayer.Instance.Volume = 1.0d;
            UpdateButtons(false, true);
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                int count = 1;
                IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
                if (!settings.Contains("radioBackCount"))
                {
                    settings.Add("radioBackCount", 1);
                }
                else
                {
                    count = (int)IsolatedStorageSettings.ApplicationSettings["radioBackCount"];
                    settings["radioBackCount"] = count + 1;
                }
                settings.Save();
                if (count % 3 == 0)
                {
                    interstitialAd.ShowAd();
                }
            }
            catch (Exception ex)
            {
                NavigationService.GoBack();
            }
        }
    }
}