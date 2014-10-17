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
                                  "Malibuteam",
                                  "Malijet",
                                  "Radio Mali Mlin Dj Baja",
                                  "Bygolly Old Time Radio",
                                  "XFM MALIN",
                                  "RADIO NIETA MALI",
                                  "Radio ARC-EN CIEL MALI",
                                  "Radio STUDIO TABALE MALI",
                              };
        string[] radioUrl = {
                                "http://62.212.132.53:8354",
                                "http://188.165.156.104:5800",
                                "http://50.22.219.97:37683",
                                "http://50.22.223.16:8608",
                                "http://210.1.31.58:8688",
                                "http://192.235.87.113:10882",
                                "http://192.235.87.113:10688",
                                "http://192.235.87.113:10902"
                            };

        public string adBanner = "ca-app-pub-7607380003153721/9099522699";
        public string homeInterstitial = "ca-app-pub-7607380003153721/1576255896";
        public string detailInterstitial = "ca-app-pub-7607380003153721/3052989091";

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
