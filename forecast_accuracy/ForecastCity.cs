using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forecast_accuracy
{
    public class ForecastCity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coord Coord { get; set; }
        public string Country { get; set; }
        public int Popuplation { get; set; }
        public int Timezone { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }
}
