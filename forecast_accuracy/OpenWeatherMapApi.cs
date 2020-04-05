using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace forecast_accuracy
{
    public class OpenWeatherMapApi
    {
        private const string ApiKey = "487cdd963fc6fe3e039d81147780ef10";

        public (DatabaseWeather weather, DatabaseCity city) GetCurrentByName(string city)
        {
            var apiWeatherObject = this.GetApiWeatherByName(city);
            if (apiWeatherObject != null && apiWeatherObject.Cod == 200)
                return (new DatabaseWeather(apiWeatherObject), new DatabaseCity(apiWeatherObject));
            return (null, null);
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
            //Console.WriteLine(url);
            return url;
        }

        static private string BuildForecastUrl(string city)
        {
            string url = "http://api.openweathermap.org/data/2.5/forecast?units=metric&q=";
            url = url + city + "&APPID=" + ApiKey;
            //Console.WriteLine(url);
            return url;
        }

        private ApiWeatherObject GetApiWeatherByName(string city)
        {
            var url = BuildWeatherUrl(city);
            var client = new WebClient();

            try
            {
                var json = client.DownloadString(url);
                var result = JsonConvert.DeserializeObject<ApiWeatherObject>(json);
                return result;
            }
            catch (WebException ex)
            {
                MessageBox.Show("GetApiWeatherByName:\n\n" + ex.Message);
                Console.WriteLine("!");
                return null;
            }
        }

        private ForecastCollection GetApiForecastByName(string city)
        {
            var url = BuildForecastUrl(city);
            var client = new WebClient();
            try
            {
                var json = client.DownloadString(url);
                var result = JsonConvert.DeserializeObject<ForecastCollection>(json);
                return result;
            }
            catch (WebException ex)
            {
                MessageBox.Show("GetApiForecastByName:\n\n" + ex.Message);
                return null;
            }
            
        }

    }
}
