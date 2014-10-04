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
                                  "Rajawali Radio - Bandung, Indonesia",
                                  "MUSIK DANGDUT INDONESIA",
                                  "miratsul-anbiya indonesia",
                                  "Radio Arts Indonesia",
                                  "RADIO MARIA INDONESIA",
                                  "Swara Indonesia",
                                  "Radio Pemuda FM  Untuk Indonesia Karena Indonesia",
                                  "Al Ghifari Server Indonesia",
                                  "This is Indonesia NetRadio powered by Indosound dotcom"
                              };
        string[] radioUrl = {
                                "http://125.160.17.86:8014",
                                "http://198.71.90.155:8989",
                                "http://128.199.225.150:8788/stream",
                                "http://50.22.212.205:8138",
                                "http://50.7.181.186:8062",
                                "http://162.217.249.112:8600",
                                "http://199.167.134.163:7014",
                                "http://103.28.148.18:8058",
                                "http://146.185.18.251:8004"
                            };

        public string adBanner = "ca-app-pub-7607380003153721/7602769897";
        public string homeInterstitial = "ca-app-pub-7607380003153721/9079503090";
        public string detailInterstitial = "ca-app-pub-7607380003153721/1556236291";

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
