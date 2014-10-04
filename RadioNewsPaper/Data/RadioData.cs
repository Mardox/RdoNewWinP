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
                                  "HIGHLIFE RADIO - GHANA",
                                  "SANKOFA RADIO - Ghana and Africa's #1",
                                  "GH Radio 1Real Music Power",
                                  "Ghana Music Radio - Africa's #1",
                                  "NASPARADIO GHANA",
                                  "Hot Digital Radio (Ghana)",
                                  "DFW Ghana Radio"
                              };
        string[] radioUrl = {
                                "http://173.192.205.185:80",
                                "http://192.81.248.192:8068",
                                "http://69.64.41.66:9946",
                                "http://206.190.136.141:3372/Live",
                                "http://74.50.122.103:7702",
                                "http://95.211.60.39:8002/stream.mp3",
                                "http://198.178.123.20:8222"
                            };

        public string adBanner = "ca-app-pub-7607380003153721/4788904298";
        public string homeInterstitial = "ca-app-pub-7607380003153721/6265637496";
        public string detailInterstitial = "ca-app-pub-7607380003153721/7742370691";

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
