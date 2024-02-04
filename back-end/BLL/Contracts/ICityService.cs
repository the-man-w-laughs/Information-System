using BLL.DTOs;

namespace BLL.Contracts
{
    public interface ICityService
    {
        Task<List<CityResponseDto>> GetAllCityAsync(CancellationToken cancellationToken = default);
    }
}
