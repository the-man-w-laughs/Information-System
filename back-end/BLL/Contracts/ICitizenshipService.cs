using BLL.DTOs;

namespace BLL.Contracts
{
    public interface ICitizenshipService
    {
        Task<List<CitizenshipResponseDto>> GetAllCitizenshipAsync(
            CancellationToken cancellationToken = default
        );
    }
}
