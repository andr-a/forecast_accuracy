using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forecast_accuracy
{
    public class DatabaseWeather
    {
        // Actual/Current -> Zeitpunkt der Berechnung gerundet auf die jede dritte Stunde, Forecast -> vorhergesagte Zeit.
        public DateTime TimeOfWeather { get; set; }
        // Actual/Current -> Zeitpunkt der Berechnung, Forecast -> Zeitpunkt der Abfrage gerundet auf jeden Tag.
        public DateTime TimeOfCalculation { get; set; }
        public int CityId { get; set; }
        public double Temperature { get; set; }
        public double WindSpeed { get; set; }
        public int WindDegree { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }

        // Datenbank actual und forecast.
        public DatabaseWeather(DateTime timeOfWeather, DateTime timeOfCalculation, int cityId, double temperature, double windSpeed, int windDegree, int pressure, int humidty)
        {
            this.TimeOfWeather = timeOfWeather;
            this.TimeOfCalculation = timeOfCalculation;
            this.CityId = cityId;
            this.Temperature = temperature;
            this.WindSpeed = windSpeed;
            this.WindDegree = windDegree;
            this.Pressure = pressure;
            this.Humidity = humidty;
        }

        // API Current Weather.
        public DatabaseWeather(ApiWeatherObject weatherObject)
        {
            // Konvertiert den Unix Timestamp aus der API in DateTime
            this.TimeOfCalculation = DateTimeOffset.FromUnixTimeSeconds(weatherObject.Dt).DateTime;

            this.TimeOfWeather = Helper.RoundDateTimeToHours(this.TimeOfCalculation, 3);

            this.CityId = weatherObject.Id;
            this.Temperature = weatherObject.Main.Temp;
            this.WindSpeed = weatherObject.Wind.Speed;
            this.WindDegree = weatherObject.Wind.Deg;
            this.Pressure = weatherObject.Main.Pressure;
            this.Humidity = weatherObject.Main.Humidity;
        }

        // API Forecast.
        public DatabaseWeather(ForecastObject forecastObject, int cityId)
        {
            this.TimeOfWeather = DateTimeOffset.FromUnixTimeSeconds(forecastObject.Dt).DateTime;

            //this.TimeOfCalculation = Helper.RoundDateTimeToHours(DateTime.UtcNow.Date, 24);
            this.TimeOfCalculation = Helper.RoundTimeOfForecast(this.TimeOfWeather, DateTime.UtcNow);

            this.CityId = cityId;
            this.Temperature = forecastObject.Main.Temp;
            this.WindSpeed = forecastObject.Wind.Speed;
            this.WindDegree = forecastObject.Wind.Deg;
            this.Pressure = forecastObject.Main.Pressure;
            this.Humidity = forecastObject.Main.Humidity;
        }
    }
}
