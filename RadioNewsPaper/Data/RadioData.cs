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
                                  "DJ Zone - Snimkata Na No6tta - Kanal KOM - Plovdiv, Bulgaria",
                                  "Bulgarian Christian Radio",
                              };
        string[] radioUrl = {
                                "http://80.83.123.210:9986",
                                "http://176.31.111.65:8126",
                            };

        public string adBanner = "ca-app-pub-7607380003153721/6454963891";
        public string homeInterstitial = "ca-app-pub-7607380003153721/7931697098";
        public string detailInterstitial = "ca-app-pub-7607380003153721/9408430299";

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
