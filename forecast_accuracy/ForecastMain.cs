using Newtonsoft.Json;

namespace forecast_accuracy
{
    public class ForecastMain : CurrentMain
    {
        public int SeaLevel { get; set; }
        public int GrndLevel { get; set; }
        public double Temp_kf { get; set; }
    }
}