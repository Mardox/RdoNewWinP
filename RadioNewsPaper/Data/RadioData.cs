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
                                "http://114.130.45.114:1021",
                                "http://live.abcradiobd.fm:8282",
                                "http://220.247.162.146:7170",
                                "http://radiovoice24.com:7015",
                                "http://118.179.219.243:8000",
                                "http://live.peoplesradio.fm:9160",
                                "http://184.107.144.218:8240",
                                "http://202.51.191.123:8000",
                                "http://184.172.165.195:8201"
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
