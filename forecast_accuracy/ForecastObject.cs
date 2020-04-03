using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forecast_accuracy
{
    public class ForecastObject
    {
        // Unix Timestamp
        public long Dt { get; set; }
        public ForecastMain Main { get; set; }
        public List<Weather> Weather { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        // Kein Regen -> "default" Objekt mit wert 0
        public Rain Rain { get; set; } = new Rain();
        public ForecastSys Sys { get; set; } // Testen ob es ohne funktioniert
        // In JSON als String im Format "YYYY-MM-DD hh:mm:ss"
        public DateTime Dt_text { get; set; }
    }
}
