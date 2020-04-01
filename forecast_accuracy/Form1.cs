using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;

namespace forecast_accuracy
{
    public partial class Form1 : Form
    {
        public const string ApiKey = "487cdd963fc6fe3e039d81147780ef10";
        public string city = "tokyo";

        public Form1()
        {
            InitializeComponent();
            var api = new Api();

            var weather = api.GetWeatherByName(city);
            Console.WriteLine(weather.Rain.RainMm);
            var foreCast = api.GetForecastByName(city);
            Console.WriteLine("Forecast: " + foreCast.List[34].Rain.RainMm);
        }



    }
}
