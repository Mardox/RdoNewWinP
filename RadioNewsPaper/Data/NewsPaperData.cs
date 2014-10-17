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
                                 "http://www.bta.bg/en",
                                 "http://www.telegraph.co.uk/news/worldnews/europe/bulgaria/",
                                 "http://topics.nytimes.com/top/news/international/countriesandterritories/bulgaria/index.html",
                                 "http://www.theguardian.com/world/bulgaria",
                                 "http://www.standartnews.com/english/"
                             };


        string[] NewsTitles = {
                                         "Bulgarian News",
                                         "The Telegraph",
                                         "New York Times",
                                         "The Guardian",
                                         "Stand Art",
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
