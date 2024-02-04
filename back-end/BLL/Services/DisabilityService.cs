using AutoMapper;
using BLL.Contracts;
using BLL.DTOs;
using DAL.Contracts;

namespace BLL.Services
{
    public class DisabilityService : IDisabilityService
    {
        private readonly IDisabilityModelRepository _disabilityModelRepository;
        private readonly IMapper _mapper;

        public DisabilityService(
            IDisabilityModelRepository disabilityModelRepository,
            IMapper mapper
        )
        {
            _disabilityModelRepository = disabilityModelRepository;
            _mapper = mapper;
        }

        public async Task<List<DisabilityResponseDto>> GetAllDisabilityAsync(
            CancellationToken cancellationToken = default
        )
        {
            var result = await _disabilityModelRepository.GetAllAsync(cancellationToken);

            return _mapper.Map<List<DisabilityResponseDto>>(result);
        }
    }
}
