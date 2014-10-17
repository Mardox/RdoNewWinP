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
                                 "http://allafrica.com/mali/",
                                 "http://www.aljazeera.com/category/country/mali",
                                 "http://topics.nytimes.com/top/news/international/countriesandterritories/mali/index.html",
                                 "http://www.theguardian.com/world/mali",
                                 "http://www.telegraph.co.uk/news/worldnews/africaandindianocean/mali/",
                                 "http://www.breakingnews.com/topic/mali/"
                             };


        string[] NewsTitles = {
                                         "All Africa",
                                         "Aljazeera",
                                         "New York Times",
                                         "The Guardian",
                                         "The Telegraph",
                                         "Breaking News"
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
