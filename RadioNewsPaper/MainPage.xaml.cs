using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using RadioNewsPaper.Resources;
using GoogleAds;
using System.Diagnostics;
using RadioNewsPaper.Data;
using RadioNewsPaper.ViewModels;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.IO;
using Microsoft.Phone.BackgroundAudio;
using Microsoft.Phone.Tasks;
using Newtonsoft.Json;

namespace RadioNewsPaper
{
    public partial class MainPage : PhoneApplicationPage
    {
        private RadioData rdata;
        private InterstitialAd interstitialAd, interstitialAd2;
        int popupCount = 1;
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            Loaded += MainPage_Loaded;
            FeedbackOverlay.VisibilityChanged += FeedbackOverlay_VisibilityChanged;
            playRecAudio.MediaEnded += playRecAudio_MediaEnded;
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        void playRecAudio_MediaEnded(object sender, RoutedEventArgs e)
        {
            RotateCircle.Stop();
            recordPlayPopUp.IsOpen = false;
        }

        void FeedbackOverlay_VisibilityChanged(object sender, EventArgs e)
        {
            //ApplicationBar.IsVisible = (FeedbackOverlay.Visibility != Visibility.Visible);
        }

        // Soon after loading Main Page
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            rdata = new RadioData();
            interstitialAd = new InterstitialAd(rdata.homeInterstitial);
            AdRequest adRequest = new AdRequest();

            interstitialAd.ReceivedAd += OnAdReceived;
            interstitialAd.DismissingOverlay += interstitialAd_DismissingOverlay;
            interstitialAd.LoadAd(adRequest);

            //Interstitial two
            interstitialAd2 = new InterstitialAd(rdata.detailInterstitial);
            AdRequest adRequest2 = new AdRequest();

            interstitialAd2.ReceivedAd += OnAdReceived2;
            interstitialAd2.DismissingOverlay += interstitialAd_DismissingOverlay2;
            interstitialAd2.LoadAd(adRequest2);

            AdView bannerAd = new AdView
            {
                Format = AdFormats.Banner,
                AdUnitID = rdata.adBanner
            };
            AdRequest BanneradRequest = new AdRequest();
            // Assumes we've defined a Grid that has a name
            // directive of ContentPanel.
            LayoutRoot.Children.Add(bannerAd);
            bannerAd.VerticalAlignment = VerticalAlignment.Bottom;
            bannerAd.LoadAd(BanneradRequest);
        }

        #region Ad Handlers
        private void interstitialAd_DismissingOverlay2(object sender, AdEventArgs e)
        {
            //do nothing
            recordPlayPopUp.IsOpen = true;
            playRecAudio.AutoPlay = true;
            playRecAudio.Play();
        }

        private void OnAdReceived2(object sender, AdEventArgs e)
        {
            Debug.WriteLine("Received second ad");
            
        }

        void interstitialAd_DismissingOverlay(object sender, AdEventArgs e)
        {
            Application.Current.Terminate();
        }

        private void OnAdReceived(object sender, AdEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ad received successfully");
        }
        #endregion

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            playRecAudio.AutoPlay = false;
        }

        #region Radio and News Taps
        private void RadioItem_Tap(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null, do nothing
            if (RadioList.SelectedItem == null)
                return;

            var longlistselector = (sender as LongListSelector);
            int index = longlistselector.ItemsSource.IndexOf(longlistselector.SelectedItem);
            //MessageBox.Show(index.ToString());
            NavigationService.Navigate(new Uri("/Views/RadioDetail.xaml?index=" + index, UriKind.Relative));

            // Reset selected item to null
            RadioList.SelectedItem = null;
        }

        private void NewsPaper_Tap(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null, do nothing
            if (NewsPaperList.SelectedItem == null)
                return;

            var longlistselector = (sender as LongListSelector);
            int index = longlistselector.ItemsSource.IndexOf(longlistselector.SelectedItem);
            //MessageBox.Show(index.ToString());
            NavigationService.Navigate(new Uri("/Views/NewsPaperDetail.xaml?index=" + index, UriKind.Relative));

            // Reset selected item to null
            NewsPaperList.SelectedItem = null;
        }
        #endregion

        //Back key press
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                interstitialAd.ShowAd();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                var result = MessageBox.Show("Come back soon!", "Are you sure?", MessageBoxButton.OKCancel);
                e.Cancel = result != MessageBoxResult.OK;
            }
            base.OnBackKeyPress(e);
            
        }

        #region Favorite Item

        private void RadioFavItem_Tap(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null, do nothing
            if (FavList.SelectedItem == null)
                return;

            var longlistselector = (sender as LongListSelector);
            int index = longlistselector.ItemsSource.IndexOf(longlistselector.SelectedItem);
            //MessageBox.Show(index.ToString());
            NavigationService.Navigate(new Uri("/Views/RadioDetail.xaml?favIndex=" + index, UriKind.Relative));

            // Reset selected item to null
            FavList.SelectedItem = null;
        }
        private string[] radioTitles;
        private string[] radioUrls;
        private void favListLoaded(object sender, RoutedEventArgs e)
        {
            
            if (IsolatedStorageSettings.ApplicationSettings.Contains("favData"))
            {
                string fav = IsolatedStorageSettings.ApplicationSettings["favData"] as string;
                if (fav != "")
                {
                    App.ViewModel.FavItems.Clear();
                    string[] tempFav = fav.Split(',');
                    RadioData rData = new RadioData();
                    radioTitles = rData.returnTitle();
                    radioUrls = rData.returnUrl();
                    foreach (string favItem in tempFav)
                    {
                        for (int i = 0; i < radioTitles.Length; i++)
                        {
                            if (favItem == radioTitles[i])
                            {
                                App.ViewModel.FavItems.Add(new RadioFavViewModel() { RadioTitle = radioTitles[i], RadioUrl = radioUrls[i], FavIndex = i });
                            }
                        }
                    }
                }
                else
                {
                    App.ViewModel.FavItems.Clear();
                }
            }
            FavList.ItemsSource = App.ViewModel.FavItems;
        }

        #endregion

        #region Recording List helpers
        private void RadioRecordingItem_Tap(object sender, SelectionChangedEventArgs e)
        {
            playRecAudio.AutoPlay = true;
            recordPlayPopUp.IsOpen = true;
            RotateCircle.Begin();
            LongListSelector selector = sender as LongListSelector;

            // verifying our sender is actually a LongListSelector
            if (selector == null)
                return;

            RecordingsViewModel data = selector.SelectedItem as RecordingsViewModel;

            // verifying our sender is actually SoundData
            if (data == null)
                return;

            // is file a custom recorded file?
            if (File.Exists(data.RecPath))
            {
                playRecAudio.Source = new Uri(data.RecPath, UriKind.RelativeOrAbsolute);
            }
            else
            {
                using (var storageFolder = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (var stream = new IsolatedStorageFileStream(data.RecPath, FileMode.Open, FileAccess.Read ,FileShare.Read, storageFolder))
                    {
                        BackgroundAudioPlayer.Instance.Close();
                        playRecAudio.SetSource(stream);
                    }
                }
            }

            #region Interstitial
            try
            {
                IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
                if (!settings.Contains("radioPopupCount"))
                {
                    settings.Add("radioPopupCount", 1);
                }
                else
                {
                    popupCount = (int)IsolatedStorageSettings.ApplicationSettings["radioPopupCount"];
                    settings["radioPopupCount"] = popupCount + 1;
                }
                settings.Save();

                if (popupCount % 5 == 0)
                {
                    interstitialAd2.ShowAd();
                }
            }
            catch (Exception ex)
            {
                //Do nothing
            }
            #endregion

            //playRecAudio.Play();
            // resetting selected so we can play the same sound over and over again
            selector.SelectedItem = null;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var myItem = (sender as MenuItem).DataContext as RecordingsViewModel;

            App.ViewModel.RecItems.Remove(myItem);
            var data = JsonConvert.SerializeObject(App.ViewModel.RecItems);
            LayoutRoot.UpdateLayout();
            IsolatedStorageSettings.ApplicationSettings[App.CustomSoundKey] = data;
            IsolatedStorageSettings.ApplicationSettings.Save();
        }

        private void closePopupTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            recordPlayPopUp.IsOpen = false;
            playRecAudio.Stop();
            RotateCircle.Stop();
        }
        #endregion

        //Button on the appbar
        private void nowPlaying_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/RadioDetail.xaml", UriKind.RelativeOrAbsolute));
        }

        

        private void MoreItem_Tap(object sender, SelectionChangedEventArgs e)
        {
            var myItem = ((LongListSelector)sender).SelectedItem as MoreItemViewModel;

            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri(myItem.StoreUrl);
            webBrowserTask.Show();
        }
    }
}