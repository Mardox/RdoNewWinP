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
                                  "Magic FM",
                                  "Radiounoplus",
                                  "The Office",
                                  "Rock 181",
                                  "181.FM",
                                  "#MUSIK.MAIN",
                                  "ChartHits.FM ",
                                  "Radio Jat",
                                  "Rock FM Romania",
                                  "Narodni radio"
                              };
        string[] radioUrl = {
                                "http://80.86.106.35:7070",
                                "http://listen.radionomy.com/radiounoplus",
                                "http://108.61.73.119:14002",
                                "http://108.61.73.119:8008",
                                "http://108.61.73.119:14046",
                                "http://193.34.51.10:80",
                                "http://95.141.24.155:80",
                                "http://95.140.115.227:12111",
                                "http://80.86.106.35:8064",
                                "http://173.192.137.34:9498"
                            };

        public string adBanner = "ca-app-pub-7607380003153721/1415452295";
        public string homeInterstitial = "ca-app-pub-7607380003153721/2892185492";
        public string detailInterstitial = "ca-app-pub-7607380003153721/4368918695";

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
