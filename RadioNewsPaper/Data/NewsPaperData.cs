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
                                 "http://www.monitor.co.ug/",
                                 "http://www.newvision.co.ug/",
                                 "http://www.redpepper.co.ug/",
                                 "http://www.bukedde.co.ug/",
                                 "http://www.observer.ug/",
                                 "http://allafrica.com/uganda/"
                             };


        string[] NewsTitles = {
                                         "Daily Monitor",
                                         "New Vision",
                                         "Red Paper",
                                         "Bukedde",
                                         "The Observer",
                                         "All Africa"
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
