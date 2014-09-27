using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using RadioNewsPaper.Resources;
using RadioNewsPaper.Data;
using RadioNewsPaper.Views;
using System.IO.IsolatedStorage;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RadioNewsPaper.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.RadioItems = new ObservableCollection<RadioViewModel>();
            this.NewsItems = new ObservableCollection<NewsPaperViewModel>();
            this.RecItems = new List<RecordingsViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        public ObservableCollection<RadioViewModel> RadioItems { get; private set; }
        public ObservableCollection<NewsPaperViewModel> NewsItems { get; private set; }
        public ObservableCollection<RadioFavViewModel> FavItems = new ObservableCollection<RadioFavViewModel>();
        public List<RecordingsViewModel> RecItems { get; set; }
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
            this.IsDataLoaded = true;
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