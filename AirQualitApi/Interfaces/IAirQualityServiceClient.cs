using AirQualityApi.Models;
using System.Threading.Tasks;

namespace AirQualityApi.Interfaces
{
    public interface IClient
    {
        Task<Result> Get(string Query);
    }
}
