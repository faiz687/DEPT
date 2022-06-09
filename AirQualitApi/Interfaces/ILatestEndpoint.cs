using AirQualitApi.ViewModels;
using AirQualityApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirQualityApi.Endpoints
{
    public interface ILatestEndpoint
    {
        Task<List<MeasurementResult>> GetLatest(AirQualitySearchRequest airQualitySearchRequest);
    }
}