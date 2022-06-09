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
    public class Client : IClient
    {
        protected HttpClient httpClient;
        protected string OpenAqUrl = "https://api.openaq.org/v2/";
        public Client()
        {
            httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.BaseAddress = new Uri(OpenAqUrl);
        }

        public async Task<Result> Get(string query)
        {
            var result = new Result { Success = false };

            try
            {
                var response = await httpClient.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                   
                    var responseString = await response.Content.ReadAsStringAsync();

                    result.Success = true;
                    result.Response = responseString;
                    return result;
                }

                result.Response = response.Content.ToString();
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Response = $"Api call to {httpClient.BaseAddress.AbsoluteUri} failed with error: {ex.Message}";
                return result;
            }
        }     
    }
}
