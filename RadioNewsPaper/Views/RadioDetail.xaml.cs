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
//using Coding4Fun.Toolkit.Audio;
//using Coding4Fun.Toolkit.Audio.Helpers;
using System.IO;
using RadioNewsPaper.ViewModels;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Parse;

namespace RadioNewsPaper.Views
{
    public partial class RadioDetail : PhoneApplicationPage
    {

        List<ParseObject> radioStations = new List<ParseObject>();

        ParseObject currentStation;

        int index;
        private InterstitialAd interstitialAd, interstitialAd2;


          // Timer for updating the UI

        // Indexes into the array of ApplicationBar.Buttons
        //const int PrevButtonIndex = 0;
        const int PlayButtonIndex = 0;
        const int PauseButtonIndex = 1;
        //const int NextButtonIndex = 3;
        //readonly ApplicationBarIconButton _nextButton;
        readonly ApplicationBarIconButton _pauseButton;
        readonly ApplicationBarIconButton _playButton;
        //readonly ApplicationBarIconButton _prevButton;
        DispatcherTimer _timer;

        public RadioDetail()
        {
            InitializeComponent();

            GoogleAnalytics.EasyTracker.GetTracker().SendView("RadioPlayer");

            
            
            radioStations = DataCenter.returnStations();

            //_prevButton = ((ApplicationBarIconButton)(ApplicationBar.Buttons[PrevButtonIndex]));
            _pauseButton = ((ApplicationBarIconButton)(ApplicationBar.Buttons[PauseButtonIndex]));
            _playButton = ((ApplicationBarIconButton)(ApplicationBar.Buttons[PlayButtonIndex]));
            //_nextButton = ((ApplicationBarIconButton)(ApplicationBar.Buttons[NextButtonIndex]));


            interstitialAd = new InterstitialAd(DataCenter.detailInterstitial);
            AdRequest adRequest = new AdRequest();

            interstitialAd.ReceivedAd += OnAdReceived;
            interstitialAd.DismissingOverlay += interstitialAd_DismissingOverlay;
            interstitialAd.LoadAd(adRequest);

            //Interstitial two
            //interstitialAd2 = new InterstitialAd(RadioData.detailInterstitial);
            //AdRequest adRequest2 = new AdRequest();

            //interstitialAd2.ReceivedAd += OnAdReceived2;
            //interstitialAd2.DismissingOverlay += interstitialAd_DismissingOverlay2;
            //interstitialAd2.LoadAd(adRequest2);
            AdMediator_Radio_Detail.AdSdkError += AdMediator_Bottom_AdError;
            AdMediator_Radio_Detail.AdMediatorFilled += AdMediator_Bottom_AdFilled;
            AdMediator_Radio_Detail.AdMediatorError += AdMediator_Bottom_AdMediatorError;
            AdMediator_Radio_Detail.AdSdkEvent += AdMediator_Bottom_AdSdkEvent;

        }


        void AdMediator_Bottom_AdSdkEvent(object sender, Microsoft.AdMediator.Core.Events.AdSdkEventArgs e)
        {
            Debug.WriteLine("AdSdk event {0} by {1}", e.EventName, e.Name);
            GoogleAnalytics.EasyTracker.GetTracker().SendEvent("ui_action", "tap", e.EventName, 0);
        }

        void AdMediator_Bottom_AdMediatorError(object sender, Microsoft.AdMediator.Core.Events.AdMediatorFailedEventArgs e)
        {
            Debug.WriteLine("AdMediatorError:" + e.Error + " " + e.ErrorCode);
            // if (e.ErrorCode == AdMediatorErrorCode.NoAdAvailable)
            // AdMediator will not show an ad for this mediation cycle
        }

        void AdMediator_Bottom_AdFilled(object sender, Microsoft.AdMediator.Core.Events.AdSdkEventArgs e)
        {
            Debug.WriteLine("AdFilled:" + e.Name);
        }

        void AdMediator_Bottom_AdError(object sender, Microsoft.AdMediator.Core.Events.AdFailedEventArgs e)
        {
            Debug.WriteLine("AdSdkError by {0} ErrorCode: {1} ErrorDescription: {2} Error: {3}", e.Name, e.ErrorCode, e.ErrorDescription, e.Error);
        }

        void RadioDetail_OnLoaded(object sender, RoutedEventArgs e)
        {
            // Initialize a timer to update the UI every half-second.
            _timer = new DispatcherTimer
                     {
                         Interval = TimeSpan.FromSeconds(0.5)
                     };

            _timer.Tick += UpdateState;

            var player = BackgroundAudioPlayer.Instance;

            player.PlayStateChanged += Instance_PlayStateChanged;

            PlayTrack(player);

        }


        void interstitialAd_DismissingOverlay(object sender, AdEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OnAdReceived(object sender, AdEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ad received successfully");
        }


        private void interstitialAd_DismissingOverlay2(object sender, AdEventArgs e)
        {
            //Do nothing
        }

        private void OnAdReceived2(object sender, AdEventArgs e)
        {
            Debug.WriteLine("Received second ad");
            if (DataCenter.showAds())
            {
                interstitialAd2.ShowAd();
            }
        }

        /// <summary>
        ///     PlayStateChanged event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Instance_PlayStateChanged(object sender, EventArgs e)
        {

            var player = BackgroundAudioPlayer.Instance;
            
            Debug.WriteLine("Hooman Player track.Source {0} track.Tag {1} playState {2}",
                null == player.Track ? "<no track>" : null == player.Track.Source ? "<none>" : player.Track.Source.ToString(),
                null == player.Track ? "<no track>" : player.Track.Tag ?? "<none>", player.PlayerState);

            switch (player.PlayerState)
            {
                case PlayState.Playing:
                    // Update the UI.
                    {
                        var track = BackgroundAudioPlayer.Instance.Track;

                        if (null != track)
                        {
                            var duration = track.Duration;

                            if (duration > TimeSpan.Zero)
                            {
                                positionIndicator.IsIndeterminate = false;
                                positionIndicator.Maximum = duration.TotalSeconds;
                            }
                        }
                    }

                    _playButton.IsEnabled = false;
                    _pauseButton.IsEnabled = true;
                    bufferingProgress.Visibility = Visibility.Collapsed;
                    warning.Visibility = Visibility.Collapsed;

                    UpdateState(null, null);

                    // Start the timer for updating the UI.
                    _timer.Start();

                    GoogleAnalytics.EasyTracker.GetTracker().SendEvent("app_action", "playing_radio", currentStation["name"].ToString(), 0);

                    break;
                case PlayState.Stopped:
                case PlayState.BufferingStarted:
                    _playButton.IsEnabled = false;
                    bufferingProgress.Visibility = Visibility.Visible;
                    GoogleAnalytics.EasyTracker.GetTracker().SendEvent("app_action", "buffering_radio", currentStation["name"].ToString(), 0);
                    break;
                case PlayState.Paused:
                    // Update the UI.

                    _playButton.IsEnabled = true;
                    _pauseButton.IsEnabled = false;

                    UpdateState(null, null);

                    // Stop the timer for updating the UI.
                    _timer.Stop();

                    break;
                case PlayState.Unknown:
                    _playButton.IsEnabled = false;
                    _pauseButton.IsEnabled = true;

                    UpdateState(null, null);

                    break;
            }

            //_nextButton.IsEnabled = true;
            //_prevButton.IsEnabled = true;
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {


            base.OnNavigatedTo(e);

            string temp = "";

            if (NavigationContext.QueryString.TryGetValue("index", out temp))
            {
                index = Convert.ToInt32(temp);
                currentStation = radioStations[index];
                GoogleAnalytics.EasyTracker.GetTracker().SendEvent("app_action", "loading_radio", currentStation["name"].ToString(), 0);
                
                
            }
            else if (NavigationContext.QueryString.TryGetValue("favIndex", out temp))
            {
                int tempIndex = Convert.ToInt32(temp);
                var element = App.ViewModel.FavItems.ElementAt(tempIndex);
                index = element.FavIndex;
                currentStation = radioStations[index];
            }
            else
            {
                bufferingProgress.Visibility = Visibility.Collapsed;
                warning.Visibility = Visibility.Collapsed;
            }

            
           
            //playButton_Click(null, null);

        }


        private void PlayTrack(BackgroundAudioPlayer player)
        {
            if ((player.Track == null) || (player.Track.Title != currentStation["name"].ToString()))
            {
                // If it's a new track, set the track
                player.Track = new AudioTrack(null, currentStation["name"].ToString(), null, null, null,
                    currentStation["data"].ToString(),
                    EnabledPlayerControls.All);
            }

            // Play it
            if ((player.Track != null) && (player.PlayerState != PlayState.Playing))
            {
                player.Play();
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {

            if (DataCenter.showAds() && interstitialAd != null)
            {
                interstitialAd.ShowAd();
            }
            else
            {
                NavigationService.GoBack();
            }
        }


        /// <summary>
        ///     Updates the status indicators including the State, Track title,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UpdateState(object sender, EventArgs e)
        {
            try
            {
                var player = BackgroundAudioPlayer.Instance;

                if (null == player)
                    return;

                txtState.Text = string.Format("State: {0}", player.PlayerState);

                var track = player.Track;

                if (null != track)
                    txtTrack.Text = string.Format("Track: {0}", track.Title);

                // Set the current position on the ProgressBar.
                positionIndicator.Value = player.Position.TotalSeconds;

                // Update the current playback position.
                var position = player.Position;
                textPosition.Text = string.Format("{0:d2}:{1:d2}:{2:d2}", position.Hours, position.Minutes, position.Seconds);

                // Update the time remaining digits.
                if (null != track)
                {
                    var timeRemaining = track.Duration - position;
                    textRemaining.Text = string.Format("-{0:d2}:{1:d2}:{2:d2}", timeRemaining.Hours, timeRemaining.Minutes, timeRemaining.Seconds);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("MainPage.UpdateState() failed: " + ex.Message);
            }
        }

        /// <summary>
        ///     Click handler for the Skip Previous button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //void prevButton_Click(object sender, EventArgs e)
        //{
        //    // Show the indeterminate progress bar.
        //    positionIndicator.IsIndeterminate = true;

        //    // Disable the button so the user can't click it multiple times before 
        //    // the background audio agent is able to handle their request.
        //    //_prevButton.IsEnabled = false;

        //    // Tell the background audio agent to skip to the previous track.
        //    BackgroundAudioPlayer.Instance.SkipPrevious();
        //}

        /// <summary>
        ///     Click handler for the Play button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void playButton_Click(object sender, EventArgs e)
        {
            GoogleAnalytics.EasyTracker.GetTracker().SendEvent("ui_action", "tap", "play_radio", 0);
            // Tell the background audio agent to play the current track.
            //BackgroundAudioPlayer.Instance.Track = new AudioTrack(null, currentStation["name"].ToString(), null, null, null,
            //    currentStation["data"].ToString(),
            //    EnabledPlayerControls.All);
            BackgroundAudioPlayer.Instance.Play();
        }

        /// <summary>
        ///     Click handler for the Pause button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pauseButton_Click(object sender, EventArgs e)
        {
            GoogleAnalytics.EasyTracker.GetTracker().SendEvent("ui_action", "tap", "pause_radio", 0);
            // Tell the background audio agent to pause the current track.
            BackgroundAudioPlayer.Instance.Pause();
        }

        /// <summary>
        ///     Click handler for the Skip Next button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //void nextButton_Click(object sender, EventArgs e)
        //{
        //    // Show the indeterminate progress bar.
        //    positionIndicator.IsIndeterminate = true;

        //    // Disable the button so the user can't click it multiple times before 
        //    // the background audio agent is able to handle their request.
        //    //_nextButton.IsEnabled = false;

        //    // Tell the background audio agent to skip to the next track.
        //    BackgroundAudioPlayer.Instance.SkipNext();
        //}
    


        //#region Recording section
        //private MicrophoneRecorder _recorder = new MicrophoneRecorder();
        //private IsolatedStorageFileStream _audioStream;
        //private string _tempFileName = "tempWav.wav";

        //private void startClick(object sender, RoutedEventArgs e)
        //{
        //    playButton.IsEnabled = false;
        //    saveButton.IsEnabled = false;
        //    recordButton.Content = "Stop";
        //    RotateCircle.Begin();
        //    _recorder.Start();
        //}

        //private void SaveTempAudio(MemoryStream buffer)
        //{
        //    if (buffer == null)
        //        throw new ArgumentNullException("Attempting to save an empty audio file");

        //    //Clean media element hold on audioStream
        //    if (_audioStream != null)
        //    {
        //        playAudio.Stop();
        //        playAudio.Source = null;

        //        _audioStream.Dispose();
        //    }

        //    var bytes = buffer.GetWavAsByteArray(_recorder.SampleRate);

        //    using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
        //    {
        //        if (isoStore.FileExists(_tempFileName))
        //        {
        //            isoStore.DeleteFile(_tempFileName);
        //        }
        //        _tempFileName = string.Format("{0}.wav", DateTime.Now.ToFileTime());
        //        _audioStream = isoStore.CreateFile(_tempFileName);
        //        _audioStream.Write(bytes, 0, bytes.Length);

        //        //Play
        //        playAudio.SetSource(_audioStream);


        //    }
        //}

        //private void playClick(object sender, RoutedEventArgs e)
        //{
        //    BackgroundAudioPlayer.Instance.Close();
        //    saveButton.Visibility = Visibility.Collapsed;
        //    playButton.Visibility = Visibility.Visible;
        //    playAudio.Play();
        //}

        //private void stopClick(object sender, RoutedEventArgs e)
        //{
        //    RotateCircle.Stop();
        //    playButton.IsEnabled = true;
        //    saveButton.IsEnabled = true;
        //    recordButton.Content = "Record";
        //    _recorder.Stop();
        //    SaveTempAudio(_recorder.Buffer);

        //}

        //private void closeGridTap(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    recordPopUp.IsOpen = false;
        //}

        //#endregion

        private void toggleFavorite_Click(object sender, EventArgs e)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;

            if (!settings.Contains("favData"))
            {
                settings.Add("favData", currentStation.ObjectId + ",");
            }
            else
            {
                if (!settings["favData"].ToString().Contains(currentStation.ObjectId))
                {
                    settings["favData"] += currentStation.ObjectId + ",";
                    MessageBox.Show("This station is added as favorite. To remove click on favorite button again.");
                }
                else if (settings["favData"].ToString().Contains(currentStation.ObjectId))
                {
                    string tempSetting = settings["favData"] as string;
                    tempSetting = tempSetting.Replace(currentStation.ObjectId + ",", "");
                    settings["favData"] = tempSetting;
                    MessageBox.Show("This station is removed from favorites.");
                }

            }
            settings.Save();


        }

        //private void recordButtonClick(object sender, EventArgs e)
        //{
        //    recordPopUp.IsOpen = true;
        //}

        //private void saveClick(object sender, RoutedEventArgs e)
        //{
        //    InputPrompt fileName = new InputPrompt();

        //    fileName.Title = "Sound name";
        //    fileName.Message = "What should be the file name";

        //    fileName.Completed += fileName_Completed;
        //    fileName.Show();
        //}

        //private void fileName_Completed(object sender, PopUpEventArgs<string, PopUpResult> e)
        //{
        //    if (e.PopUpResult == PopUpResult.Ok)
        //    {
        //        if (e.Result != null)
        //        {
        //            RecordingsViewModel rvm = new RecordingsViewModel();
        //            rvm.RecTitle = e.Result;
        //            rvm.RecPath = string.Format("/recordAudio/{0}.wav", DateTime.Now.ToFileTime());
        //            rvm.RecTime = DateTime.Now.ToShortDateString();

        //            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
        //            {
        //                if (!isoStore.DirectoryExists("/recordAudio/"))
        //                    isoStore.CreateDirectory("/recordAudio/");
        //                isoStore.MoveFile(_tempFileName, rvm.RecPath);
        //            }

        //            App.ViewModel.RecItems.Add(rvm);

        //            var data = JsonConvert.SerializeObject(App.ViewModel.RecItems);

        //            IsolatedStorageSettings.ApplicationSettings[App.CustomSoundKey] = data;
        //            IsolatedStorageSettings.ApplicationSettings.Save();
        //        }
        //    }

        //    recordPopUp.IsOpen = false;
        //}

       
    }
}