using AirQualityApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirQualityApi.ServiceClient
{
    public interface IAirQualityAPIServiceClient<TEndpoint> where TEndpoint :  IAirQualityBase
    {
        Task<AirQualityResult<TEndpoint>> GetAll(string Query);
    }
}