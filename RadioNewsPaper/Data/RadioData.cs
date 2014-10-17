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
                                  "DJFM Ukraine",
                                  "MiX FM Ukraine",
                                  "RADIO MARIA UKRAINE",
                                  "Filadelfia MD",
                              };
        string[] radioUrl = {
                                "http://217.20.164.163:8010",
                                "http://195.189.227.16:8192",
                                "http://50.7.181.186:8022",
                                "http://77.92.76.190:8750",
                            };

        public string adBanner = "ca-app-pub-7607380003153721/3192589891";
        public string homeInterstitial = "ca-app-pub-7607380003153721/4669323093";
        public string detailInterstitial = "ca-app-pub-7607380003153721/6146056297";

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
