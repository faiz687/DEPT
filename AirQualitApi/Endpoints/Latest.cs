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
    public class LatestEndpoint : AirQualityAPIServiceClient<MeasurementResult>, ILatestEndpoint
    {
        public LatestEndpoint(IClient client, IMapper mapper) : base(client, mapper)
        {

        }

        public async Task<List<MeasurementResult>> GetLatest(AirQualitySearchRequest airQualitySearchRequest)
        {
            var query = AirQualityHelper.GenerateSearchRequest(airQualitySearchRequest);

            var result = await base.GetAll(query);

            return result.Results;

        }
    }
}
