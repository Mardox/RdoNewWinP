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
        public NewsPaperDetail()
        {
            InitializeComponent();
            Loaded += NewsPaperDetail_Loaded;
            NewsPaperBrowser.LoadCompleted += NewsPaperBrowser_LoadCompleted;

            RadioData rData = new RadioData();
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
    }
}