using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forecast_accuracy
{
    public class Accuracies
    {
        public double TemperatureAccuracy { get; set; }
        public double WindSpeedAccuracy { get; set; }
        public double WindDegreeAccuracy { get; set; }
        public double PressureAccuracy { get; set; }
        public double HumidityAccuracy { get; set; }

        public Accuracies(DatabaseWeather actualWeather, DatabaseWeather forecast)
        {
            this.TemperatureAccuracy = CalculateAccuracy(actualWeather.Temperature, forecast.Temperature);
            this.WindSpeedAccuracy = CalculateAccuracy(actualWeather.WindSpeed, forecast.WindSpeed);
            this.WindDegreeAccuracy = CalculateAccuracy(actualWeather.WindDegree, forecast.WindDegree);
            this.PressureAccuracy = CalculateAccuracy(actualWeather.Pressure, forecast.Pressure);
            this.HumidityAccuracy = CalculateAccuracy(actualWeather.Humidity, forecast.Humidity);
        }

        private double CalculateAccuracy(double actual, double forecast)
        {
            var result = 1 - (forecast / actual);
            return Math.Round(Math.Abs(result), 2);
        }
    }
}
