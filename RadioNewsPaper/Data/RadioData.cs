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
                                  "Maxima Fm Honduras",
                                  "Radio Verbo Honduras",
                                  "Radio Station Name: Xtrema Fm Honduras",
                                  "Radio Boqueron",
                                  "Radio Honduras 504  San Pedro Sula",
                                  "LUNA FM HONDURAS",
                                  "Gala Stereo",
                              };
        string[] radioUrl = {
                                "http://listen.radionomy.com/Maxima-Fm-Honduras",
                                "http://200.59.26.125:8000",
                                "http://192.235.87.113:10290",
                                "http://38.96.175.24:8308",
                                "http://216.38.54.82:8504",
                                "http://198.204.232.221:9984",
                                "http://198.24.147.106:9640",
                            };

        public string adBanner = "ca-app-pub-7607380003153721/2913388291";
        public string homeInterstitial = "ca-app-pub-7607380003153721/4390121493";
        public string detailInterstitial = "ca-app-pub-7607380003153721/5866854698";

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
