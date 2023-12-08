using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Interfaces;

namespace WeatherApp.Handlers
{
    public class HttpResponseHandler : IHttpResponseHandler
    {
        public async Task<JObject> HttpResponseToObject(HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = ExtractErrorMessage(responseString);
                throw new HttpRequestException($"Error {response.ReasonPhrase}: {errorMessage}");
            }

            return JObject.Parse(responseString);
        }

        private string ExtractErrorMessage(string responseString)
        {
            var responseObj = JObject.Parse(responseString);
            return responseObj["message"]?.ToString() ?? "Unknown HTTP error";
        }
    }
}
