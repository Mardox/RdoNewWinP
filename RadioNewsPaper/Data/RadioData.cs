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
                                  "FM 1",
                                  "FM 2",
                                  "FM 3",
                                  "FM 4",
                                  "FM 5",
                                  "FM 6",
                                  "FM 7",
                                  "FM 8",
                                  "FM 9",
                              };
        string[] radioUrl = {
                                "url 1",
                                "url 2",
                                "url 3",
                                "url 4",
                                "url 5",
                                "url 6",
                                "url 7",
                                "url 8",
                                "url 9",
                            };

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
