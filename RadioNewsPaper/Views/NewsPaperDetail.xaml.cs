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
using System.Diagnostics;
using Parse;

namespace RadioNewsPaper.Views
{
    public partial class NewsPaperDetail : PhoneApplicationPage
    {
        string index = "";

       // RadioData rData;
        private InterstitialAd interstitialAd, interstitialAd2;

        public NewsPaperDetail()
        {
            InitializeComponent();

            NewsPaperBrowser.LoadCompleted += NewsPaperBrowser_LoadCompleted;

            GoogleAnalytics.EasyTracker.GetTracker().SendView("NewsPaper");

            //rData = new RadioData();
            //AdView bannerAd = new AdView
            //{
            //    Format = AdFormats.Banner,
            //    AdUnitID = rData.adBanner
            //};
            //AdRequest BanneradRequest = new AdRequest();
            //// Assumes we've defined a Grid that has a name
            //// directive of ContentPanel.
            //ContentPanel.Children.Add(bannerAd);
            //bannerAd.VerticalAlignment = VerticalAlignment.Bottom;
            //bannerAd.LoadAd(BanneradRequest);

            Loaded += NewsPaperDetail_Loaded;

            interstitialAd = new InterstitialAd(DataCenter.detailInterstitial);
            AdRequest adRequest = new AdRequest();

            interstitialAd.ReceivedAd += OnAdReceived;
            interstitialAd.DismissingOverlay += interstitialAd_DismissingOverlay;
            interstitialAd.LoadAd(adRequest);

            //Interstitial two
            //interstitialAd2 = new InterstitialAd(rData.detailInterstitial);
            //AdRequest adRequest2 = new AdRequest();

            //interstitialAd2.ReceivedAd += OnAdReceived2;
            //interstitialAd2.DismissingOverlay += interstitialAd_DismissingOverlay2;
            //interstitialAd2.LoadAd(adRequest2);

            AdMediator_NewsPaper_Detail.AdSdkError += AdMediator_Bottom_AdError;
            AdMediator_NewsPaper_Detail.AdMediatorFilled += AdMediator_Bottom_AdFilled;
            AdMediator_NewsPaper_Detail.AdMediatorError += AdMediator_Bottom_AdMediatorError;
            AdMediator_NewsPaper_Detail.AdSdkEvent += AdMediator_Bottom_AdSdkEvent;

        }


        void AdMediator_Bottom_AdSdkEvent(object sender, Microsoft.AdMediator.Core.Events.AdSdkEventArgs e)
        {
            Debug.WriteLine("AdSdk event {0} by {1}", e.EventName, e.Name);
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
            if (DataCenter.showAds())
            {
              //  interstitialAd2.ShowAd();
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

            List<ParseObject> newsPapers = DataCenter.returnPapers();
            ParseObject currentPaper = newsPapers[Convert.ToInt32(index)];

            GoogleAnalytics.EasyTracker.GetTracker().SendEvent("app_action", "show_paper", currentPaper["name"].ToString(), 0);

            NewsPaperBrowser.Navigate(new Uri(currentPaper["data"].ToString(), UriKind.Absolute));

            
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string temp;

            if (NavigationContext.QueryString.TryGetValue("index", out temp))
            {
                index = temp;
            }

            //List<string> newsTitles = NewsPaperData.returnNewsTitles();
            //pageName.Text = newsTitles[Convert.ToInt32(index)];
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (DataCenter.showAds())
            {
                interstitialAd.ShowAd();
            }
            else
            {
                NavigationService.GoBack();
            }
        }


    }
}