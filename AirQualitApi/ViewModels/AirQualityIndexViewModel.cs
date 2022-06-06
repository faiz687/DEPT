using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace AirQualitApi.ViewModels
{
    public class AirQualityIndexViewModel
    {
        public List<SelectListItem> AllCountries { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SelectedCountries { get; set; }

        public List<string> SelectedCountriesTrying { get; set; }
    }

}
