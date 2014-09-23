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
                                 "http://www.pknews.tv/",
                                 "http://www.thenews.com.pk/News.aspx",
                                 "http://www.dawn.com/",
                                 "http://tribune.com.pk/",
                             };
        

        string[] NewsTitles = {
                                         "Siasat",
                                         "International News",
                                         "Dawn",
                                         "Tribune",
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
