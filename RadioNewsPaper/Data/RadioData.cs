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
                                  "RADIO MARIA PERU",
                                  "Radio Rakuen Peru",
                                  "Radio Nacional del Peru",
                                  "Radio Sensacion Peru - Chosica",
                                  "RADIO ELITE 104.1 FM - HUARAL - PERU",
                                  "Turbo radio online - radio en vivo - lima  peru",
                                  "Radio Cambia Peru",
                                  "RADIO NUEVO MUNDO - PERU"
                              };
        string[] radioUrl = {
                                "http://50.7.181.186:8074",
                                "http://67.212.165.162:7018",
                                "http://190.223.63.71:6524",
                                "http://184.107.179.162:9020",
                                "http://96.127.138.18:9998",
                                "http://198.245.63.66:7206",
                                "http://50.30.37.112:8000/test.acc",
                                "http://67.212.179.138:7130"
                            };

        public string adBanner = "ca-app-pub-7607380003153721/6285657091";
        public string homeInterstitial = "ca-app-pub-7607380003153721/7762390293";
        public string detailInterstitial = "ca-app-pub-7607380003153721/9239123490";

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
