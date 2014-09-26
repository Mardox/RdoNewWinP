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
                                 "http://zeenews.india.com/marathi",
                                 "http://maharashtratimes.indiatimes.com/",
                                 "http://www.loksatta.com/",
                                 "http://www.batmya.com/",
                                 "http://divyamarathi.bhaskar.com/",
                             };
        

        string[] NewsTitles = {
                                         "Marathi Latest News",
                                         "Maharashtra Times",
                                         "Loksatta",
                                         "Batmya",
                                         "Divya",
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
