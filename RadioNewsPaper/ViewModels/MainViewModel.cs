using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using RadioNewsPaper.Resources;
using RadioNewsPaper.Data;
using RadioNewsPaper.Views;
using System.IO.IsolatedStorage;
using Newtonsoft.Json;
using System.Collections.Generic;
using Parse;
using System.Collections;
using System.Linq;
using System.Net;
using System.IO;

namespace RadioNewsPaper.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.RadioItems = new ObservableCollection<RadioViewModel>();
            this.NewsItems = new ObservableCollection<NewsPaperViewModel>();
            this.RecItems = new ObservableCollection<RecordingsViewModel>();
            this.MoreItems = new ObservableCollection<MoreItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        public ObservableCollection<RadioViewModel> RadioItems { get; private set; }
        public ObservableCollection<NewsPaperViewModel> NewsItems { get; private set; }
        public ObservableCollection<RadioFavViewModel> FavItems = new ObservableCollection<RadioFavViewModel>();
        public ObservableCollection<RecordingsViewModel> RecItems { get; set; }
        public ObservableCollection<MoreItemViewModel> MoreItems { get; set; }
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
            LoadRecordingData();
            LoadMoreItemsData();
            this.IsDataLoaded = true;
        }

        private void LoadMoreItemsData()
        {
            MoreItemsData mData = new MoreItemsData();
            string[] moreTitles = mData.MoreTitles;
            string[] storeUrls = mData.StoreUrls;
            string[] imageUrls = mData.ImageUrls;

            for (int i = 0; i < moreTitles.Length; i++)
            {
                this.MoreItems.Add(new MoreItemViewModel() { MoreItemTitle = moreTitles[i], StoreUrl = storeUrls[i], ImageUrl = imageUrls[i] });
            }
        }

        void LoadRecordingData()
        {
            List<RecordingsViewModel> list;
            RecordingsViewModel data = new RecordingsViewModel();
            string dataFromAppSettings;

            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains(App.CustomSoundKey))
            {
                if (IsolatedStorageSettings.ApplicationSettings.TryGetValue(App.CustomSoundKey, out dataFromAppSettings))
                {
                    list = JsonConvert.DeserializeObject<List<RecordingsViewModel>>(dataFromAppSettings);
                    foreach (var item in list)
                    {
                        data = item;
                        this.RecItems.Add(new RecordingsViewModel() { RecTitle = data.RecTitle, RecPath = data.RecPath, RecTime = data.RecTime });
                    }
                    
                }
            }
            
            else
            {
                data = new RecordingsViewModel();
            }

            
        }

        async void LoadRadioData()
        {

            var stations = ParseObject.GetQuery("Data").WhereEqualTo("country", "Ghana").WhereEqualTo("type", "Radio");
            IEnumerable<ParseObject> results = await stations.FindAsync();

            for (int i = 0; i < results.Count() ; i++)
            {
                ParseObject item = results.ElementAt(i);
                this.RadioItems.Add(new RadioViewModel() { RadioTitle = item["name"].ToString(), RadioUrl = item["data"].ToString() });

            }

            //Items = new ObservableCollection<ItemViewModel>();
            //RadioData rData = new RadioData();
            //radioTitles = rData.returnTitle();
            //radioUrls = rData.returnUrl();
            //for (int i = 0; i < radioTitles.Length; i++)
            //{
            //    this.RadioItems.Add(new RadioViewModel() { RadioTitle = radioTitles[i], RadioUrl = radioUrls[i] });
            //}
        }



        async void LoadNewsPaperData()
        {


            var stations = ParseObject.GetQuery("Data").WhereEqualTo("country", "Ghana").WhereEqualTo("type", "News");
            IEnumerable<ParseObject> results = await stations.FindAsync();

            for (int i = 0; i < results.Count(); i++)
            {
                ParseObject item = results.ElementAt(i);

                this.NewsItems.Add(new NewsPaperViewModel() { NewsTitle = item["name"].ToString(), NewsUrl = item["data"].ToString() });
            }


            //Items = new ObservableCollection<ItemViewModel>();
            //NewsPaperData nData = new NewsPaperData();
            //newsTitles = nData.returnNewsTitles();
            //newsUrls = nData.returnNewsUrls();
            //for (int i = 0; i < newsTitles.Length; i++)
            //{
            //    this.NewsItems.Add(new NewsPaperViewModel() { NewsTitle = newsTitles[i], NewsUrl = newsUrls[i] });
            //}
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