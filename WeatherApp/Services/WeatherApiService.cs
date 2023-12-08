using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherApiService : IWeatherApiService
    {
        private readonly HttpClient _client;
        private readonly IHttpResponseHandler _responseHandler;
        private readonly IObjectMapper _objectMapper;

        public const string BasePath = "/data/2.5/weather?APPID=2e544563202f054c557332328ab62cc1&q=";

        public WeatherApiService(HttpClient client, IHttpResponseHandler responseHandler, IObjectMapper objectMapper)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _responseHandler = responseHandler ?? throw new ArgumentNullException(nameof(responseHandler));
            _objectMapper = objectMapper ?? throw new ArgumentNullException(nameof(objectMapper));
        }

        public async Task<WeatherInfoModel> GetLocationWeatherInfo(string location)
        {
            var response = await _client.GetAsync(BasePath + location).ConfigureAwait(false);

            var result = await _responseHandler.HttpResponseToObject(response).ConfigureAwait(false);

            return _objectMapper.MapToWeatherInfoModel(result);
        }
    }
}