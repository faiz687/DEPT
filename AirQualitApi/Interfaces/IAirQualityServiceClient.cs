using AirQualityApi.Models;
using System.Threading.Tasks;

namespace AirQualityApi.Interfaces
{
    public interface IAirQualityClient
    {
        Task<Root<Countries>> GetAllCountries();

        Task<Root<Cities>> GetAllCities();
    }
}