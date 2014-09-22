﻿using System;
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

            rData = new RadioData();
            radioTitles = rData.returnTitle();
            radioUris = rData.returnUrl();

            
            BackgroundAudioPlayer.Instance.PlayStateChanged += Instance_PlayStateChanged;

            if (BackgroundAudioPlayer.Instance.PlayerState == PlayState.Playing)
            {
                stationName.Text = radioTitles[index];
            }
        }

        void Instance_PlayStateChanged(object sender, EventArgs e)
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

                    break;

                case PlayState.Paused:
                    
                    this.UpdateState(null, null);
                    break;
                case PlayState.Stopped:
                    
                    this.UpdateState(null, null);
                    break;
                default:
                    break;
            }
        }

        private void UpdateState(object sender, EventArgs e)
        {
            // The code below changes the Song Name Track

            AudioTrack audioTrack = BackgroundAudioPlayer.Instance.Track;

            if (audioTrack != null)
            {
                stationName.Text = audioTrack.Title;
                artistName.Text = audioTrack.Artist;
            }

            if (BackgroundAudioPlayer.Instance.PlayerState == PlayState.BufferingStarted)
            {
                statusBox.Text = "Buffering";
            }
            else if (BackgroundAudioPlayer.Instance.PlayerState == PlayState.Playing)
            {
                statusBox.Text = "Playing";
            }
            else if (BackgroundAudioPlayer.Instance.PlayerState == PlayState.Stopped)
            {
                statusBox.Text = "Stopped";
            }
            else
            {
                statusBox.Text = "Unknown";
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
            rData = new RadioData();
            radioTitles = rData.returnTitle();
            radioUris = rData.returnUrl();
            if(BackgroundAudioPlayer.Instance.PlayerState == PlayState.Playing)
            {
                UpdateButtons(false, true);
            }
            else
            {
                UpdateButtons(true, false);
            }
            
            UpdateState(null, null);
        }

        private void playButtonTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            BackgroundAudioPlayer.Instance.Track = new AudioTrack(null, radioTitles[index], null, null, null, radioUris[index], EnabledPlayerControls.Pause);
            
            //Volume is by default set to the Maximum
            BackgroundAudioPlayer.Instance.Volume = 1.0d;
            UpdateState(null, null);
            UpdateButtons(false, true);
        }

        private void stopButtonTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
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
            
            BackgroundAudioPlayer.Instance.Track = new AudioTrack(null, radioTitles[index], null, null, null, radioUris[index], EnabledPlayerControls.Pause);
            BackgroundAudioPlayer.Instance.Volume = 1.0d;
            UpdateButtons(false, true);
            UpdateState(null, null);
        }

        //protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        //{
        //    if (BackgroundAudioPlayer.Instance.PlayerState == PlayState.Playing)
        //    {
        //        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        //        if (!settings.Contains("currentRadio"))
        //        {
        //            settings.Add("currentRadio", index);
        //        }
        //        else
        //        {
        //            settings["currentRadio"] = index;
        //        }
        //        settings.Save();
        //    }
        //}
    }
}