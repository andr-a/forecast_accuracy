using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            var columnNames = new List<string>() { "TMinus", "Temperature", "Temperuture Accuracy", "Wind Speed",
                "Wind Speed Accuracy", "Wind Degree", "Wind Degree Accuracy", "Pressure", "Pressure Accuracy",
                "Humidity", "Humidity Accuracy"
            };

            dataGridViewStatistics.ColumnCount = columnCount;

            for (int i = 0; i < columnCount; i++)
            {
                dataGridViewStatistics.Columns[i].Name = columnNames[i];
            }
        }

        private void PopulateDataGridView()
        {
            Console.WriteLine(statisticsList.Count);

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
    }
}
