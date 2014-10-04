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
                                 "http://latino.foxnews.com",
                                 "http://www.latino-news.com",
                                 "http://www.elhispanicnews.com",
                                 "http://www.nydailynews.com/latino",
                                 "http://www.huffingtonpost.com/latino-voices/"
                             };


        string[] NewsTitles = {
                                         "Fox News Latino",
                                         "Latino News",
                                         "El Hispanic News",
                                         "New York Latino News",
                                         "Huffington Post"
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
