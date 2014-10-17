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
                                  "Philippines Ofw_HomeRadio",
                                  "Atlantis Radio Philippines | Pinoy Radio | Pure Pop Love Songs",
                                  "Hope 777 Radio Philippines",
                                  "Kfm Philippines",
                                  "The Edge Philippines ",
                                  "CyberPinoy Radio Philippines",
                                  "Red Planet Radio Stations | Philippines Radio",
                                  "V-Hive Radio Philippines - The hottest pinoy radio station - filipino",
                              };
        string[] radioUrl = {
                                "http://206.190.131.100:9910",
                                "http://184.107.128.20:8000",
                                "http://206.190.131.100:9896",
                                "http://206.190.131.100:9872",
                                "http://46.105.125.110:9432",
                                "http://85.25.109.132:8002",
                                "http://184.107.128.20:8888",
                                "http://192.99.8.192:3154/vhiveradiostream"
                            };

        public string adBanner = "ca-app-pub-7607380003153721/6006455497";
        public string homeInterstitial = "ca-app-pub-7607380003153721/7483188690";
        public string detailInterstitial = "ca-app-pub-7607380003153721/8959921893";

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
