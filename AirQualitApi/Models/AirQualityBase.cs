using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityApi.Models
{
    public class AirQualityBase : IAirQualityBase
    {
        public int Locations { get; set; }
        public DateTime FirstUpdated { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<string> Parameters { get; set; }
        public long Count { get; set; }
    }

    public interface IAirQualityBase
    {
        public int Locations { get; set; }
        public DateTime FirstUpdated { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<string> Parameters { get; set; }
        public long Count { get; set; }
    }

}
