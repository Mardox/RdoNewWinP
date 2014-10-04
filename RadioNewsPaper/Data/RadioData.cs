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
                                  "Ambiance Brasil",
                                  "AMIGAFMSTEREO",
                                  "Deejays in Company Brazil",
                                  "RADIO KUARUP",
                                  "RADIO ARYSTA BRASIL",
                                  "CyberFM Brazil",
                                  "PsyBraziL Entertainment Network",
                                  "Picuaia Internacional - DJ Paulinho Cerqueira - Salvador - Bahia",
                                  "Radio Mais Brazil (Newark)"
                              };
        string[] radioUrl = {
                                "http://listen.radionomy.com/Ambiance-Brasil",
                                "http://listen.radionomy.com/AMIGAFMSTEREO",
                                "http://179.185.108.41:7979",
                                "http://69.64.33.245:8048",
                                "http://85.25.16.7:8058",
                                "http://23.88.105.31:8092",
                                "http://189.124.18.19:8000",
                                "http://87.117.208.118:23125",
                                "http://68.197.250.211:8000"
                            };

        public string adBanner = "ca-app-pub-7607380003153721/1695837091";
        public string homeInterstitial = "ca-app-pub-7607380003153721/3172570297";
        public string detailInterstitial = "ca-app-pub-7607380003153721/4649303498";

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
