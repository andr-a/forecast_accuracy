using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forecast_accuracy
{
    public class DatabaseWeather
    {
        public DateTime Time { get; set; }
        public int CityId { get; set; }
        public double Temperature { get; set; }
        public double WindSpeed { get; set; }
        public int WindDegree { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public int TMinus { get; set; }

        
        public DatabaseWeather(ApiWeatherObject weatherObject)
        {
            // Konvertiert den Unix Timestamp aus der API in DateTime
            this.Time = DateTimeOffset.FromUnixTimeSeconds(weatherObject.Dt).DateTime;
            this.CityId = weatherObject.Id;
            this.Temperature = weatherObject.Main.Temp;
            this.WindSpeed = weatherObject.Wind.Speed;
            this.WindDegree = weatherObject.Wind.Deg;
            this.Pressure = weatherObject.Main.Pressure;
            this.Humidity = weatherObject.Main.Humidity;
            this.TMinus = 0;
        }

        public DatabaseWeather(ForecastObject forecastObject, int cityId)
        {
            this.Time = DateTimeOffset.FromUnixTimeSeconds(forecastObject.Dt).DateTime;
            this.CityId = cityId;
            this.Temperature = forecastObject.Main.Temp;
            this.WindSpeed = forecastObject.Wind.Speed;
            this.WindDegree = forecastObject.Wind.Deg;
            this.Pressure = forecastObject.Main.Pressure;
            this.Humidity = forecastObject.Main.Humidity;

            var dateOfRequest = DateTime.UtcNow.Date;
            this.TMinus = (this.Time.Date - dateOfRequest).Days;
        }

        // Nicht in Verwendung.
        public DatabaseWeather(ForecastCollection forecastCollection, int index)
        {
            var forecastObject = forecastCollection.List[index];
            this.Time = DateTimeOffset.FromUnixTimeSeconds(forecastObject.Dt).DateTime;
            this.CityId = forecastCollection.City.Id;
            this.Temperature = forecastObject.Main.Temp;
            this.WindSpeed = forecastObject.Wind.Speed;
            this.WindDegree = forecastObject.Wind.Deg;
            this.Pressure = forecastObject.Main.Pressure;
            this.Humidity = forecastObject.Main.Humidity;

            var dateOfRequest = DateTime.UtcNow.Date;
            this.TMinus = (this.Time.Date - dateOfRequest).Days;
        }

    }
}
