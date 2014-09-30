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
                                 "http://loudwire.com/",
                                 "http://www.rollingstone.com/music/news",
                                 "http://www.antimusic.com/dayinrock/",
                                 "http://www.blabbermouth.net/",
                                 "http://www.planetrock.com/news/rock-news/",
                             };


        string[] NewsTitles = {
                                         "Loudwire",
                                         "RollingStone",
                                         "Antimusic",
                                         "Blabbermouth",
                                         "Planet Rock",
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
