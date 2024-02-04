using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL.AutomapperProfiles
{
    public class DisabilityProfile : BaseProfile
    {
        public DisabilityProfile()
        {
            CreateMap<DisabilityRequestDto, DisabilityModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<DisabilityModel, DisabilityResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}