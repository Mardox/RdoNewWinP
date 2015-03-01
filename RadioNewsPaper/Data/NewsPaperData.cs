using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;

namespace RadioNewsPaper.Data
{
    public static class NewsPaperData
    {

        static List<string> NewsTitles = new List<string>();
        static List<string> NewsUrl = new List<string>();


        static List<ParseObject> newsPapers = new List<ParseObject>();
        async public static Task<int> LoadNewsPaperData()
        {

            var stations = ParseObject.GetQuery("Data").WhereEqualTo("country", "Ghana").WhereEqualTo("type", "News");
            IEnumerable<ParseObject> results = await stations.FindAsync();

            if (results.Count() > 0)
            {

                for (int i = 0; i < results.Count(); i++)
                {
                    ParseObject item = results.ElementAt(i);
                    NewsTitles.Add(item["name"].ToString());
                    NewsUrl.Add(item["data"].ToString());

                    newsPapers.Add(item);
                }

            }
            //else
            //{
            //string[] NewsUrl =   {
            //                     "http://www.ghanaweb.com",
            //                     "http://www.peacefmonline.com/",
            //                     "http://vibeghana.com/",
            //                     "http://www.modernghana.com/",
            //                     "http://www.ghananewsagency.org/",
            //                     "http://www.ghanareview.com/Restyle/"
            //                 };


            //string[] NewsTitles = {
            //                             "Ghana",
            //                             "Peace FM Online",
            //                             "Vibe Ghana",
            //                             "Modern Ghana",
            //                             "Ghana News Agency",
            //                             "Ghana Review International"
            //                         };
            //    return 0;
            //}

            return results.Count();

        }



        public static List<string> returnNewsUrls()
        {
            return NewsUrl;
        }

        public static List<string> returnNewsTitles()
        {
            return NewsTitles;
        }

        public static List<ParseObject> returnPapers()
        {
            return newsPapers;
        }
    }
}
