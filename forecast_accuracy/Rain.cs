using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forecast_accuracy
{
    public class Rain
    {
        [JsonProperty("1h")]
        public double RainMm { get; set; } = -1; // 1h bei Current
        [JsonProperty("3h")]
        public double Rain3h { set { RainMm = value; } } // 3h bei Forecast
    }
}
