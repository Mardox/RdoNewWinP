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
                                  "Radio FM SENEGAL",
                                  "Radio AFRICA 7 SENEGAL",
                                  "NGOR FM From Dakar Senegal",
                                  "RFDI",
                                  "Xamsadine wakhtaan -  Senegal",
                                  "RFM - Powered by SenewebNetworks: RFM DAKAR 94.0 SENEGA",
                              };
        string[] radioUrl = {
                                "http://192.235.87.113:10734",
                                "http://192.235.87.113:10732",
                                "http://67.228.177.153:1067/Live",
                                "http://198.178.123.8:8324",
                                "http://198.178.123.20:7200",
                                "http://173.236.81.218:9002",
                            };

        public string adBanner = "ca-app-pub-7607380003153721/9378724296";
        public string homeInterstitial = "ca-app-pub-7607380003153721/1855457493";
        public string detailInterstitial = "ca-app-pub-7607380003153721/3332190698";

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
