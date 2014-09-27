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

namespace RadioNewsPaper
{
    public partial class MainPage : PhoneApplicationPage
    {
        private RadioData rdata;
        private InterstitialAd interstitialAd;
        //public ObservableCollection<RadioFavViewModel> FavItems;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            Loaded += MainPage_Loaded;
            FeedbackOverlay.VisibilityChanged += FeedbackOverlay_VisibilityChanged;
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        void FeedbackOverlay_VisibilityChanged(object sender, EventArgs e)
        {
            //ApplicationBar.IsVisible = (FeedbackOverlay.Visibility != Visibility.Visible);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            rdata = new RadioData();
            interstitialAd = new InterstitialAd(rdata.homeInterstitial);
            AdRequest adRequest = new AdRequest();

            interstitialAd.ReceivedAd += OnAdReceived;
            interstitialAd.DismissingOverlay += interstitialAd_DismissingOverlay;
            interstitialAd.LoadAd(adRequest);

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

        void interstitialAd_DismissingOverlay(object sender, AdEventArgs e)
        {
            Application.Current.Terminate();
        }

        private void OnAdReceived(object sender, AdEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Ad received successfully");
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

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

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            //Do your work here
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
            }
            FavList.ItemsSource = App.ViewModel.FavItems;
        }

        private void RadioRecordingItem_Tap(object sender, SelectionChangedEventArgs e)
        {
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
                    using (var stream = new IsolatedStorageFileStream(data.RecPath, FileMode.Open, storageFolder))
                    {
                        BackgroundAudioPlayer.Instance.Close();
                        playRecAudio.SetSource(stream);
                        stream.Close();
                    }
                }
            }

            //playRecAudio.Play();
            // resetting selected so we can play the same sound over and over again
            selector.SelectedItem = null;
        }

        private void recListLoaded(object sender, RoutedEventArgs e)
        {
            RecList.ItemsSource = App.ViewModel.RecItems;
        }
    }
}