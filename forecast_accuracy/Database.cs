using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
                command.CommandText = $"INSERT INTO city VALUES({id}, '{name}', '{countryIso}', {timezoneShift}, 0) "
                                    + $"ON DUPLICATE KEY UPDATE timezone_shift = {timezoneShift}, suspended = 0";
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("WriteCity: " + ex.Message);
            }
            finally
            {
                CloseDb();
            }
        }

        public void SuspendCity(string cityName)
        {
            try
            {
                OpenDb();
                var command = connection.CreateCommand();
                command.CommandText = $"UPDATE city SET suspended = 1 WHERE name = '{cityName}'";
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + ":\n\n" + ex.Message);
            }
            finally
            {
                CloseDb();
            }
        }

        public void WriteActual(DatabaseWeather weather)
        {
            var roundedTime = weather.TimeOfWeather;
            var timeofCalculation = weather.TimeOfCalculation;
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
                command.CommandText = $"INSERT IGNORE INTO actual VALUES('{roundedTime:yyyy-MM-dd HH:mm:ss}', "
                                     + $"'{timeofCalculation:yyyy-MM-dd HH:mm:ss}', "
                                     + $"{cityId}, {temperatur}, {windSpeed}, {windDegree}, {pressure}, {humidity})";
                command.ExecuteNonQuery();
                Console.WriteLine("Actual written.");
            }
            catch (MySqlException ex)
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
                var forecastTime = weather.TimeOfWeather;
                var roundedTimeOfRequest = weather.TimeOfCalculation;
                var cityId = weather.CityId;
                var temperature = weather.Temperature.ToString(CultureInfo.InvariantCulture);
                var windSpeed = weather.WindSpeed.ToString(CultureInfo.InvariantCulture);
                var windDegree = weather.WindDegree;
                var pressure = weather.Pressure;
                var humidity = weather.Humidity;

                values += $"('{forecastTime:yyyy-MM-dd HH:mm:ss}', '{roundedTimeOfRequest:yyyy-MM-dd HH:mm:ss}', "
                        + $"{cityId}, {temperature}, {windSpeed}, {windDegree}, {pressure}, {humidity})";
                if (weather != last)
                {
                    values += ", ";
                }
            }

            try
            {
                OpenDb();
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO forecast VALUES {values}"
                    + "ON DUPLICATE KEY UPDATE temperature = VALUES(temperature), "
                    + "wind_speed = VALUES(wind_speed), wind_degree = VALUES(wind_degree), pressure = VALUES(pressure), "
                    + "pressure = VALUES(pressure), humidity = VALUES(humidity)";
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("WriteForecastList: " + ex.Message);
            }
            finally
            {
                CloseDb();
            }
        }

        public void GetCityDataTable(ref DataTable dataTable)
        {
            dataTable.Clear();
            try
            {
                OpenDb();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM city WHERE suspended = 0 ORDER BY name";
                command.ExecuteNonQuery();

                var dataAdapter = new MySqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + ":\n\n" + ex.Message);
            }
            finally
            {
                CloseDb();
            }
        }

        public List<DatabaseWeather> GetForecastListById(int cityId)
        {
            var forecastList = new List<DatabaseWeather>();

            try
            {
                OpenDb();
                var command = connection.CreateCommand();
                //command.CommandText = $"SELECT *,  FROM forecast WHERE city_id = {cityId} ORDER BY forecast_time";
                command.CommandText = $"SELECT * , TIME_FORMAT(TIMEDIFF(forecast_time, rounded_time_of_request), '%H') / 24 AS t_minus FROM forecast HAVING city_id = {cityId} ORDER BY forecast_time";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var forecast = new DatabaseWeather(
                        reader.GetDateTime(0),
                        reader.GetDateTime(1),
                        reader.GetInt32(8),
                        reader.GetInt32(2),
                        !reader.IsDBNull(3) ? reader.GetDouble(3) : 0.0,
                        !reader.IsDBNull(4) ? reader.GetDouble(4) : 0.0,
                        !reader.IsDBNull(5) ? reader.GetInt32(5) : 0,
                        !reader.IsDBNull(6) ? reader.GetInt32(6) : 0,
                        !reader.IsDBNull(7) ? reader.GetInt32(7) : 0
                        );
                    forecastList.Add(forecast);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + ":\n\n" + ex.Message);
            }
            finally
            {
                CloseDb();
            }
            return forecastList;
        }

        public List<DatabaseWeather> GetWeatherByIdAndDateTime(int cityId, DateTime dateTime)
        {
            var weatherList = new List<DatabaseWeather>();
            var formattedDateTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                OpenDb();
                var command = connection.CreateCommand();
                command.CommandText = $"(SELECT * , 0 as t_minus FROM actual WHERE city_id = {cityId} AND rounded_time = '{formattedDateTime}') "
                    + $"UNION (SELECT * , TIME_FORMAT(TIMEDIFF(forecast_time, rounded_time_of_request), '%H') / 24 AS t_minus FROM forecast HAVING city_id = {cityId} AND forecast_time = '{formattedDateTime}' AND t_minus > 0)";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var weahter = new DatabaseWeather(
                        reader.GetDateTime(0),
                        reader.GetDateTime(1),
                        reader.GetInt32(8),
                        reader.GetInt32(2),
                        !reader.IsDBNull(3) ? reader.GetDouble(3) : 0.0,
                        !reader.IsDBNull(4) ? reader.GetDouble(4) : 0.0,
                        !reader.IsDBNull(5) ? reader.GetInt32(5) : 0,
                        !reader.IsDBNull(6) ? reader.GetInt32(6) : 0,
                        !reader.IsDBNull(7) ? reader.GetInt32(7) : 0
                        );
                    weatherList.Add(weahter);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + ":\n\n" + ex.Message);
            }
            finally
            {
                CloseDb();
            }
            return weatherList;
        }

        // Nicht in Verwendung, deshalb private.
        private void GetForecastDataTable(ref DataTable dataTable, int cityId)
        {
            dataTable.Clear();
            try
            {
                OpenDb();
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM forecast WHERE city_id = {cityId} ORDER BY forecast_time";
                command.ExecuteNonQuery();

                var dataAdapter = new MySqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + ":\n\n" + ex.Message);
            }
            finally
            {
                CloseDb();
            }
        }
        
        // Nicht in Verwendung, deshalb private.
        public List<DatabaseCity> GetCityList()
        {
            var cityList = new List<DatabaseCity>();

            try
            {
                OpenDb();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM city";
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var city = new DatabaseCity(
                        reader.GetInt32(0),
                        !reader.IsDBNull(1) ? reader.GetString(1) : "",
                        !reader.IsDBNull(2) ? reader.GetString(2) : "",
                        !reader.IsDBNull(3) ? reader.GetInt32(3) : 0
                        );
                    cityList.Add(city);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("GetCityList:\n\n" + ex.Message);
            }
            finally
            {
                CloseDb();
            }
            return cityList;
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

                values += $"('{forecastTime:yyyy-MM-dd HH:mm:ss}', {cityId}, {temperature}, {windSpeed}, "
                         + $"{windDegree}, {pressure}, {humidity}, {tMinus})";
                if (forecastObject != last)
                {
                    values += ", ";
                }
            }

            try
            {
                OpenDb();
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO forecast VALUES {values}"
                    + "ON DUPLICATE KEY UPDATE temperature = VALUES(temperature), "
                    + "wind_speed = VALUES(wind_speed), wind_degree = VALUES(wind_degree), pressure = VALUES(pressure), "
                    + "pressure = VALUES(pressure), humidity = VALUES(humidity)";
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
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
