using Newtonsoft.Json.Linq;
using WeatherApp.Models;

namespace WeatherApp.Interfaces
{
    public interface IObjectMapper
    {
        WeatherInfoModel MapToWeatherInfoModel(JObject apiObject);
    }
}