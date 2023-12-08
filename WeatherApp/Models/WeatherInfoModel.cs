using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Models
{
    public class WeatherInfoModel
    {
        public string City { get; set; }
        public string Country { get; set; }

        [Display(Name = "Current Temp")]
        public double CurrentTemp { get; set; }

        [Display(Name = "Min Temp")]
        public double MinTemp { get; set; }

        [Display(Name = "Max Temp")]
        public double MaxTemp { get; set; }

        public int Humidity { get; set; }

        public DateTime? Sunset { get; set; }

        public DateTime? Sunrise { get; set; }
    }
}