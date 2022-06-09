using AirQualitApi.ViewModels;
using AirQualityApi.Helpers;
using AirQualityApi.Interfaces;
using AirQualityApi.Models;
using AirQualityApi.ServiceClient;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityApi.Endpoints
{
    public class CitiesEndpoint : AirQualityAPIServiceClient<Cities>, ICitiesEndpoint
    {
        public CitiesEndpoint(IClient client, IMapper mapper) : base(client, mapper)
        {

        }

        public async Task<List<Cities>> GetAllCities(List<string> Countries = null)
        {
            var query =  AirQualityHelper.GenerateSearchRequest(new AirQualitySearchRequest { Country = Countries });

            var result = await base.GetAll(query);
            
            return result.Results;                
        }

    }
}
