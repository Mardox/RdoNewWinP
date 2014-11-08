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
using Coding4Fun.Toolkit.Audio;
using Coding4Fun.Toolkit.Audio.Helpers;
using System.IO;
using RadioNewsPaper.ViewModels;
using System.Collections.ObjectModel;
using Coding4Fun.Toolkit.Controls;
using Newtonsoft.Json;

namespace RadioNewsPaper.Views
{
    public partial class RadioDetail : PhoneApplicationPage
    {
        public string[] radioTitles;
        public string[] radioUris;
        RadioData rData;
        int index, forewardCount = 1;
        private InterstitialAd interstitialAd, interstitialAd2;

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

            //Interstitial two
            interstitialAd2 = new InterstitialAd(rData.detailInterstitial);
            AdRequest adRequest2 = new AdRequest();

            interstitialAd2.ReceivedAd += OnAdReceived2;
            interstitialAd2.DismissingOverlay += interstitialAd_DismissingOverlay2;
            interstitialAd2.LoadAd(adRequest2);

            AdView bannerAd = new AdView
            {
                Format = AdFormats.Banner,
                AdUnitID = rData.adBanner
            };
            AdRequest BanneradRequest = new AdRequest();
            // Assumes we've defined a Grid that has a name
            // directive of ContentPanel.
            adPanel.Children.Add(bannerAd);
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

        private void interstitialAd_DismissingOverlay2(object sender, AdEventArgs e)
        {
            //Do nothing
        }

        private void OnAdReceived2(object sender, AdEventArgs e)
        {
            Debug.WriteLine("Received second ad");
            if (RandomNumber() == 0)
            {
                interstitialAd2.ShowAd();
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
                    statusBox.Text = BackgroundAudioPlayer.Instance.PlayerState.ToString();
                    break;

                case PlayState.Paused:
                    this.timer.Stop();
                    this.UpdateState(null, null);
                    statusBox.Text = BackgroundAudioPlayer.Instance.PlayerState.ToString();
                    break;
                case PlayState.Stopped:
                    this.timer.Stop();
                    UpdateButtons(true, false);
                    this.UpdateState(null, null);
                    statusBox.Text = BackgroundAudioPlayer.Instance.PlayerState.ToString();
                    break;
                case PlayState.BufferingStarted:
                    statusBox.Text = BackgroundAudioPlayer.Instance.PlayerState.ToString();
                    break;
                default:
                    break;
            }
        }

        private void UpdateState(object sender, EventArgs e)
        {
            // The code below changes the Song Name Track
            //statusBox.Text = BackgroundAudioPlayer.Instance.PlayerState.ToString();
            try
            {
                AudioTrack audioTrack = BackgroundAudioPlayer.Instance.Track;
                if (audioTrack != null)
                {
                    stationName.Text = audioTrack.Title;
                    artistName.Text = audioTrack.Artist;
                    bufferingProgress.IsIndeterminate = false;
                }
                else
                {
                    statusBox.Text = "Buffering";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
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
            else if (NavigationContext.QueryString.TryGetValue("favIndex", out temp))
            {
                int tempIndex = Convert.ToInt32(temp);
                var element = App.ViewModel.FavItems.ElementAt(tempIndex);
                index = element.FavIndex;
            }
            try
            {
                int prevIndex = (int)IsolatedStorageSettings.ApplicationSettings["prevIndex"];
                if (index != prevIndex)
                {
                    Play();
                }
                else
                {
                    if (BackgroundAudioPlayer.Instance.PlayerState != PlayState.Playing)
                    {
                        Play();
                    }
                }

                //if(BackgroundAudioPlayer.Instance.PlayerState != PlayState.Playing)
                if ((bool)IsolatedStorageSettings.ApplicationSettings["isPLaying"] == false)
                {
                    Play();
                }
            }
            catch (KeyNotFoundException)
            {
                Play();
                Debug.WriteLine("first time to radio detail page");
            }

        }

        private void playButtonTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Play();
        }

        private void stopButtonTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            IsolatedStorageSettings.ApplicationSettings["isPLaying"] = false;
            IsolatedStorageSettings.ApplicationSettings.Save();
            this.timer.Stop();
            try
            {
                BackgroundAudioPlayer.Instance.Stop();
            }
            catch (Exception)
            {
                UpdateButtons(true, false);
            }

            UpdateButtons(true, false);
            UpdateState(null, null);
        }

        void Play()
        {
            bufferingProgress.IsIndeterminate = true;
            BackgroundAudioPlayer.Instance.Track = new AudioTrack(null, radioTitles[index], null, null, null, radioUris[index], EnabledPlayerControls.Pause);
            //Volume is by default set to the Maximum
            BackgroundAudioPlayer.Instance.Volume = 1.0d;
            IsolatedStorageSettings.ApplicationSettings["isPLaying"] = true;
            IsolatedStorageSettings.ApplicationSettings.Save();
            //UpdateButtons(false, true);
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            IsolatedStorageSettings.ApplicationSettings["prevIndex"] = index;
            IsolatedStorageSettings.ApplicationSettings.Save();
            if (RandomNumber() == 0)
            {
                interstitialAd.ShowAd();
            }
            else
            {
                NavigationService.GoBack();
            }
        }

        #region Recording section
        private MicrophoneRecorder _recorder = new MicrophoneRecorder();
        private IsolatedStorageFileStream _audioStream;
        private string _tempFileName = "tempWav.wav";

        private void startClick(object sender, RoutedEventArgs e)
        {
            playButton.IsEnabled = false;
            saveButton.IsEnabled = false;
            recordButton.Content = "Stop";
            RotateCircle.Begin();
            _recorder.Start();
        }

        private void SaveTempAudio(MemoryStream buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException("Attempting to save an empty audio file");

            //Clean media element hold on audioStream
            if (_audioStream != null)
            {
                playAudio.Stop();
                playAudio.Source = null;

                _audioStream.Dispose();
            }

            var bytes = buffer.GetWavAsByteArray(_recorder.SampleRate);

            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isoStore.FileExists(_tempFileName))
                {
                    isoStore.DeleteFile(_tempFileName);
                }
                _tempFileName = string.Format("{0}.wav", DateTime.Now.ToFileTime());
                _audioStream = isoStore.CreateFile(_tempFileName);
                _audioStream.Write(bytes, 0, bytes.Length);

                //Play
                playAudio.SetSource(_audioStream);


            }
        }

        private void playClick(object sender, RoutedEventArgs e)
        {
            BackgroundAudioPlayer.Instance.Close();
            stop.Visibility = Visibility.Collapsed;
            play.Visibility = Visibility.Visible;
            playAudio.Play();
        }

        private void stopClick(object sender, RoutedEventArgs e)
        {
            RotateCircle.Stop();
            playButton.IsEnabled = true;
            saveButton.IsEnabled = true;
            recordButton.Content = "Record";
            _recorder.Stop();
            SaveTempAudio(_recorder.Buffer);

        }

        private void closeGridTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            recordPopUp.IsOpen = false;
        }

        #endregion

        private void toggleFavorite_Click(object sender, EventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            if (!settings.Contains("favData"))
            {
                settings.Add("favData", radioTitles[index] + ",");
            }
            else
            {
                if (!settings["favData"].ToString().Contains(radioTitles[index]))
                {
                    settings["favData"] += radioTitles[index] + ",";
                    MessageBox.Show("This station is added as favorite. To remove click on favorite button again.");
                }
                else if (settings["favData"].ToString().Contains(radioTitles[index]))
                {
                    string tempSetting = settings["favData"] as string;
                    tempSetting = tempSetting.Replace(radioTitles[index] + ",", "");
                    settings["favData"] = tempSetting;
                    MessageBox.Show("This station is removed from favorites.");
                }

            }
            settings.Save();


        }

        private void recordButtonClick(object sender, EventArgs e)
        {
            recordPopUp.IsOpen = true;
        }

        private void saveClick(object sender, RoutedEventArgs e)
        {
            InputPrompt fileName = new InputPrompt();

            fileName.Title = "Sound name";
            fileName.Message = "What should be the file name";

            fileName.Completed += fileName_Completed;
            fileName.Show();
        }

        private void fileName_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
        {
            if (e.PopUpResult == PopUpResult.Ok)
            {
                if (e.Result != null)
                {
                    RecordingsViewModel rvm = new RecordingsViewModel();
                    rvm.RecTitle = e.Result;
                    rvm.RecPath = string.Format("/recordAudio/{0}.wav", DateTime.Now.ToFileTime());
                    rvm.RecTime = DateTime.Now.ToShortDateString();

                    using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        if (!isoStore.DirectoryExists("/recordAudio/"))
                            isoStore.CreateDirectory("/recordAudio/");
                        isoStore.MoveFile(_tempFileName, rvm.RecPath);
                    }

                    App.ViewModel.RecItems.Add(rvm);

                    var data = JsonConvert.SerializeObject(App.ViewModel.RecItems);

                    IsolatedStorageSettings.ApplicationSettings[App.CustomSoundKey] = data;
                    IsolatedStorageSettings.ApplicationSettings.Save();
                }
            }

            recordPopUp.IsOpen = false;
        }

        private int RandomNumber()
        {
            Random random = new Random();
            return random.Next(0, 1);
        }
    }
}