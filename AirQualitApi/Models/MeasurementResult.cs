using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityApi.Models
{
    public class MeasurementResult : IAirQualityBase
    {
        public string location { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public Coordinates coordinates { get; set; }
        public List<Measurement> measurements { get; set; }
    }
    public class Coordinates
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Measurement
    {
        public string location { get; set; }
        public string parameter { get; set; }
        public double value { get; set; }
        public DateTime lastUpdated { get; set; }
        public string unit { get; set; }
    }
}
