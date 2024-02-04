using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL.AutomapperProfiles
{
    public class MaritalStatusProfile : BaseProfile
    {
        public MaritalStatusProfile()
        {
            CreateMap<MaritalStatusRequestDto, MaritalStatusModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<MaritalStatusModel, MaritalStatusResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}