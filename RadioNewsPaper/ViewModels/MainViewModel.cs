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
using System.Threading.Tasks;

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
       
        //private string[] newsTitles;
        //private string[] newsUrls;

        List<string> newsTitles = new List<string>();
        List<string> newsUrls = new List<string>();

        List<string> radioTitles = new List<string>();
        List<string> radioUrls = new List<string>();

        List<ParseObject> radioStations = new List<ParseObject>();

        List<ParseObject> newsPapers = new List<ParseObject>();


        //private string[] radioTitles;
        //private string[] radioUrls;

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

                int return_value =  await DataCenter.LoadData();

                if (return_value > 0)
                {
                    //radioTitles = RadioData.returnTitle();
                    //radioUrls = RadioData.returnUrl();

                    radioStations = DataCenter.returnStations();

                    //for (int i = 0; i < radioTitles.Count(); i++)
                    //{
                    //    this.RadioItems.Add(new RadioViewModel() { RadioTitle = radioTitles[i], RadioUrl = radioUrls[i] });
                    //}

                    for (int i = 0; i < radioStations.Count(); i++)
                    {
                        ParseObject item = radioStations[i];
                        this.RadioItems.Add(new RadioViewModel() { RadioTitle = item["name"].ToString(), RadioUrl = item["data"].ToString() });
                    }

                    newsPapers = DataCenter.returnPapers();

                    //for (int i = 0; i < radioTitles.Count(); i++)
                    //{
                    //    this.RadioItems.Add(new RadioViewModel() { RadioTitle = radioTitles[i], RadioUrl = radioUrls[i] });
                    //}

                    for (int i = 0; i < newsPapers.Count(); i++)
                    {
                        ParseObject item = newsPapers[i];
                        this.NewsItems.Add(new NewsPaperViewModel() { NewsTitle = item["name"].ToString(), NewsUrl = item["data"].ToString() });
                    }

                }
            //}
        }



        //async void LoadNewsPaperData()
        //{

        //     int return_value =  await DataCenter.LoadNewsPaperData();

        //     if (return_value > 0)
        //     {

        //         newsPapers = DataCenter.returnPapers();

        //         //for (int i = 0; i < radioTitles.Count(); i++)
        //         //{
        //         //    this.RadioItems.Add(new RadioViewModel() { RadioTitle = radioTitles[i], RadioUrl = radioUrls[i] });
        //         //}

        //         for (int i = 0; i < newsPapers.Count(); i++)
        //         {
        //             ParseObject item = newsPapers[i];
        //             this.NewsItems.Add(new NewsPaperViewModel() { NewsTitle = item["name"].ToString(), NewsUrl = item["data"].ToString() });
        //         }


        //         //newsTitles = NewsPaperData.returnNewsTitles();
        //         //newsUrls = NewsPaperData.returnNewsUrls();

        //         //for (int i = 0; i < newsTitles.Count(); i++)
        //         //{
        //         //    this.NewsItems.Add(new NewsPaperViewModel() { NewsTitle = newsTitles[i], NewsUrl = newsUrls[i] });
        //         //}
        //     }

            
      
        //}

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