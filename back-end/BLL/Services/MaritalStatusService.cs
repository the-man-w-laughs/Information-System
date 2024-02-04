using AutoMapper;
using BLL.Contracts;
using BLL.DTOs;
using DAL.Contracts;

namespace BLL.Services
{
    public class MaritalStatusService : IMaritalStatusService
    {
        private readonly IMaritalStatusModelRepository _maritalStatusModelRepository;
        private readonly IMapper _mapper;

        public MaritalStatusService(
            IMaritalStatusModelRepository maritalStatusModelRepository,
            IMapper mapper
        )
        {
            _maritalStatusModelRepository = maritalStatusModelRepository;
            _mapper = mapper;
        }

        public async Task<List<MaritalStatusResponseDto>> GetAllMaritalStatusAsync(
            CancellationToken cancellationToken = default
        )
        {
            var result = await _maritalStatusModelRepository.GetAllAsync(cancellationToken);

            return _mapper.Map<List<MaritalStatusResponseDto>>(result);
        }
    }
}
