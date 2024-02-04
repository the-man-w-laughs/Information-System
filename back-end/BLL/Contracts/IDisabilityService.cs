using BLL.DTOs;

namespace BLL.Contracts
{
    public interface IDisabilityService
    {
        Task<List<DisabilityResponseDto>> GetAllDisabilityAsync(
            CancellationToken cancellationToken = default
        );
    }
}
