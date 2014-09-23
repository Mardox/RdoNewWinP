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
                                  "Apna eRadio",
                                  "Apna Classic",
                                  "Pakistan Radio",
                                  "Radio Pak",
                                  "DeSi-RaDiO",
                              };
        string[] radioUrl = {
                                "http://209.62.54.34:8000",
                                "http://209.62.54.34:8300",
                                "http://listen.radionomy.com/pakistanradio",
                                "http://50.7.77.178:8412",
                                "http://204.45.41.148:80",
                            };

        public string adBanner = "ca-app-pub-7607380003153721/1834254690";
        public string homeInterstitial = "ca-app-pub-7607380003153721/3310987893";
        public string detailInterstitial = "ca-app-pub-7607380003153721/4787721090";

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
