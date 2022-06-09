using AirQualitApi.ViewModels;
using AirQualityApi.Endpoints;
using AirQualityApi.Helpers;
using AirQualityApi.Interfaces;
using AirQualityApi.Models;
using AirQualityApi.ServiceClient;
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
        private readonly IMapper _mapper;
        private readonly ICountriesEndpoint _countriesEndpoint;
        private readonly ICitiesEndpoint _citiesEndpoint;
        private readonly ILatestEndpoint _latestEndpoint;

        public AirQualityController( IMapper mapper, ICountriesEndpoint countriesEndpoint, ICitiesEndpoint citiesEndpoint, ILatestEndpoint latestEndpoint )
        {
           _latestEndpoint = latestEndpoint;
           _citiesEndpoint = citiesEndpoint;
           _countriesEndpoint = countriesEndpoint;
           _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {      
            var viewModel = new AirQualityIndexViewModel();

            var allCountries = await _countriesEndpoint.GetAllCountries();

            if (allCountries.Any())
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

            var allCities = await _citiesEndpoint.GetAllCities(countrieslist);
 
            var result = allCities.Select(city => city.City);

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetMeasurements(AirQualityIndexViewModel viewModel)
        {
            var airQualitySearchRequest = _mapper.Map<AirQualitySearchRequest>(viewModel);

            var latestMeasurements = await _latestEndpoint.GetLatest(airQualitySearchRequest);

            var measurementsFiltered = latestMeasurements.Where(a => a.city != null && a.city != "N/A").ToList();

            viewModel.Measurements = measurementsFiltered;

            var result = await _countriesEndpoint.GetAllCountries();
            viewModel.AllCountries = result.Select(country => new SelectListItem
            {
                Text = country.Name,
                Value = country.Code
            }).ToList();


            var resultCities = await _citiesEndpoint.GetAllCities(viewModel.SelectedCountries);
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
      
    }
}
