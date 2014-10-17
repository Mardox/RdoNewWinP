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
                                 "http://www.theguardian.com/world/ukraine",
                                 "http://www.ukrinform.ua/eng/",
                                 "http://www.unian.info/",
                                 "http://www.day.kiev.ua/en",
                                 "http://www.ukrainianjournal.com/",
                             };


        string[] NewsTitles = {
                                         "The Guardian",
                                         "Ukraine Form",
                                         "Unian",
                                         "Day",
                                         "Ukrainuan Journal",
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
