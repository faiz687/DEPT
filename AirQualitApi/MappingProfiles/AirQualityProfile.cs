using AirQualitApi.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityApi.MappingProfiles
{
    public class AirQualityProfile : Profile
    {
        public AirQualityProfile()
        {
            CreateMap<AirQualityIndexViewModel, AirQualitySearchRequest>()
                .ForMember(dest => dest.Country, opts => opts.MapFrom(src => src.SelectedCountries))
                .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.SelectedCities));
        }
    }
}
