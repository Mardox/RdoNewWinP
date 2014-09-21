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
                                 "http://www.prothom-alo.com",
                                 "http://www.ittefaq.com.bd",
                                 "http://www.amardeshonline.com",
                                 "http://www.samakal.net",
                                 "http://www.amadershomoybd.com",
                                 "http://www.thebangladeshtoday.com",
                                 "http://www.thefinancialexpress-bd.com",
                                 "http://www.newstoday.com.bd",
                                 "http://www.thenewnationbd.com"
                             };
        

        string[] NewsTitles = {
                                         "Channel 1",
                                         "Channel 2",
                                         "Channel 3",
                                         "Channel 4",
                                         "Channel 5",
                                         "Channel 6",
                                         "Channel 7",
                                         "Channel 8",
                                         "Channel 9"

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
