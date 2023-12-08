using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using WeatherApp.Interfaces;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherApiService _apiService;

        public WeatherController(IWeatherApiService service)
        {
            _apiService = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(string location)
        {
            try
            {
                var noSpacesLocation = RemoveWhitespace(location);
                var weatherInfo = await _apiService.GetLocationWeatherInfo(noSpacesLocation);
                SearchHistoryList.AddSearch(weatherInfo);
                return View(weatherInfo);
            }
            catch (HttpRequestException ex)
            {
                return View("Error", (object)ex.Message);
            }
            catch (Exception ex)
            {
                return View("Error", (object)"An unexpected error occurred.");
            }
        }

        private string RemoveWhitespace(string input)
        {
            return new string(input?.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }
    }
}
