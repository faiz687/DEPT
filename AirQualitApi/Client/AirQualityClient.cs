using AirQualityApi.Interfaces;
using AirQualityApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AirQualityApi.Client
{
    public class AirQualityClient : IAirQualityClient
    {
        protected HttpClient Client;
        protected string OpenAqUrl = "https://api.openaq.org/v2/";
        public AirQualityClient()
        {
            Client = new HttpClient();

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Client.BaseAddress = new Uri(OpenAqUrl);
        }

        public async Task<Root<Cities>> GetAllCities()
        {
            var result = await Client.GetAsync("cities");

            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<Root<Cities>>(json);

            return response;
        }

        public async Task<Root<Countries>> GetAllCountries()
        {
            var result = await Client.GetAsync("countries");

            var json = await result.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<Root<Countries>>(json);

            return response;
        }
    }
}
