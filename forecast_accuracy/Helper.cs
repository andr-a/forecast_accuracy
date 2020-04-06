using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;

namespace forecast_accuracy
{
    static class Helper
    {
        public static DateTime RoundDateTimeToHours(DateTime dateTime, int hours)
        {
            var currentHours = dateTime.TimeOfDay.TotalHours;
            var roundedHours = Math.Round(currentHours / hours) * hours;
            return dateTime.Date.AddHours(roundedHours);
        }

        public static DateTime RoundTimeOfForecast(DateTime forecastTime, DateTime timeOfRequest)
        {
            var timeSpanHours = (forecastTime - timeOfRequest).TotalHours;
            var rounded = Math.Round(timeSpanHours / 24) * 24;
            var result = forecastTime.AddHours(-rounded);
            return result;
        }

        // Hilfsmethode, konvertiert jede Liste in eine entsprechende DataTable.
        public static DataTable ConvertToDataTable<T>(List<T> dataList)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            var dataTable = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    dataTable.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                }
                else
                {
                    dataTable.Columns.Add(prop.Name, prop.PropertyType);
                }
            }

            object[] values = new object[props.Count];
            foreach (T item in dataList)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }
}
