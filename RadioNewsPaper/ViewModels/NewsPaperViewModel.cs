using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioNewsPaper.ViewModels
{
    public class NewsPaperViewModel : INotifyPropertyChanged
    {
        private string _newsTitle;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string NewsTitle
        {
            get
            {
                return _newsTitle;
            }
            set
            {
                if (value != _newsTitle)
                {
                    _newsTitle = value;
                    NotifyPropertyChanged("NewsTitle");
                }
            }
        }

        private string _newsUrl;
        public string NewsUrl
        {
            get
            {
                return _newsUrl;
            }
            set
            {
                if (value != _newsUrl)
                {
                    _newsUrl = value;
                    NotifyPropertyChanged("NewsUrl");
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
