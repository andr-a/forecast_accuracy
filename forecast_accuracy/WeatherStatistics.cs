using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forecast_accuracy
{
    public class WeatherStatistics
    {
        public DatabaseWeather Forecast { get; set; }
        public Accuracies Accuracies { get; set; }

        public WeatherStatistics(DatabaseWeather actualWeather, DatabaseWeather forecast)
        {
            this.Forecast = forecast;
            this.Accuracies = new Accuracies(actualWeather, forecast);
        }
    }

}
