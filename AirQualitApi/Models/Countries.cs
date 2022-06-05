using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityApi.Models
{
    public class Countries : AirQualityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Cities { get; set; }
        public int Sources { get; set; }
    }
}
