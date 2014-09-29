using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioNewsPaper.ViewModels
{
    public class MoreItemViewModel : INotifyPropertyChanged
    {
        private string _moreItemTitle;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string MoreItemTitle
        {
            get
            {
                return _moreItemTitle;
            }
            set
            {
                if (value != _moreItemTitle)
                {
                    _moreItemTitle = value;
                    NotifyPropertyChanged("MoreItemTitle");
                }
            }
        }

        private string _storeUrl;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string StoreUrl
        {
            get
            {
                return _storeUrl;
            }
            set
            {
                if (value != _storeUrl)
                {
                    _storeUrl = value;
                    NotifyPropertyChanged("StoreUrl");
                }
            }
        }

        private string _imageUrl;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                if (value != _imageUrl)
                {
                    _imageUrl = value;
                    NotifyPropertyChanged("ImageUrl");
                }
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
