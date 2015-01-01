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
                                  "Sahara Radio",
                                  "Radio Dzair Sahara",
                                  "SAHARA TERCINTA",
                                  "Frog Town",
                                  "Radio Dzair"
                              };
        string[] radioUrl = {
                                "http://38.96.148.26:9896",
                                "http://188.165.242.25:8026/stream",
                                "http://199.167.134.163:7044",
                                "http://85.25.73.102:10958",
                                "http://188.165.242.25:8026/stream2"
                            };

        public string adBanner = "ca-app-pub-7607380003153721/9050649092";
        public string homeInterstitial = "ca-app-pub-7607380003153721/1527382296";
        public string detailInterstitial = "ca-app-pub-7607380003153721/3004115497";

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
