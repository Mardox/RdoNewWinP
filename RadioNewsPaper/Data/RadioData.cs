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
                                  "Bangla Radio1",
                                  "BANGLA RADIO NEW",
                                  "Bangla Wadio",
                                  "us bangla radio ac richmond ave",
                                  "BANGLA RADIO 2",
                                  "AKTARA | Bangla Online Radio | Kolkata | Dhaka",
                                  "Radio Mainamati",
                                  "My Bangla Gaan",
                              };
        string[] radioUrl = {
                                "http://202.51.191.123:8000",
                                "http://182.160.99.234:8182",
                                "http://66.85.136.194:8201",
                                "http://5.133.182.164:3064",
                                "http://182.160.99.237:8010",
                                "http://50.7.98.106:8520",
                                "http://66.85.136.194:7011",
                                "http://69.175.103.230:8000",
                            };

        public string adBanner = "ca-app-pub-7607380003153721/5986435899";
        public string homeInterstitial = "ca-app-pub-7607380003153721/7463169092";
        public string detailInterstitial = "ca-app-pub-7607380003153721/8939902297";

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
