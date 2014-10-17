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
                                 "http://www.telegraph.co.uk/news/worldnews/europe/albania/",
                                 "http://topics.nytimes.com/top/news/international/countriesandterritories/albania/index.html",
                                 "http://www.theguardian.com/world/albania",
                                 "http://world.einnews.com/country/albania",
                             };


        string[] NewsTitles = {
                                         "The Telegraph",
                                         "New York Times",
                                         "The Guardian",
                                         "World News Report",
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
