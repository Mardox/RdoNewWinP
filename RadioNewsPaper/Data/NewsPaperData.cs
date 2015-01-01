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
                                 "http://saharareporters.com/News",
                                 "http://saharareporters.com/reports",
                                 "http://saharareporters.com/breaking-news",
                                 "http://www.latestnigeriannews.com/latest-news/saharareporters/"
                             };


        string[] NewsTitles = {
                                         "SR News",
                                         "SR News Reports",
                                         "Breaking News",
                                         "Reporters Headline"
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
