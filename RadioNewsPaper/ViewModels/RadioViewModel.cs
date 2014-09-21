using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioNewsPaper.ViewModels
{
    public class RadioViewModel : INotifyPropertyChanged
    {
        private string _radioTitle;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string RadioTitle
        {
            get
            {
                return _radioTitle;
            }
            set
            {
                if (value != _radioTitle)
                {
                    _radioTitle = value;
                    NotifyPropertyChanged("RadioTitle");
                }
            }
        }

        private string _radioUrl;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string RadioUrl
        {
            get
            {
                return _radioUrl;
            }
            set
            {
                if (value != _radioUrl)
                {
                    _radioUrl = value;
                    NotifyPropertyChanged("RadioUrl");
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
