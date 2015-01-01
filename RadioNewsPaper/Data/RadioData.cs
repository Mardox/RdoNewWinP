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
                                  "RADIO MARIA UGANDA",
                                  "Radio Uganda Boston",
                                  "Yo Voice &  Beyond",
                                  "Ssuubi FM",
                                  "Kubutaka Radio"
                              };
        string[] radioUrl = {
                                "http://50.7.181.186:8052",
                                "http://50.7.70.58:8651",
                                "http://50.7.70.58:8653",
                                "http://50.22.212.195:8181",
                                "http://198.178.123.5:8756"
                            };

        public string adBanner = "ca-app-pub-7607380003153721/1666983093";
        public string homeInterstitial = "ca-app-pub-7607380003153721/3143716297";
        public string detailInterstitial = "ca-app-pub-7607380003153721/4620449492";

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
