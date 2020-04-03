using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forecast_accuracy
{
    public class ApiWeatherObject
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        public CurrentMain Main { get; set; }
        public int Visibilty { get; set; }
        public Wind Wind { get; set; }
        // Kein Regen -> "default" Objekt mit wert 0
        public Rain Rain { get; set; } = new Rain();
        public Clouds Clouds { get; set; }
        // Zeit der Datenberechnung als Unix Timestamp
        public long Dt { get; set; }
        public CurrentSys Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}
