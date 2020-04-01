using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace forecast_accuracy
{
    public class Api
    {
        private const string ApiKey = "***REMOVED***";

        static private string BuildWeatherUrl(string city)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=";
            url = url + city + "&APPID=" + ApiKey;
            Console.WriteLine(url);
            return url;
        }

        static private string BuildForecastUrl(string city)
        {
            string url = "http://api.openweathermap.org/data/2.5/forecast?q=";
            url = url + city + "&APPID=" + ApiKey;
            Console.WriteLine(url);
            return url;
        }

        public WeatherObject GetWeatherByName(string city)
        {
            var url = BuildWeatherUrl(city);
            var json = new WebClient().DownloadString(url);
            var result = JsonConvert.DeserializeObject<WeatherObject>(json);

            return result;
        }

        public ForecastCollection GetForecastByName(string city)
        {
            var url = BuildForecastUrl(city);
            var json = new WebClient().DownloadString(url);
            var result = JsonConvert.DeserializeObject<ForecastCollection>(json);
            return result;
        }
    }
}
