using AutoMapper;
using BLL.DTOs;
using DAL.Models;

namespace BLL.AutomapperProfiles
{
    public class PersonalInfoProfile : BaseProfile
    {
        public PersonalInfoProfile()
        {
            CreateMap<PersonalInfoRequestDto, PersonalInfoModel>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CurrentCity, opt => opt.Ignore())
            .ForMember(dest => dest.RegistrationCity, opt => opt.Ignore())
            .ForMember(dest => dest.MaritalStatus, opt => opt.Ignore())
            .ForMember(dest => dest.Citizenship, opt => opt.Ignore())
            .ForMember(dest => dest.Disability, opt => opt.Ignore())
            .ForMember(dest => dest.IsPensioner, opt => opt.MapFrom(src => src.IsPensioner))
            .ForMember(dest => dest.MonthlyIncome, opt => opt.MapFrom(src => src.MonthlyIncome))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.PassportSeries, opt => opt.MapFrom(src => src.PassportSeries))
            .ForMember(dest => dest.PassportNumber, opt => opt.MapFrom(src => src.PassportNumber))
            .ForMember(dest => dest.PassportIssuedBy, opt => opt.MapFrom(src => src.PassportIssuedBy))
            .ForMember(dest => dest.PassportIssueDate, opt => opt.MapFrom(src => src.PassportIssueDate))
            .ForMember(dest => dest.IdentificationNumber, opt => opt.MapFrom(src => src.IdentificationNumber))
            .ForMember(dest => dest.PlaceOfBirth, opt => opt.MapFrom(src => src.PlaceOfBirth))
            .ForMember(dest => dest.CurrentCityId, opt => opt.MapFrom(src => src.CurrentCityId))
            .ForMember(dest => dest.CurrentAddress, opt => opt.MapFrom(src => src.CurrentAddress))
            .ForMember(dest => dest.HomePhone, opt => opt.MapFrom(src => src.HomePhone))
            .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => src.MobilePhone))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Workplace, opt => opt.MapFrom(src => src.Workplace))
            .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
            .ForMember(dest => dest.RegistrationCityId, opt => opt.MapFrom(src => src.RegistrationCityId))
            .ForMember(dest => dest.MaritalStatusId, opt => opt.MapFrom(src => src.MaritalStatusId))
            .ForMember(dest => dest.CitizenshipId, opt => opt.MapFrom(src => src.CitizenshipId))
            .ForMember(dest => dest.DisabilityId, opt => opt.MapFrom(src => src.DisabilityId));

            CreateMap<PersonalInfoModel, PersonalInfoResponseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest => dest.PassportSeries, opt => opt.MapFrom(src => src.PassportSeries))
            .ForMember(dest => dest.PassportNumber, opt => opt.MapFrom(src => src.PassportNumber))
            .ForMember(dest => dest.PassportIssuedBy, opt => opt.MapFrom(src => src.PassportIssuedBy))
            .ForMember(dest => dest.PassportIssueDate, opt => opt.MapFrom(src => src.PassportIssueDate))
            .ForMember(dest => dest.IdentificationNumber, opt => opt.MapFrom(src => src.IdentificationNumber))
            .ForMember(dest => dest.PlaceOfBirth, opt => opt.MapFrom(src => src.PlaceOfBirth))
            .ForMember(dest => dest.CurrentCityId, opt => opt.MapFrom(src => src.CurrentCityId))
            .ForMember(dest => dest.CurrentCity, opt => opt.MapFrom(src => src.CurrentCity != null ? src.CurrentCity.Name : null))
            .ForMember(dest => dest.CurrentAddress, opt => opt.MapFrom(src => src.CurrentAddress))
            .ForMember(dest => dest.HomePhone, opt => opt.MapFrom(src => src.HomePhone))
            .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(src => src.MobilePhone))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Workplace, opt => opt.MapFrom(src => src.Workplace))
            .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
            .ForMember(dest => dest.RegistrationCityId, opt => opt.MapFrom(src => src.RegistrationCityId))
            .ForMember(dest => dest.RegistrationCity, opt => opt.MapFrom(src => src.RegistrationCity != null ? src.RegistrationCity.Name : null))
            .ForMember(dest => dest.MaritalStatusId, opt => opt.MapFrom(src => src.MaritalStatusId))
            .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus != null ? src.MaritalStatus.Name : null))
            .ForMember(dest => dest.CitizenshipId, opt => opt.MapFrom(src => src.CitizenshipId))
            .ForMember(dest => dest.Citizenship, opt => opt.MapFrom(src => src.Citizenship != null ? src.Citizenship.Name : null))
            .ForMember(dest => dest.DisabilityId, opt => opt.MapFrom(src => src.DisabilityId))
            .ForMember(dest => dest.Disability, opt => opt.MapFrom(src => src.Disability != null ? src.Disability.Name : null))
            .ForMember(dest => dest.IsPensioner, opt => opt.MapFrom(src => src.IsPensioner))
            .ForMember(dest => dest.MonthlyIncome, opt => opt.MapFrom(src => src.MonthlyIncome));
        }
    }
}