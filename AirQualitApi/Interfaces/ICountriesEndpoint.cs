using AirQualityApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirQualityApi.Endpoints
{
    public interface ICountriesEndpoint
    {
         Task<List<Countries>> GetAllCountries(List<string> Countries = null);
    }
}