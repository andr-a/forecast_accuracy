using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace forecast_accuracy
{
    public class ForecastCollection
    {
        public int Cod { get; set; }
        public int Message { get; set; }
        public int Cnt { get; set; }
        public List<ForecastObject> List { get; set; }
        public ForecastCity City { get; set; }
    }
}
