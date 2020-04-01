using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forecast_accuracy
{
    public class WeatherObject
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        public CurrentMain Main { get; set; }
        public int Visibilty { get; set; }
        public Wind Wind { get; set; }
        public Rain Rain { get; set; } = new Rain(); // Kein Regen -> "default" Objekt mit wert 0
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public CurrentSys Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
