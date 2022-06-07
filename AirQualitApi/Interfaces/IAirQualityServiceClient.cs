using AirQualityApi.Models;
using System.Threading.Tasks;

namespace AirQualityApi.Interfaces
{
    public interface IAirQualityClient
    {
        Task<Root<Countries>> GetAllCountries();

        Task<Root<Cities>> GetAllCities(string Query);

        Task<Root<MeasurementResult>> GetMeasurements(string Query);

    }
}
