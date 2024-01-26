using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApplication.Constants
{
    internal class UrlConstan//todo parametirleri appsettingden oxumaga calis
    {
        public const string BaseUrl = "https://api.weatherapi.com/v1/forecast.json?q=";

        //https://api.weatherapi.com/v1/current.json?q=Baku&key=0824de2a00c44659967151735242601

        public static string GetMyUrl(Location location, (string lang, string day) info)
        {                               //simal-cenub         //serq-qerb
            return $"{BaseUrl}{location.Latitude}%2C{location.Longitude}&days={info.day}&lang={info.lang}&key={ApiKey.Key}";
        }
       
    }

    internal class ApiKey
    {
        public const string Key = "0824de2a00c44659967151735242601";
    }
}
