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
                                 "http://www.hondurasnews.com/",
                                 "http://topics.nytimes.com/top/news/international/countriesandterritories/honduras/index.html",
                                 "http://www.huffingtonpost.com/news/honduras/",
                                 "http://www.hondurasweekly.com/",
                             };


        string[] NewsTitles = {
                                         "Hondura news",
                                         "New York Times",
                                         "Huffington Post",
                                         "Honduras Weekly",
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
