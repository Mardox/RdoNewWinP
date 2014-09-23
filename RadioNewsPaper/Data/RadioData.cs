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
                              };
        string[] radioUrl = {
                                "http://208.80.53.106:16704",
                                "http://78.46.73.237:8000/schizoid",
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
