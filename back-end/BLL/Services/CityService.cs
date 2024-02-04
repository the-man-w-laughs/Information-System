using AutoMapper;
using BLL.Contracts;
using BLL.DTOs;
using DAL.Contracts;

namespace BLL.Services
{
    public class CityService : ICityService
    {
        private readonly ICityModelRepository _cityModelRepository;
        private readonly IMapper _mapper;

        public CityService(ICityModelRepository cityModelRepository, IMapper mapper)
        {
            _cityModelRepository = cityModelRepository;
            _mapper = mapper;
        }

        public async Task<List<CityResponseDto>> GetAllCityAsync(
            CancellationToken cancellationToken = default
        )
        {
            var result = await _cityModelRepository.GetAllAsync(cancellationToken);

            return _mapper.Map<List<CityResponseDto>>(result);
        }
    }
}
