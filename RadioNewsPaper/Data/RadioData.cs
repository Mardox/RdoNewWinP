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
                                  "Radio Latina",
                                  "DB9000-TX",
                                  "La Radio Latina - Memphis",
                                  "Radio Latina Amor",
                                  "Radio Latina Mix Internactional",
                                  "Radio Latina Canada",
                              };
        string[] radioUrl = {
                                "http://178.32.136.9:9097",
                                "http://207.210.201.56:8000",
                                "http://174.37.16.73:1209/Live",
                                "http://198.154.112.233:8328",
                                "http://162.217.125.32:8102",
                                "http://69.64.52.74:7042",
                            };

        public string adBanner = "ca-app-pub-7607380003153721/7881971499";
        public string homeInterstitial = "ca-app-pub-7607380003153721/9358704694";
        public string detailInterstitial = "ca-app-pub-7607380003153721/1835437890";

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
