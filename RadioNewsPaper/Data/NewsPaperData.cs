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
                                 "http://rjrnewsonline.com/",
                                 "http://go-jamaica.com/power/",
                                 "http://www.jamaicaobserver.com",
                                 "http://www.jamaica-star.com",
                                 "http://go-jamaica.com",
                             };


        string[] NewsTitles = {
                                         "RJR News",
                                         "GO-Jamaica",
                                         "Jamaica Observer",
                                         "Jamaica Star",
                                         "Go Jamaica",
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
