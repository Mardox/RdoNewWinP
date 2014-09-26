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
                                 "http://www.vanguardngr.com/",
                                 "http://www.punchng.com/",
                                 "http://www.nigeriaworld.com/",
                                 "http://ngrguardiannews.com/",
                             };
        

        string[] NewsTitles = {
                                         "Vanguard",
                                         "Punch",
                                         "Nigeria World",
                                         "The Guardian",
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
