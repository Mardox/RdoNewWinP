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
                                 "http://www.thehindu.com/",
                                 "http://timesofindia.indiatimes.com/",
                                 "http://indianexpress.com/",
                                 "http://indiatoday.intoday.in/",
                                 "http://zeenews.india.com/",
                             };
        

        string[] NewsTitles = {
                                         "The Hindu",
                                         "Times of India",
                                         "The Indian Express",
                                         "India Today",
                                         "Zee News",
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
