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
                                 "http://topics.nytimes.com/top/news/international/countriesandterritories/togo/index.html",
                                 "http://www.bbc.com/news/world-africa-14106781",
                                 "http://www.telegraph.co.uk/news/worldnews/africaandindianocean/togo/",
                                 "http://allafrica.com/togo/",
                                 "http://www.onlinenewspapers.com/togo.htm"
                             };


        string[] NewsTitles = {
                                         "NY Togo",
                                         "BBC News",
                                         "Telegraph",
                                         "All Africa",
                                         "Online Togo"
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
