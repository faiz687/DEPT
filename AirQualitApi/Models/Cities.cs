using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityApi.Models
{
    public class Cities : AirQualityBase
    {
        public string Country { get; set; }
        public string City { get; set; }
    }

}
