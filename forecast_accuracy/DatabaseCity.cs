using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forecast_accuracy
{
    public class DatabaseCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }
        public int TimezoneShift { get; set; }

        public DatabaseCity(ApiWeatherObject weatherObject)
        {
            this.Id = weatherObject.Id;
            this.Name = weatherObject.Name;
            this.CountryIso = weatherObject.Sys.Country;
            this.TimezoneShift = weatherObject.Timezone;
        }

        public DatabaseCity(ForecastCollection forecastCollection)
        {
            this.Id = forecastCollection.City.Id;
            this.Name = forecastCollection.City.Name;
            this.CountryIso = forecastCollection.City.Country;
            this.TimezoneShift = forecastCollection.City.Timezone;
        }
    }
}
