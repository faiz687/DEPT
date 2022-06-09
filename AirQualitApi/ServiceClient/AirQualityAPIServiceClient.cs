using AirQualitApi.ViewModels;
using AirQualityApi.Helpers;
using AirQualityApi.Interfaces;
using AirQualityApi.Models;
using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityApi.ServiceClient
{
    public abstract class AirQualityAPIServiceClient<TEndpoint> : IAirQualityAPIServiceClient<TEndpoint> where TEndpoint : IAirQualityBase
    {
        private readonly IClient _client;
        private readonly IMapper _mapper;

        public AirQualityAPIServiceClient(IClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        public async Task<AirQualityResult<TEndpoint>> GetAll(string Query)
        {
            var result = new AirQualityResult<TEndpoint>{ Success = false };

            try
            {
                var response = await _client.Get($"{AdaptiveUri}?{Query}");

                if (response.Success)
                {
                    result = JsonConvert.DeserializeObject<AirQualityResult<TEndpoint>>(response.Response);
                    result.Success = true;
                }

                result.Message = response.Response;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = $"Error Occured while making call to API with message {ex.Message}";
                return result;
            }
        }

        //public async Task<AirQualityResult<Cities>> GetAllCities(List<string> Countries = null)
        //{
        //    var result = new AirQualityResult<Cities> { Success = false };

        //    try
        //    {
        //        var query = AirQualityHelper.GenerateSearchRequest(new AirQualitySearchRequest { Country = Countries });

        //        var response = await _client.Get($"cities?{query}");

        //        if (response.Success)
        //        {
        //            result = JsonConvert.DeserializeObject<AirQualityResult<cities>>(response.Response);
        //            result.Success = true;
        //        }

        //        result.Message = response.Response;
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Message = $"Error Occured while making call to API with message {ex.Message}";
        //        return result;
        //    }











        //    var query = AirQualityHelper.GenerateSearchRequest(new AirQualitySearchRequest { Country = Countries });

        //    var allCities = await _airQualityServiceClient.Get(query);

        //    return allCities.Results.Where(c => c.City != "N/A").ToList();
        //}


        protected string AdaptiveUri
        {
            get
            {
                if(typeof(TEndpoint) == typeof(Countries))
                {
                    return "countries";
                }
                if(typeof(TEndpoint) == typeof(Cities))
                {
                    return "cities";
                }
                if(typeof(TEndpoint) == typeof(MeasurementResult))
                {
                    return "latest";
                }
                return "";
            }
        }

    }
}
