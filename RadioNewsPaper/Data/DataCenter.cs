﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;
using System.Collections.Generic;
using RadioNewsPaper.Resources;

namespace RadioNewsPaper.Data
{
    public static class DataCenter
    {

         static List<string> radioTitle = new List<string>();
         static List<string> radioUrl = new List<string>();

         static List<ParseObject> radioStations = new List<ParseObject>();
         static List<ParseObject> newsPapers = new List<ParseObject>();


        async public static Task<int> LoadData()
        {

            var stations = ParseObject.GetQuery("Data").WhereEqualTo("country", AppResources.Country);
            IEnumerable<ParseObject> results = await stations.FindAsync();

            if (results.Count() > 0)
            {

                for (int i = 0; i < results.Count(); i++)
                {
                    ParseObject item = results.ElementAt(i);

                    if (item["type"].ToString() == "Radio")
                    {
                        radioStations.Add(item);
                    }
                    else if (item["type"].ToString() == "News")
                    {
                        newsPapers.Add(item);
                    }
                 
                }

            }

            return results.Count();

        }
       

        //public static string adBanner = "ca-app-pub-7607380003153721/4788904298";
        //public static string homeInterstitial = "ca-app-pub-7607380003153721/6265637496";
        //public static string detailInterstitial = "ca-app-pub-7607380003153721/7742370691";

        public static string homeInterstitial = AppResources.AdmobIntrestitialHome;
        public static string detailInterstitial = AppResources.AdmobIntrestitialDetail;

        public static List<ParseObject> returnStations()
        {
            return radioStations;
        }

        public static List<ParseObject> returnPapers()
        {
            return newsPapers;
        }
    }
}