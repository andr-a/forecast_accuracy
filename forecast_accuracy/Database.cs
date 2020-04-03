using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forecast_accuracy
{
    public class Database
    {
        private const string Server = "localhost";
        private const string Uid = "root";
        private const string Password = "root";
        private const string DatabaseName = "weather";
        private readonly MySqlConnection connection = new MySqlConnection(
            $"SERVER={Server};"
            + $"UID={Uid};"
            + $"PASSWORD={Password};"
            + $"DATABASE={DatabaseName}"
            );
        private const string OnDuplicateKey = "ON DUPLICATE KEY UPDATE temperature = VALUES(temperature), wind_speed = VALUES(wind_speed), wind_degree = VALUES(wind_degree), pressure = VALUES(pressure), humidity = VALUES(humidity)";

        private void OpenDb()
        {
            connection.Open();
        }

        private void CloseDb()
        {
            if (connection != null)
                connection.Close();
        }

        public void WriteCity(DatabaseCity city)
        {
            var id = city.Id;
            var name = city.Name;
            var countryIso = city.CountryIso;
            var timezoneShift = city.TimezoneShift;

            try
            {
                OpenDb();
                var command = connection.CreateCommand();
                // Bei Zeitumstellung ändert sich timezoneShift entsprechend.
                command.CommandText = $"INSERT INTO city VALUES({id}, '{name}', '{countryIso}', {timezoneShift}) "
                                    + $"ON DUPLICATE KEY UPDATE timezone_shift = {timezoneShift}";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("WriteCity: " + ex.Message);
            }
            finally
            {
                CloseDb();
            }
        }

        public void WriteActual(DatabaseWeather weather)
        {
            var timeofCalculation = weather.Time;
            var cityId = weather.CityId;
            var temperatur = weather.Temperature.ToString(CultureInfo.InvariantCulture);
            var windSpeed = weather.WindSpeed.ToString(CultureInfo.InvariantCulture);
            var windDegree = weather.WindDegree;
            var pressure = weather.Pressure;
            var humidity = weather.Humidity;

            try
            {
                OpenDb();
                var command = connection.CreateCommand();
                // Daten werden nur alle paar Minuten neu berechnet.
                command.CommandText = $"INSERT IGNORE INTO actual VALUES('{timeofCalculation:yyyy-MM-dd HH-mm-ss}', {cityId}, {temperatur}, {windSpeed}, {windDegree}, {pressure}, {humidity})";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("WriteActual: " + ex.Message);
            }
            finally
            {
                CloseDb();
            }
        }

        public void WriteForecastList(List<DatabaseWeather> forecastList)
        {
            var values = "";
            var last = forecastList.Last();

            foreach (var weather in forecastList)
            {
                var forecastTime = weather.Time;
                var cityId = weather.CityId;
                var temperature = weather.Temperature.ToString(CultureInfo.InvariantCulture);
                var windSpeed = weather.WindSpeed.ToString(CultureInfo.InvariantCulture);
                var windDegree = weather.WindDegree;
                var pressure = weather.Pressure;
                var humidity = weather.Humidity;
                var tMinus = weather.TMinus;

                values += $"('{forecastTime:yyyy-MM-dd HH:mm:ss}', {cityId}, {temperature}, {windSpeed}, {windDegree}, {pressure}, {humidity}, {tMinus})";
                if (weather != last)
                {
                    values += ", ";
                }
            }

            try
            {
                OpenDb();
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO forecast VALUES {values}" + OnDuplicateKey;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("WriteForecastList: " + ex.Message);
            }
            finally
            {
                CloseDb();
            }
        }

        // Nicht in Verwendung, deshalb private.
        private void WriteForecast(DatabaseWeather weather)
        {
            var forecastTime = weather.Time;
            var cityId = weather.CityId;
            var temperature = weather.Temperature;
            var windSpeed = weather.WindSpeed;
            var windDegree = weather.WindDegree;
            var pressure = weather.Pressure;
            var humidity = weather.Humidity;
            var tMinus = weather.TMinus;

            try
            {
                OpenDb();
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO forecast VALUES({forecastTime}, {cityId}, {temperature}, {windSpeed}, {windDegree}, {pressure}, {humidity}, {tMinus})";
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("WriteForecast: " + ex.Message);
            }
            finally
            {
                CloseDb();
            }
        }

        // Nicht in Verwendung, deshalb private.
        private void WriteForcastCollection(ForecastCollection forecastCollection)
        {
            var dateOfRequest = forecastCollection.DateOfRequest;
            var cityId = forecastCollection.City.Id;
            string values = "";

            var last = forecastCollection.List.Last();

            foreach (var forecastObject in forecastCollection.List)
            {
                var forecastTime = DateTimeOffset.FromUnixTimeSeconds(forecastObject.Dt).DateTime;
                var temperature = forecastObject.Main.Temp.ToString(CultureInfo.InvariantCulture);
                var windSpeed = forecastObject.Wind.Speed.ToString(CultureInfo.InvariantCulture);
                var windDegree = forecastObject.Wind.Deg;
                var pressure = forecastObject.Main.Pressure;
                var humidity = forecastObject.Main.Humidity;

                var tMinus = (int)Math.Ceiling((forecastTime - dateOfRequest).TotalDays);

                values += $"('{forecastTime:yyyy-MM-dd HH:mm:ss}', {cityId}, {temperature}, {windSpeed}, {windDegree}, {pressure}, {humidity}, {tMinus})";
                if (forecastObject != last)
                {
                    values += ", ";
                }
            }

            try
            {
                OpenDb();
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO forecast VALUES {values}" + OnDuplicateKey;
                Console.WriteLine(command.CommandText);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("WriteForecastCollection: " + ex.Message);
            }
            finally
            {
                CloseDb();
            }
        }
    }
}
