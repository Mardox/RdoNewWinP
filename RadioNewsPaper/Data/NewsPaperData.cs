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
                                 "http://www.ghanaweb.com",
                                 "http://www.peacefmonline.com/",
                                 "http://vibeghana.com/",
                                 "http://www.modernghana.com/",
                                 "http://www.ghananewsagency.org/",
                                 "http://www.ghanareview.com/Restyle/"
                             };


        string[] NewsTitles = {
                                         "Ghana",
                                         "Peace FM Online",
                                         "Vibe Ghana",
                                         "Modern Ghana",
                                         "Ghana News Agency",
                                         "Ghana Review International"
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
