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
                                 "http://allafrica.com/senegal/",
                                 "http://topics.nytimes.com/top/news/international/countriesandterritories/senegal/index.html",
                                 "http://www.telegraph.co.uk/news/worldnews/africaandindianocean/senegal/",
                                 "http://www.theguardian.com/world/senegal",
                                 "http://abcnews.go.com/topics/news/senegal.htm",
                                 "http://www.topix.com/sn/dakar"
                             };


        string[] NewsTitles = {
                                         "All Africa",
                                         "New York Times",
                                         "Telegraph",
                                         "The Guardian",
                                         "ABC News",
                                         "Topix"
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
