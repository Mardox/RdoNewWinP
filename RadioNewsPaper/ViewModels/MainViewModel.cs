using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using RadioNewsPaper.Resources;
using RadioNewsPaper.Data;
using RadioNewsPaper.Views;
using System.IO.IsolatedStorage;

namespace RadioNewsPaper.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.RadioItems = new ObservableCollection<RadioViewModel>();
            this.NewsItems = new ObservableCollection<NewsPaperViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        public ObservableCollection<RadioViewModel> RadioItems { get; private set; }
        public ObservableCollection<NewsPaperViewModel> NewsItems { get; private set; }
        public ObservableCollection<RadioFavViewModel> FavItems = new ObservableCollection<RadioFavViewModel>();
        private string[] newsTitles;
        private string[] newsUrls;
        private string[] radioTitles;
        private string[] radioUrls;

        private string _favoritesProperty = "Favorites Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string FavoritesProperty
        {
            get
            {
                return _favoritesProperty;
            }
            set
            {
                if (value != _favoritesProperty)
                {
                    _favoritesProperty = value;
                    NotifyPropertyChanged("FavoritesProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            LoadRadioData();
            LoadNewsPaperData();
            this.IsDataLoaded = true;
        }

        void LoadRadioData()
        {
            //Items = new ObservableCollection<ItemViewModel>();
            RadioData rData = new RadioData();
            radioTitles = rData.returnTitle();
            radioUrls = rData.returnUrl();
            for (int i = 0; i < radioTitles.Length; i++)
            {
                this.RadioItems.Add(new RadioViewModel() { RadioTitle = radioTitles[i], RadioUrl = radioUrls[i] });
            }
        }

        void LoadNewsPaperData()
        {
            Items = new ObservableCollection<ItemViewModel>();
            NewsPaperData nData = new NewsPaperData();
            newsTitles = nData.returnNewsTitles();
            newsUrls = nData.returnNewsUrls();
            for (int i = 0; i < newsTitles.Length; i++)
            {
                this.NewsItems.Add(new NewsPaperViewModel() { NewsTitle = newsTitles[i], NewsUrl = newsUrls[i] });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}