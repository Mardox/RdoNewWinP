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
                                 "http://www.banglanews24.com/beta/",
                                 "http://www.bbc.co.uk/bengali",
                                 "http://www.allbanglanewspaper.com/",
                                 "http://news-bangla.com/",
                             };


        string[] NewsTitles = {
                                         "Bangala News",
                                         "BBC Bangla",
                                         "All Bangla Newspaper",
                                         "News Bangala",
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
