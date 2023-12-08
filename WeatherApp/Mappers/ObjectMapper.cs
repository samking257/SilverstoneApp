using System;
using Newtonsoft.Json.Linq;
using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Mappers
{
    public class ObjectMapper : IObjectMapper
    {
        public WeatherInfoModel MapToWeatherInfoModel(JObject apiObject)
        {
            if (apiObject == null)
            {
                throw new ArgumentNullException(nameof(apiObject));
            }

            return new WeatherInfoModel
            {
                City = GetString(apiObject, "name"),
                Country = GetString(apiObject["sys"], "country"),
                CurrentTemp = KelvinToCelsius(GetDouble(apiObject["main"], "temp")),
                MinTemp = KelvinToCelsius(GetDouble(apiObject["main"], "temp_min")),
                MaxTemp = KelvinToCelsius(GetDouble(apiObject["main"], "temp_max")),
                Humidity = GetInt(apiObject["main"], "humidity") ?? 0,
                Sunrise = UnixTimeStampToDateTime(GetDouble(apiObject["sys"], "sunrise")),
                Sunset = UnixTimeStampToDateTime(GetDouble(apiObject["sys"], "sunset"))
            };
        }

        private string GetString(JToken token, string propertyName)
        {
            return token?[propertyName]?.ToString();
        }

        private double? GetDouble(JToken token, string propertyName)
        {
            return token?[propertyName]?.Value<double?>();
        }

        private int? GetInt(JToken token, string propertyName)
        {
            return token?[propertyName]?.Value<int?>();
        }

        private DateTime? UnixTimeStampToDateTime(double? unixTimeStamp)
        {
            return unixTimeStamp.HasValue
                ? new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp.Value).ToLocalTime()
                : (DateTime?)null;
        }

        private double KelvinToCelsius(double? kelvin)
        {
            return kelvin.HasValue ? Math.Round(kelvin.Value - 273.15, 2) : 0;
        }
    }
}
