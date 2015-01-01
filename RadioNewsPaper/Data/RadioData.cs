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
                                  "RADIO MARIA TOGO",
                                  "Radio Degnigban",
                                  "RADIO MERVEILLE Togo",
                                  "TOGO LIBRE",
                                  "RADIO TOGO KTO",
                                  "PROTOGON HARDSTYLE ",
                                  "Radio LOME TOGO"
                              };
        string[] radioUrl = {
                                "http://50.7.181.186:8050",
                                "http://198.27.80.37:5546/stream",
                                "http://174.123.20.131:8240",
                                "http://192.235.87.113:10720",
                                "http://listen.radionomy.com/RADIOTOGOKTO",
                                "http://37.59.20.121:8002/test.aac",
                                "http://192.235.87.113:11560"
                            };

        public string adBanner = "ca-app-pub-7607380003153721/8389671091";
        public string homeInterstitial = "ca-app-pub-7607380003153721/9866404295";
        public string detailInterstitial = "ca-app-pub-7607380003153721/2343137494";

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
