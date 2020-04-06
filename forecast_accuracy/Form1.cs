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
        List<DatabaseWeather> weatherList;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            SetUpTimeSelection();
            PopulateCityListbox();
        }

        public void PopulateCityListbox()
        {
            db.GetCityDataTable(ref cityDataTable);
            lbxCities.DataSource = cityDataTable;
            lbxCities.DisplayMember = "name";
        }

        private void buttonHistoricalForecasts_Click(object sender, EventArgs e)
        {
            var forecastList = db.GetForecastListById(selectedCityId);
            forecastDataTable = Helper.ConvertToDataTable(forecastList);
            PopulateDataGridViewWeather();
        }

        private void lbxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonShowStatistics.Enabled = false;

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
                    labelTimeValue.Text = weather.TimeOfCalculation.ToString("yyyy-MM-dd HH:mm:ss");
                    labelTemperatureValue.Text = weather.Temperature.ToString();
                    labelWindSpeedValue.Text = weather.WindSpeed.ToString();
                    labelWindDegreeValue.Text = weather.WindDegree.ToString();
                    labelPressureValue.Text = weather.Pressure.ToString();
                    labelHumidityValue.Text = weather.Humidity.ToString();
                    db.WriteActual(weather);

                    var forecastList = api.GetForecastListByName(city["name"].ToString());
                    forecastDataTable = Helper.ConvertToDataTable(forecastList);
                    PopulateDataGridViewWeather();
                    dataGridViewWeather.Columns.Remove("TMinus");
                }
            }
        }

        public void PopulateDataGridViewWeather()
        {
            dataGridViewWeather.DataSource = null;

            dataGridViewWeather.DataSource = forecastDataTable;
            //dataGridViewWeather.DataMember = forecastDataTable.TableName;
            dataGridViewWeather.Columns.Remove("TimeOfCalculation");
            dataGridViewWeather.Columns.Remove("CityId");
            dataGridViewWeather.AutoResizeColumns();
            foreach (DataGridViewColumn column in dataGridViewWeather.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (column.ValueType == typeof(DateTime))
                {
                    column.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }
            }
        }

        private void buttonUpdateWeather_Click(object sender, EventArgs e)
        {
            var forecastList = new List<DatabaseWeather>();
            foreach (DataRow row in cityDataTable.Rows)
            {
                var city = row["name"].ToString();

                (var current, _) = api.GetCurrentByName(city);
                if (current != null)
                {
                    db.WriteActual(current);
                }

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

        void SetUpTimeSelection()
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";

            for (int i = 0; i < 24; i += 3)
            {
                comboBoxTime.Items.Add($"{i:00}:00");
            }
            comboBoxTime.SelectedIndex = 0;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker1.Value.Date;
            var time = Convert.ToInt32(comboBoxTime.SelectedItem.ToString().Remove(2));
            var dateTime = date.AddHours(time);

            weatherList = db.GetWeatherByIdAndDateTime(selectedCityId, dateTime);

            dataGridViewWeather.DataSource = null;
            dataGridViewWeather.DataSource = weatherList;
            dataGridViewWeather.Columns.Remove("TimeOfCalculation");
            dataGridViewWeather.Columns.Remove("TimeOfWeather");
            dataGridViewWeather.Columns.Remove("CityId");

            if (dataGridViewWeather.Rows[0].Cells[0].Value.ToString().Equals("0") && dataGridViewWeather.RowCount > 1)
            {
                buttonShowStatistics.Enabled = true;
            }
            else
            {
                buttonShowStatistics.Enabled = false;
            }
        }

        private void buttonShowStatistics_Click(object sender, EventArgs e)
        {
            var cityName = cityDataTable.Rows[lbxCities.SelectedIndex];
            var statisticsForm = new StatisticsForm(cityName["name"].ToString(), weatherList);
            statisticsForm.Show();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to close the Application?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
