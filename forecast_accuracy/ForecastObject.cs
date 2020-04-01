using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forecast_accuracy
{
    public class ForecastObject
    {
        public int Dt { get; set; }
        public ForecastMain Main { get; set; }
        public List<Weather> Weather { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public Rain Rain { get; set; } = new Rain(); // Kein Regen -> "default" Objekt mit wert 0
        public ForecastSys Sys { get; set; } // Testen ob es ohne funktioniert
        public DateTime Dt_text { get; set; } // In JSON als String im Format "YYYY-MM-DD hh:mm:ss"
    }
}
