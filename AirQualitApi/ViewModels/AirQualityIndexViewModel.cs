using AirQualityApi.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace AirQualitApi.ViewModels
{
    public class AirQualityIndexViewModel
    {
        public List<SelectListItem> AllCountries { get; set; }

        public List<string> SelectedCountries { get; set; }

        public List<SelectListItem> AllCities { get; set; }

        public List<string> SelectedCities { get; set; }

        public List<MeasurementResult>  Measurements  { get; set; }
    }

}
