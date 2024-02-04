using BLL.DTOs;

namespace BLL.Contracts
{
    public interface IPersonalInfoService
    {
        Task<PersonalInfoResponseDto> CreatePersonalInfoAsync(PersonalInfoRequestDto personalInfoRequestDto, CancellationToken cancellationToken = default);
        Task<List<PersonalInfoResponseDto>> GetAllPersonalInfoAsync(CancellationToken cancellationToken = default);
        Task<PersonalInfoResponseDto> GetPersonalInfoByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<PersonalInfoResponseDto> UpdatePersonalInfoByIdAsync(int id, PersonalInfoRequestDto personalInfoRequestDto, CancellationToken cancellationToken = default);
        Task<PersonalInfoResponseDto> DeletePersonalInfoByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}