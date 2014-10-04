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
                                 "http://topics.nytimes.com/top/news/international/countriesandterritories/indonesia/index.html",
                                 "http://www.thejakartapost.com/",
                                 "http://www.telegraph.co.uk/news/worldnews/asia/indonesia/",
                                 "http://www.theguardian.com/world/indonesia",
                                 "http://www.globalpost.com/news/regions/asia-pacific/indonesia",
                                 "http://www.dailyindonesia.com/"
                             };


        string[] NewsTitles = {
                                         "New York Times",
                                         "the Jakarta Post",
                                         "The Telegraph",
                                         "The Guardian",
                                         "The Global Post",
                                         "Daily Indonesia"
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
