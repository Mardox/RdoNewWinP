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
                                 "http://www.philippinenews.com/index.php/en/",
                                 "http://www.philstar.com/headlines",
                                 "http://www.philnews.com/",
                                 "http://www.gmanetwork.com/news/",
                             };


        string[] NewsTitles = {
                                         "Philippine News",
                                         "Phil Star",
                                         "Phil News",
                                         "GMA Network",
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
