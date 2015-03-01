using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;
using System.Collections.Generic;

namespace RadioNewsPaper.Data
{
    public static class RadioData
    {

         static List<string> radioTitle = new List<string>();
         static List<string> radioUrl = new List<string>();

         static List<ParseObject> radioStations = new List<ParseObject>();

        //public RadioData()
        //{
        //    LoadRadioData();
        //}

        async public static Task<int> LoadRadioData()
        {

            var stations = ParseObject.GetQuery("Data").WhereEqualTo("country", "Ghana").WhereEqualTo("type", "Radio");
            IEnumerable<ParseObject> results = await stations.FindAsync();

            if (results.Count() > 0)
            {

                for (int i = 0; i < results.Count(); i++)
                {
                    ParseObject item = results.ElementAt(i);
                    radioTitle.Add(item["name"].ToString());
                    radioUrl.Add(item["data"].ToString());

                    radioStations.Add(item);
                }
               
            }
            //else
            //{
            //    string[] radioTitle = {
            //                      "HIGHLIFE RADIO - GHANA",
            //                      "SANKOFA RADIO - Ghana and Africa's #1",
            //                      "GH Radio 1Real Music Power",
            //                      "Ghana Music Radio - Africa's #1",
            //                      "NASPARADIO GHANA",
            //                      "Hot Digital Radio (Ghana)",
            //                      "DFW Ghana Radio"
            //                  };

            //    string[] radioUrl = {
            //                    "http://173.192.205.185:80",
            //                    "http://192.81.248.192:8068",
            //                    "http://69.64.41.66:9946",
            //                    "http://206.190.136.141:3372/Live",
            //                    "http://74.50.122.103:7702",
            //                    "http://95.211.60.39:8002/stream.mp3",
            //                    "http://198.178.123.20:8222"
            //                };
            //    return 0;
            //}

            return results.Count();
          
        }

       
       

        public static string adBanner = "ca-app-pub-7607380003153721/4788904298";
        public static string homeInterstitial = "ca-app-pub-7607380003153721/6265637496";
        public static string detailInterstitial = "ca-app-pub-7607380003153721/7742370691";

        public static List<string> returnTitle()
        {
            return radioTitle;
        }

        public static List<string> returnUrl()
        {
            return radioUrl;
        }

        public static List<ParseObject> returnStations()
        {
            return radioStations;
        }

    }
}
