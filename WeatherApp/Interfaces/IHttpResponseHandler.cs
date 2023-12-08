using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WeatherApp.Interfaces
{
    public interface IHttpResponseHandler
    {
        Task<JObject> HttpResponseToObject(HttpResponseMessage response);
    }
}
