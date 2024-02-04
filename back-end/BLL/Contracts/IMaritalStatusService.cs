using BLL.DTOs;

namespace BLL.Contracts
{
    public interface IMaritalStatusService
    {
        Task<List<MaritalStatusResponseDto>> GetAllMaritalStatusAsync(
            CancellationToken cancellationToken = default
        );
    }
}
