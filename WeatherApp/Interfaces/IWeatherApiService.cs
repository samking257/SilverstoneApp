using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Interfaces
{
    public interface IWeatherApiService
    {
        Task<WeatherInfoModel> GetLocationWeatherInfo(string location);
    }
}