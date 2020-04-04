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
        public string cityName = "ztu";
        readonly OpenWeatherMapApi api = new OpenWeatherMapApi();
        static readonly Database db = new Database();
        DataTable cityDataTable = new DataTable();
        DataTable forecastDataTable = new DataTable();

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
            db.GetCityDataTable(ref cityDataTable);
        }

        private void lbxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxCities.SelectedIndex > -1)
            {
                var index = lbxCities.SelectedIndex;
                var city = cityDataTable.Rows[index];
                tableLayoutPanelCity.GetControlFromPosition(1, 0).Text = city["name"].ToString();
                tableLayoutPanelCity.GetControlFromPosition(1, 1).Text = city["id"].ToString();
                tableLayoutPanelCity.GetControlFromPosition(1, 2).Text = city["country_iso"].ToString();
                tableLayoutPanelCity.GetControlFromPosition(1, 3).Text = city["timezone_shift"].ToString();

                (var weather, _) = api.GetCurrentByName(city["name"].ToString());

                if (weather != null)
                {
                    tableLayoutPanelCurrent.GetControlFromPosition(1, 0).Text = weather.Time.ToString("yyyy-MM-dd HH:mm:ss");
                    tableLayoutPanelCurrent.GetControlFromPosition(1, 1).Text = weather.Temperature.ToString();
                    tableLayoutPanelCurrent.GetControlFromPosition(1, 2).Text = weather.WindSpeed.ToString();
                    tableLayoutPanelCurrent.GetControlFromPosition(1, 3).Text = weather.WindDegree.ToString();
                    tableLayoutPanelCurrent.GetControlFromPosition(1, 4).Text = weather.Pressure.ToString();
                    tableLayoutPanelCurrent.GetControlFromPosition(1, 5).Text = weather.Humidity.ToString();
                    db.WriteActual(weather);

                    db.GetForecastDataTable(ref forecastDataTable, weather.CityId);
                    PopulateDataGridViewForeCasts();
                }
            }
        }

        public void PopulateDataGridViewForeCasts()
        {
            dataGridViewForecasts.DataSource = forecastDataTable;
            dataGridViewForecasts.DataMember = forecastDataTable.TableName;
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
    }
}
