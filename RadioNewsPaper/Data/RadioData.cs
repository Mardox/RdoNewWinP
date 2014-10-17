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
                                  "RADIO MARIA ARGENTINA",
                                  "ARGENTINA ROCK & POP",
                                  "Radio Cristal Villa Union La Rioja Argentina",
                                  "Argentina Streamingcom",
                                  "Radio De Dios Eben-Ezer Argentina",
                                  "Radio Taller 105.3 'Nuestra Seora de Lourdes' - Santa Fe (Capital) Santa Fe - Repblica Argentina",
                                  "Argentina Flow",
                                  "Radio Nueva Argentina 89.9 Mhz.",
                                  "Radio Cyber Carlos Paz - Argentina",
                              };
        string[] radioUrl = {
                                "http://50.7.181.186:8004",
                                "http://67.228.177.215:9988",
                                "http://186.153.160.226:8000",
                                "http://174.142.39.158:9988",
                                "http://184.107.179.162:3566",
                                "http://74.222.5.162:7996",
                                "http://50.7.70.42:7175",
                                "http://190.104.217.181:9804",
                                "http://78.129.163.73:16307",
                            };

        public string adBanner = "ca-app-pub-7607380003153721/1995058298";
        public string homeInterstitial = "ca-app-pub-7607380003153721/4948524692";
        public string detailInterstitial = "ca-app-pub-7607380003153721/6425257896";

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
