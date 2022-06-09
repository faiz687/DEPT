using AirQualityApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirQualityApi.Endpoints
{
    public interface ICitiesEndpoint
    {
        Task<List<Cities>> GetAllCities(List<string> Countries = null);
    }

}