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
        readonly OpenWeatherMapApi api = new OpenWeatherMapApi();
        static readonly Database db = new Database();
        DataTable cityDataTable = new DataTable();
        DataTable forecastDataTable = new DataTable();
        int selectedCityId;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateCityListbox();
        }

        public void PopulateCityListbox()
        {
            db.GetCityDataTable(ref cityDataTable);
            lbxCities.DataSource = cityDataTable;
            lbxCities.DisplayMember = "name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //db.GetCityDataTable(ref cityDataTable

            var forecastList = db.GetForecastListById(selectedCityId);
            forecastDataTable = Helper.ConvertToDataTable(forecastList);
            PopulateDataGridViewForeCasts();
        }

        private void lbxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxCities.SelectedIndex > -1)
            {
                var index = lbxCities.SelectedIndex;
                var city = cityDataTable.Rows[index];

                selectedCityId = (int)city["id"];

                labelNameValue.Text = city["name"].ToString();
                labelIdValue.Text = city["id"].ToString();
                labelCountryValue.Text = city["country_iso"].ToString();
                labelTimzoneShiftValue.Text = city["timezone_shift"].ToString();

                textBoxCity.Text = city["name"].ToString();

                (var weather, _) = api.GetCurrentByName(city["name"].ToString());

                if (weather != null)
                {
                    labelTimeValue.Text = weather.TimeOfWeather.ToString("yyyy-MM-dd HH:mm:ss");
                    labelTemperatureValue.Text = weather.Temperature.ToString();
                    labelWindSpeedValue.Text = weather.WindSpeed.ToString();
                    labelWindDegreeValue.Text = weather.WindDegree.ToString();
                    labelPressureValue.Text = weather.Pressure.ToString();
                    labelHumidityValue.Text = weather.Humidity.ToString();
                    db.WriteActual(weather);

                    //db.GetForecastDataTable(ref forecastDataTable, weather.CityId);

                    var forecastList = api.GetForecastListByName(city["name"].ToString());
                    forecastDataTable = Helper.ConvertToDataTable(forecastList);
                    PopulateDataGridViewForeCasts();
                }
            }
        }

        public void PopulateDataGridViewForeCasts()
        {
            dataGridViewForecasts.DataSource = null;

            dataGridViewForecasts.DataSource = forecastDataTable;
            dataGridViewForecasts.DataMember = forecastDataTable.TableName;
            dataGridViewForecasts.Columns.Remove("TimeOfCalculation");
            dataGridViewForecasts.Columns.Remove("CityId");
            dataGridViewForecasts.AutoResizeColumns();
            foreach (DataGridViewColumn column in dataGridViewForecasts.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (column.ValueType == typeof(DateTime))
                {
                    column.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }
            }
        }

        private void buttonUpdateForecasts_Click(object sender, EventArgs e)
        {
            var forecastList = new List<DatabaseWeather>();
            foreach (DataRow row in cityDataTable.Rows)
            {
                var city = row["name"].ToString();
                var forecast = api.GetForecastListByName(city);
                if (forecast != null)
                {
                forecastList.AddRange(forecast);
                }
            }
            if (forecastList.Count > 0)
            {
                db.WriteForecastList(forecastList);
            }
        }

        private void buttonAddCity_Click(object sender, EventArgs e)
        {
            var cityName = textBoxCity.Text;
            (_, var city) = api.GetCurrentByName(cityName);
            if (city != null)
            {
            db.WriteCity(city);
            }
            db.GetCityDataTable(ref cityDataTable);
        }

        private void buttonSuspendCity_Click(object sender, EventArgs e)
        {
            string cityName = lbxCities.GetItemText(lbxCities.SelectedItem);
            db.SuspendCity(cityName);
            db.GetCityDataTable(ref cityDataTable);
        }
    }
}
