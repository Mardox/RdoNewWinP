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
                                  "XL Radio Gurbani",
                                  "RadioTeenTaal",
                                  "BOMBAY BEATS",
                                  "Khalsa FM",
                                  "Carnatic",
                                  "DeSi-RaDiO",
                                  "MAST FM",
                                  "Akhand Path"
                              };
        string[] radioUrl = {
                                "http://67.228.177.153:8459/Live",
                                "http://195.154.176.33:8000",
                                "http://205.164.35.115:80",
                                "http://198.178.123.8:7798",
                                "http://67.228.150.184:7220",
                                "http://204.45.41.148:80",
                                "http://64.202.98.32:6210",
                                "http://162.221.191.51:9968/akhand"
                            };

        public string adBanner = "ca-app-pub-7607380003153721/4927321894";
        public string homeInterstitial = "ca-app-pub-7607380003153721/6404055094";
        public string detailInterstitial = "ca-app-pub-7607380003153721/7880788291";

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
