using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace forecast_accuracy
{
    public partial class StatisticsForm : Form
    {
        private readonly string cityName;
        private readonly List<DatabaseWeather> weatherList;
        private List<WeatherStatistics> statisticsList = new List<WeatherStatistics>();

        public StatisticsForm(string cityName, List<DatabaseWeather> weatherList)
        {
            InitializeComponent();
            this.cityName = cityName;
            this.weatherList = weatherList;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Statistics for {cityName} at {weatherList[0].TimeOfWeather:yyyy-MM-dd HH:mm}";

            CalculateStatistics();
            SetupDataGridViewColumnNames();
            PopulateDataGridView();

            //Console.WriteLine(dataGridViewStatistics[2, 1].Value.GetType());
            //Console.WriteLine(dataGridViewStatistics[2, 1].Value);
            DrawChart();
        }

        private void CalculateStatistics()
        {
            foreach (var forecast in weatherList.Skip(1))
            {
                var statistics = new WeatherStatistics(weatherList[0], forecast);
                statisticsList.Add(statistics);
            }
        }

        private void SetupDataGridViewColumnNames()
        {
            int columnCount = 11;
            var columnNames = new List<string>() { "TMinus", "Temperature", "Temperuture Deviation", "Wind Speed",
                "Wind Speed Deviation", "Wind Degree", "Wind Degree Deviation", "Pressure", "Pressure Deviation",
                "Humidity", "Humidity Deviation"
            };

            dataGridViewStatistics.ColumnCount = columnCount;

            for (int i = 0; i < columnCount; i++)
            {
                dataGridViewStatistics.Columns[i].Name = columnNames[i];
            }
        }

        private void PopulateDataGridView()
        {
            var actual = weatherList[0];

            dataGridViewStatistics.Rows.Add(0, actual.Temperature, null, actual.WindSpeed, null, actual.WindDegree, null,
                actual.Pressure, null, actual.Humidity, null);

            foreach (var forecast in statisticsList)
            {
                var tMinus = forecast.Forecast.TMinus;
                var temperature = forecast.Forecast.Temperature;
                var temperatureAccuracy = forecast.Accuracies.TemperatureAccuracy.ToString("P");
                var windSpeed = forecast.Forecast.WindSpeed;
                var windSpeedAccuracy = forecast.Accuracies.WindSpeedAccuracy.ToString("P");
                var windDegree = forecast.Forecast.WindDegree;
                var windDegreeAccuracy = forecast.Accuracies.WindDegreeAccuracy.ToString("P");
                var pressure = forecast.Forecast.Pressure;
                var pressureAccuracy = forecast.Accuracies.PressureAccuracy.ToString("P");
                var humidity = forecast.Forecast.Humidity;
                var humidityAccuracy = forecast.Accuracies.HumidityAccuracy.ToString("P");

                dataGridViewStatistics.Rows.Add(tMinus, temperature, temperatureAccuracy, windSpeed, windSpeedAccuracy,
                    windDegree, windDegreeAccuracy, pressure, pressureAccuracy, humidity, humidityAccuracy);
                
            }
        }

        private void DrawChart()
        {
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.ChartAreas[0].AxisX.Title = "Days until forecasted date";
            chart1.ChartAreas[0].AxisY.Title = "%";
            chart1.Series.Clear();

            for (int j = 2; j < dataGridViewStatistics.Columns.Count; j += 2)
            {
                // j - 1 um eine kompaktere Legende zu erstellen.
                chart1.Series.Add(dataGridViewStatistics.Columns[j - 1].HeaderText).ChartType = SeriesChartType.Line;

                for (int i = dataGridViewStatistics.Rows.Count - 1; i > 0; i--)
                {
                    chart1.Series[chart1.Series.Count - 1].Points.AddXY(dataGridViewStatistics[0, i].Value.ToString(), Double.Parse(dataGridViewStatistics[j, i].Value.ToString().Replace("%", "")));
                }
            }
        }

        // Nicht verwendet.
        private void DrawColumnChart()
        {
            chart1.Series.Clear();

            for (int i = 0; i < dataGridViewStatistics.Rows.Count; i++)
            {
                chart1.Series.Add(dataGridViewStatistics[0, i].Value.ToString());
                chart1.Series[i].ChartType = SeriesChartType.Column;
            }

            for (int i = 1; i < dataGridViewStatistics.Rows.Count; i++)
            {
                for (int j = 2; j < dataGridViewStatistics.Columns.Count; j += 2)
                {
                    chart1.Series[i].Points.AddXY(dataGridViewStatistics.Columns[j].HeaderText, dataGridViewStatistics[j, i].Value);
                } 
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}