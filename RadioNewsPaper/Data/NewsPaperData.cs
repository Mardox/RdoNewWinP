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
                                 "http://www.topix.com/world/mexico",
                                 "http://topics.nytimes.com/top/news/international/countriesandterritories/mexico/index.html",
                                 "http://www.theguardian.com/world/mexico",
                                 "http://www.globalpost.com/news/regions/americas/mexico",
                             };


        string[] NewsTitles = {
                                         "Mexico News- Topix",
                                         "New York Times - Mexico",
                                         "The Guardian",
                                         "Global Post",
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
