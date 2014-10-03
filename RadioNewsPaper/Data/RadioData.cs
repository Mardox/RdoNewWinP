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
                                  "Radio Jamaica Brasileira Um novo conceito em webradio esta no ar",
                                  "Power 106 FM Jamaica on Go-Jamaica",
                                  "NewsTalk 93FM Streaming Live From our Studios at UWI MONA, JAMAICA",
                                  "AUTO DJ RADIO BRASIL JAMAICA",
                                  "Radio Mundo LusoRadio Mundo Luso",
                              };
        string[] radioUrl = {
                                "http://199.233.233.42:14004",
                                "http://205.234.238.42:5480",
                                "http://91.121.67.122:7002",
                                "http://170.75.144.146:11974",
                                "http://217.129.160.26:8000",
                            };

        public string adBanner = "ca-app-pub-7607380003153721/5068105892";
        public string homeInterstitial = "ca-app-pub-7607380003153721/6544839091";
        public string detailInterstitial = "ca-app-pub-7607380003153721/8021572298";

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
