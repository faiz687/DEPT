using AirQualitApi.ViewModels;
using AirQualityApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityApi.Controllers
{
    public class AirQualityController : Controller
    {
        private readonly IAirQualityClient _airQualityServiceCLient;

        public AirQualityController(IAirQualityClient airQualityClient)
        {
            _airQualityServiceCLient = airQualityClient;
        }

        public async Task<IActionResult> Index()
        {
            var allCountries = await _airQualityServiceCLient.GetAllCountries();

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
        public async Task<IActionResult> GetAllCities(List<string> countriesSelected)
        {




            var allCities = await _airQualityServiceCLient.GetAllCities();

             var allCountries = await _airQualityServiceCLient.GetAllCountries();

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

    }
}
