using AirQualitApi.ViewModels;
using AirQualityApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityApi.Controllers
{
    public class AirQualityController : Controller
    {
        private readonly IAirQualityClient _airQualityServiceClient;

        public AirQualityController(IAirQualityClient airQualityClient)
        {
            _airQualityServiceClient = airQualityClient;
        }

        public async Task<IActionResult> Index()
        {
            var allCountries = await _airQualityServiceClient.GetAllCountries();

            var viewModel = new AirQualityIndexViewModel();

            if (allCountries.Results.Any() && allCountries.Meta.found > 1)
            {
                viewModel.AllCountries = allCountries.Results.Select(result =>

                new SelectListItem
                {
                    Value = result.Code,
                    Text = result.Name
                }).ToList();

            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities(string selectedCountries)
        {
            var countrieslist = selectedCountries.Split(',');
            
            var allCities = await _airQualityServiceClient.GetAllCities(countrieslist);

            var result = allCities.Results.Select(city => city.City);

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetMeasurements(AirQualityIndexViewModel viewModel)
        {
            
            //var countrieslist = selectedCountries.Split(',');

            //var allCities = await _airQualityServiceClient.GetAllCities(countrieslist);

            //var result = allCities.Results.Select(city => city.City);

            return Json("");
        }



    }
}
