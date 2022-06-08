using AirQualitApi.ViewModels;
using AirQualityApi.Helpers;
using AirQualityApi.Interfaces;
using AirQualityApi.Models;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public AirQualityController(IAirQualityClient airQualityClient, IMapper mapper)
        {
            _airQualityServiceClient = airQualityClient;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new AirQualityIndexViewModel();

            var allCountries = await GetAllCountries();

            if (allCountries != null && allCountries.Any())
            {
                viewModel.AllCountries = allCountries.Select(result =>

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
            var countrieslist = selectedCountries.Split(',').ToList();
            
            var allCities = await GetAllCities(countrieslist);
 
            var result = allCities.Select(city => city.City);

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetMeasurements(AirQualityIndexViewModel viewModel)
        {
            var airQualitySearchRequest = _mapper.Map<AirQualitySearchRequest>(viewModel);

            var query = AirQualityHelper.GenerateSearchRequest(airQualitySearchRequest);

            var results = await _airQualityServiceClient.GetMeasurements(query);

            var resultsFiltered = results.Results.Where(a => a.city != null && a.city != "N/A").ToList();

            viewModel.Measurements = resultsFiltered;

            var result = await GetAllCountries();
            viewModel.AllCountries = result.Select(country => new SelectListItem
            {
                Text = country.Name,
                Value = country.Code
            }).ToList();

            var resultCities = await GetAllCities(viewModel.SelectedCountries);
            viewModel.AllCities = resultCities.Select(city =>
            {

                return new SelectListItem
                {
                    Text = city.City,
                    Selected = city.City == viewModel.SelectedCities[0] ? true : false
                };
            }).ToList();
            
            return View("Index",viewModel);
        }

        private async Task<List<Countries>> GetAllCountries()
        {
            var allCountries = await _airQualityServiceClient.GetAllCountries();

            return allCountries.Results;
        }

        private async Task<List<Cities>> GetAllCities(List<string> countryNames = null)
        {
            var query = AirQualityHelper.GenerateSearchRequest(new AirQualitySearchRequest { Country = countryNames });

            var allCities = await _airQualityServiceClient.GetAllCities(query);

            return allCities.Results.Where(c => c.City != "N/A").ToList();
        }

    }
}
