using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json.Linq;
using WeatherApp.Handlers;

namespace WeatherAppTest
{
    public class HttpResponseHandlerTests
    {
        [Fact]
        public async Task HttpResponseToObject_SuccessfulResponse_ReturnsJObject()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"key\": \"value\"}")
            };

            var handler = new HttpResponseHandler();

            var result = await handler.HttpResponseToObject(response);

            Assert.NotNull(result);
            Assert.Equal("value", result["key"].ToString());
        }

        [Fact]
        public async Task HttpResponseToObject_UnsuccessfulResponse_ThrowsException()
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                ReasonPhrase = "Not Found",
                Content = new StringContent("{\"message\": \"City not found.\"}")
            };

            var handler = new HttpResponseHandler();

            await Assert.ThrowsAsync<HttpRequestException>(async () => await handler.HttpResponseToObject(response));
        }
    }
}
