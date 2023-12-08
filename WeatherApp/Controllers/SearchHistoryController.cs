using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class SearchHistoryController : Controller
    {
        public IActionResult Index()
        {
            var searchHistory = SearchHistoryList.GetSearchHistory();
            return View(searchHistory);
        }
    }
}