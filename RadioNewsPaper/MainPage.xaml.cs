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

namespace RadioNewsPaper
{
    public partial class MainPage : PhoneApplicationPage
    {
        private RadioData rdata;
        private InterstitialAd interstitialAd;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            Loaded += MainPage_Loaded;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
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
    }
}