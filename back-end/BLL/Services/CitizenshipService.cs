using AutoMapper;
using BLL.Contracts;
using BLL.DTOs;
using DAL.Contracts;

namespace BLL.Services
{
    public class CitizenshipService : ICitizenshipService
    {
        private readonly ICitizenshipModelRepository _citizenshipModelRepository;
        private readonly IMapper _mapper;

        public CitizenshipService(
            ICitizenshipModelRepository citizenshipModelRepository,
            IMapper mapper
        )
        {
            _citizenshipModelRepository = citizenshipModelRepository;
            _mapper = mapper;
        }

        public async Task<List<CitizenshipResponseDto>> GetAllCitizenshipAsync(
            CancellationToken cancellationToken = default
        )
        {
            var result = await _citizenshipModelRepository.GetAllAsync(cancellationToken);

            return _mapper.Map<List<CitizenshipResponseDto>>(result);
        }
    }
}
