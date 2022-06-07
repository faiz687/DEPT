using AirQualityApi.Models;
using System.Collections.Generic;

namespace AirQualitApi.ViewModels
{
    public class MeasurementResultViewModel
    {
        public string Country { get; set; }

        public List<City> Cities { get; set; }

    }

    public class City
    {
        public string Name { get; set; }
        public List<Measurement> Measurements { get; set; }
    }

}