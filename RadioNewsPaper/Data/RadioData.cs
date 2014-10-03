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
                                  "Sit-mexico Radio",
                                  "Rock X Mexico Radio (Cabina 1)",
                                  "RADIO MARIA MEXICO",
                                  "XHBIO - FIESTA MEXICANA - Grupo Promomedios Radio. Guadalajara, Jalisco, Mexico.",
                                  "Que Viva Mexico",
                                  "Salsa Mexico HD",
                                  "La Radio Cristiana Mexico"
                              };
        string[] radioUrl = {
                                "http://85.17.30.50:9666",
                                "http://72.29.70.19:8162",
                                "http://50.7.181.186:8086",
                                "http://189.205.46.150:8116",
                                "http://listen.radionomy.com/QueVivaMexico",
                                "http://199.217.118.10:7218",
                                "http://listen.radionomy.com/LaRadioCristianaMexico"
                            };

        public string adBanner = "ca-app-pub-7607380003153721/1975038693";
        public string homeInterstitial = "ca-app-pub-7607380003153721/3451771894";
        public string detailInterstitial = "ca-app-pub-7607380003153721/4928505091";

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
