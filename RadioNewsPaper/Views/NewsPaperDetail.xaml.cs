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
using RadioNewsPaper.ViewModels;
using GoogleAds;


namespace RadioNewsPaper.Views
{
    public partial class NewsPaperDetail : PhoneApplicationPage
    {
        string index = "";
        NewsPaperData newsData;
        RadioData rData;
        private InterstitialAd interstitialAd, interstitialAd2;

        public NewsPaperDetail()
        {
            InitializeComponent();

            NewsPaperBrowser.LoadCompleted += NewsPaperBrowser_LoadCompleted;

            rData = new RadioData();
            AdView bannerAd = new AdView
            {
                Format = AdFormats.Banner,
                AdUnitID = rData.adBanner
            };
            AdRequest BanneradRequest = new AdRequest();
            // Assumes we've defined a Grid that has a name
            // directive of ContentPanel.
            ContentPanel.Children.Add(bannerAd);
            bannerAd.VerticalAlignment = VerticalAlignment.Bottom;
            bannerAd.LoadAd(BanneradRequest);

            Loaded += NewsPaperDetail_Loaded;

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
            if (RandomNumber() == 0)
            {
                interstitialAd2.ShowAd();
            }
        }

        void NewsPaperBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            browserProgress.Visibility = Visibility.Collapsed;
        }

        void NewsPaperDetail_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(index);
            //mainViewModel = new MainViewModel();
            //mainViewModel.NewsSource(Convert.ToInt32(index));
            newsData = new NewsPaperData();
            string[] newsUrls = newsData.returnNewsUrls();
            NewsPaperBrowser.Navigate(new Uri(newsUrls[Convert.ToInt32(index)], UriKind.Absolute));
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string temp;

            if (NavigationContext.QueryString.TryGetValue("index", out temp))
            {
                index = temp;
            }
            newsData = new NewsPaperData();
            string[] newsTitles = newsData.returnNewsTitles();
            //pageName.Text = newsTitles[Convert.ToInt32(index)];
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (RandomNumber() == 0)
            {
                interstitialAd.ShowAd();
            }
            else
            {
                NavigationService.GoBack();
            }
        }


        private int RandomNumber()
        {
            Random random = new Random();
            return random.Next(0, 2);
        }
    }
}