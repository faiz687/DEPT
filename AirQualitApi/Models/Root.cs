using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityApi.Models
{
    public class Root<T> where T : IAirQualityBase
    {
        public Meta Meta { get; set; }
        public List<T> Results { get; set; }
    }
}
