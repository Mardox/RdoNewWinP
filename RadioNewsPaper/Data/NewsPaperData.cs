using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioNewsPaper.Data
{
    public class NewsPaperData
    {
        public NewsPaperData()
        {

        }

        string[] NewsUrl =   {
                                 "http://en.mercopress.com/argentina",
                                 "http://www.theguardian.com/world/argentina",
                                 "http://topics.nytimes.com/top/news/international/countriesandterritories/argentina/index.html",
                                 "http://topics.bloomberg.com/argentina/",
                                 "http://www.telegraph.co.uk/news/worldnews/southamerica/argentina/",
                             };


        string[] NewsTitles = {
                                         "Merco Press",
                                         "The Guardian",
                                         "The New York Times",
                                         "Bloomberg",
                                         "Telegraph",
                                     };

        public string[] returnNewsUrls()
        {
            return NewsUrl;
        }

        public string[] returnNewsTitles()
        {
            return NewsTitles;
        }
    }
}
