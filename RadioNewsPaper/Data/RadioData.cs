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
                                  "Marathi Radio",
                                  "Radio Schizoid Chillout",
                                  "XL Radio Gurbani",
                                  "RadioTeenTaal",
                                  "BOMBAY BEATS",
                              };
        string[] radioUrl = {
                                "http://208.80.53.106:16704",
                                "http://78.46.73.237:8000/schizoid",
                                "http://67.228.177.153:8459/Live",
                                "http://195.154.176.33:8000",
                                "http://205.164.35.115:80",
                            };

        public string adBanner = "ca-app-pub-7607380003153721/7741187491";
        public string homeInterstitial = "ca-app-pub-7607380003153721/9217920692";
        public string detailInterstitial = "ca-app-pub-7607380003153721/1694653895";

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
