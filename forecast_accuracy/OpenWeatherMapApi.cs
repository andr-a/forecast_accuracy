using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace forecast_accuracy
{
    public class OpenWeatherMapApi
    {
        private const string ApiKey = "487cdd963fc6fe3e039d81147780ef10";

        public (DatabaseWeather weather, DatabaseCity city) GetCurrentByName(string city)
        {
            var weatherObject = this.GetApiWeatherByName(city);
            return (new DatabaseWeather(weatherObject), new DatabaseCity(weatherObject));
        }

        public List<DatabaseWeather> GetForecastListByName(string city)
        {
            var forecastCollection = this.GetApiForecastByName(city);
            var forecastList = new List<DatabaseWeather>();

            foreach (var forecastObject in forecastCollection.List)
            {
                var databaseWeather = new DatabaseWeather(forecastObject, forecastCollection.City.Id);
                forecastList.Add(databaseWeather);
            }

            return forecastList;
        }

        static private string BuildWeatherUrl(string city)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?units=metric&q=";
            url = url + city + "&APPID=" + ApiKey;
            Console.WriteLine(url);
            return url;
        }

        static private string BuildForecastUrl(string city)
        {
            string url = "http://api.openweathermap.org/data/2.5/forecast?units=metric&q=";
            url = url + city + "&APPID=" + ApiKey;
            Console.WriteLine(url);
            return url;
        }

        private ApiWeatherObject GetApiWeatherByName(string city)
        {
            var url = BuildWeatherUrl(city);
            var json = new WebClient().DownloadString(url);
            var result = JsonConvert.DeserializeObject<ApiWeatherObject>(json);

            return result;
        }

        private ForecastCollection GetApiForecastByName(string city)
        {
            var url = BuildForecastUrl(city);
            var json = new WebClient().DownloadString(url);
            var result = JsonConvert.DeserializeObject<ForecastCollection>(json);
            return result;
        }

    }
}
