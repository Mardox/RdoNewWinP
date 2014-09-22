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

namespace RadioNewsPaper
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
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
    }
}