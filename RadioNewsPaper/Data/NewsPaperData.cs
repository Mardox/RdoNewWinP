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
                                 "http://www.peruthisweek.com/news",
                                 "http://www.peruviantimes.com/",
                                 "http://topics.nytimes.com/top/news/international/countriesandterritories/peru/index.html",
                                 "http://www.telegraph.co.uk/news/worldnews/southamerica/peru/",
                                 "http://www.andina.com.pe/ingles/",
                                 "http://www.theguardian.com/world/peru"
                             };


        string[] NewsTitles = {
                                         "Peru This Week",
                                         "Peruvian Times",
                                         "New York Times",
                                         "Telegraph",
                                         "Andina",
                                         "The guardian"
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
