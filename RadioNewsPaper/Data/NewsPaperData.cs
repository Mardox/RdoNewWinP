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
                                 "http://allafrica.com/angola/",
                                 "http://www.portalangop.co.ao/angola/en_us/",
                                 "http://www.telegraph.co.uk/news/worldnews/africaandindianocean/angola/",
                                 "http://www.bbc.com/news/world-africa-13036732",
                                 "http://www.theguardian.com/world/angola",
                                 "http://www.onlinenewspapers.com/angola.htm"
                             };


        string[] NewsTitles = {
                                         "All Africa",
                                         "Angola Press",
                                         "Angola News",
                                         "BBC News",
                                         "Angola Gardian",
                                         "Angolan"
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
