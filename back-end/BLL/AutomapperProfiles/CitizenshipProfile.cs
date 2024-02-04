using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL.AutomapperProfiles
{
    public class CitizenshipProfile : BaseProfile
    {
        public CitizenshipProfile()
        {
            CreateMap<CitizenshipRequestDto, CitizenshipModel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<CitizenshipModel, CitizenshipResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}