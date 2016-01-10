using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

// This class will need to use http://stackoverflow.com/a/28908704 to fetch the location on first startup and save it.

namespace WeatherWallpaper
{
    class Location
    {
        private static object latLong { get; set; }
        public static object getLocation()
        {
            // Store the location in a static object named latLong so that we only make one location call
            // per program execution.
            if(latLong == null)
            {
                WebClient webClient = new WebClient();
                dynamic result = Json.Decode(webClient.DownloadString("http://ipinfo.io"));
                string[] tmp = result.loc.Split(',');
                latLong = new { Latitude = tmp[0], Longitude = tmp[1] };
            }
            return latLong;
        }
    }
}
