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
        public const string ApiKey = "***REMOVED***";
        public string cityName = "Zehdenick";

        public Form1()
        {
            InitializeComponent();

            Main();
        }

        public void Main()
        {
            var api = new OpenWeatherMapApi();
            var db = new Database();

            (var current, var city) = api.GetCurrentByName(cityName);
            var forecastList = api.GetForecastListByName(cityName);
            Console.WriteLine(current.TMinus);
            Console.WriteLine(city.Name);
            db.WriteCity(city);
            db.WriteActual(current);
            db.WriteForecastList(forecastList);
        }

    }
}
