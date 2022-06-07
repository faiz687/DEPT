using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace AirQualitApi.ViewModels
{
    public class AirQualitySearchRequest
    {
        public List<string> Country { get; set; } = new List<string>();

        public List<string> City { get; set; } = new List<string>();

    }

}
