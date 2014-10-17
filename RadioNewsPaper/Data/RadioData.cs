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
                                  "Top Albania Radio",
                                  "RADIO MARIA ALBANIA",
                                  "CityFM Radio Albania",
                                  "Radio 7 Albania",
                                  "Albania FM",
                                  "Quran in Albanian by EDC",
                                  "LAR : London Albanian Radio",
                                  "Radio EnergyFM Albania - Shqip"
                              };
        string[] radioUrl = {
                                "http://66.55.93.205:9078",
                                "http://50.7.181.186:8008",
                                "http://206.190.136.141:2872/Live",
                                "http://50.117.8.242:5664/Live",
                                "http://87.98.216.129:9812",
                                "http://37.58.72.235:9996",
                                "http://50.7.184.106:8701",
                                "http://78.46.52.186:18122"
                            };

        public string adBanner = "ca-app-pub-7607380003153721/5587653092";
        public string homeInterstitial = "ca-app-pub-7607380003153721/7064386297";
        public string detailInterstitial = "ca-app-pub-7607380003153721/8541119493";

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
