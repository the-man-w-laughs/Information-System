using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL.AutomapperProfiles
{
    public class CityProfile : BaseProfile
    {
        public CityProfile()
        {
            CreateMap<CityRequestDto, CityModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<CityModel, CityResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}