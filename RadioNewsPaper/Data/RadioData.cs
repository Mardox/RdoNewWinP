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
                                  "RFDI",
                                  "Radio Jet7 Angola",
                                  "Media d'Afrique",
                                  "Rdio Marimba",
                                  "RADIO DORILAND KIDS",
                                  "Radio Gospel Angola",
                                  "Ministerio Shalom"
                              };
        string[] radioUrl = {
                                "http://198.178.123.8:8324",
                                "http://50.7.77.179:8090",
                                "http://195.154.240.161:8022",
                                "http://192.184.9.79:8094",
                                "http://85.25.16.7:8070",
                                "http://78.129.163.73:21877",
                                "http://209.105.232.220:8256"
                            };

        public string adBanner = "ca-app-pub-7607380003153721/4760050292";
        public string homeInterstitial = "ca-app-pub-7607380003153721/6236783496";
        public string detailInterstitial = "ca-app-pub-7607380003153721/7713516692";

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
