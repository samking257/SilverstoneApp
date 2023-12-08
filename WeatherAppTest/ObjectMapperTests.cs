using System;
using Newtonsoft.Json.Linq;
using WeatherApp.Mappers;
using WeatherApp.Models;
using Xunit;

namespace WeatherApp.Tests.Mappers
{
    public class ObjectMapperTests
    {
        [Fact]
        public void MapToWeatherInfoModel_ValidObject_ReturnsWeatherInfoModel()
        {
            var objectMapper = new ObjectMapper();

            var apiObject = new JObject
            {
                ["name"] = "London",
                ["main"] = new JObject
                {
                    ["temp"] = 300.0,
                    ["temp_min"] = 290.0,
                    ["temp_max"] = 310.0,
                    ["humidity"] = 50
                },
                ["sys"] = new JObject
                {
                    ["country"] = "GB",
                    ["sunrise"] = 1637868000.0,
                    ["sunset"] = 1637911200.0 
                }
            };

            var result = objectMapper.MapToWeatherInfoModel(apiObject);

            Assert.NotNull(result);
            Assert.Equal("London", result.City);
            Assert.Equal("GB", result.Country);
            Assert.Equal(26.85, result.CurrentTemp, 2);
            Assert.Equal(16.85, result.MinTemp, 2);
            Assert.Equal(36.85, result.MaxTemp, 2);
            Assert.Equal(50, result.Humidity);

        }

        [Fact]
        public void MapToWeatherInfoModel_NullObject_ThrowsArgumentNullException()
        {
            var objectMapper = new ObjectMapper();

            Assert.Throws<ArgumentNullException>(() => objectMapper.MapToWeatherInfoModel(null));
        }
    }
}