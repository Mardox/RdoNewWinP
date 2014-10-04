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
                                 "http://www.telegraph.co.uk/news/worldnews/southamerica/brazil/",
                                 "http://riotimesonline.com/brazil-news/tag/brazil-news/#",
                                 "http://www.theguardian.com/world/brazil",
                                 "http://www.globalpost.com/news/regions/americas/brazil",
                             };


        string[] NewsTitles = {
                                         "The Telegraph",
                                         "The Rio Times",
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
