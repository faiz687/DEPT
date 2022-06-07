using AirQualitApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityApi.Helpers
{
    public static class AirQualityHelper 
    {
        public static string GenerateSearchRequest(AirQualitySearchRequest searchRequest)
        {
            var query = "";

            if (searchRequest.City.Any() || searchRequest.Country.Any())
            {
                query += "?";
            }
            
            if (searchRequest.City.Any())
            {
                foreach (var city in searchRequest.City)
                {
                    query += $"{(nameof(searchRequest.City)).ToLower()}={city}&";
                }
            }

            if (searchRequest.Country.Any())
            {
                foreach (var country in searchRequest.Country)
                {
                    query += $"{(nameof(searchRequest.Country)).ToLower()}={country}&";
                }
            }

            return query;
        }

        public static string GetCountryNameFromTwoLetterCounytryCode(string countryCode)
        {
            RegionInfo regionInfo = new RegionInfo(countryCode);
            // globalization ??
            return regionInfo.EnglishName;
        }
    }
}
