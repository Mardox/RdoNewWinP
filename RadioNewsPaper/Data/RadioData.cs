using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioNewsPaper.Data
{
    public class RadioData
    {
        public RadioData()
        {

        }

        string[] radioTitle = {
                                  "RadioPalmWine",
                                  "Yoruba Radio",
                                  "Kapital FM",
                                  "Dawahnigeria Quran",
                                  "Space FM 90.1",
                                  "Breeze Radio",
                              };
        string[] radioUrl = {
                                "http://67.23.246.19:8004",
                                "http://67.23.246.19:8002",
                                "http://97.74.73.104:9996",
                                "http://108.163.197.114:8148",
                                "http://78.129.159.25:8096",
                                "http://5.63.145.172:7114",
                            };

        public string adBanner = "ca-app-pub-7607380003153721/8020389098";
        public string homeInterstitial = "ca-app-pub-7607380003153721/9497122296";
        public string detailInterstitial = "ca-app-pub-7607380003153721/1973855493";

        public string[] returnTitle()
        {
            return radioTitle;
        }

        public string[] returnUrl()
        {
            return radioUrl;
        }

    }
}
