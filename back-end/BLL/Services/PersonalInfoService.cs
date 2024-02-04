using AutoMapper;
using BLL.Contracts;
using BLL.DTOs;
using BLL.Exceptions;
using DAL.Contracts;
using DAL.Models;

namespace BLL.Services
{
    public class PersonalInfoService : IPersonalInfoService
    {
        private readonly IPersonalInfoModelRepository _personalInfoModelRepository;
        private readonly IMapper _mapper;

        public PersonalInfoService(IPersonalInfoModelRepository personalInfoModelRepository, IMapper mapper)
        {
            _personalInfoModelRepository = personalInfoModelRepository;
            _mapper = mapper;
        }
        public async Task<PersonalInfoResponseDto> CreatePersonalInfoAsync(PersonalInfoRequestDto personalInfoRequestDto, CancellationToken cancellationToken = default)
        {
            var personalInfoToCreate = _mapper.Map<PersonalInfoModel>(personalInfoRequestDto);
            var createdPersonalInfo = await _personalInfoModelRepository.AddAsync(personalInfoToCreate, cancellationToken);
            var result = _mapper.Map<PersonalInfoResponseDto>(createdPersonalInfo);
            return result;
        }

        public async Task<List<PersonalInfoResponseDto>> GetAllPersonalInfoAsync(CancellationToken cancellationToken = default)
        {
            var personalInfoList = await _personalInfoModelRepository.GetAllAsync(cancellationToken);
            var result = _mapper.Map<List<PersonalInfoResponseDto>>(personalInfoList);
            return result;
        }

        public async Task<PersonalInfoResponseDto> GetPersonalInfoByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var personalInfo = await _personalInfoModelRepository.GetByIdAsync(id, cancellationToken);
            var result = _mapper.Map<PersonalInfoResponseDto>(personalInfo);
            return result;
        }

        public async Task<PersonalInfoResponseDto> UpdatePersonalInfoByIdAsync(int id, PersonalInfoRequestDto personalInfoRequestDto, CancellationToken cancellationToken = default)
        {
            var existingPersonalInfo = await _personalInfoModelRepository.GetByIdAsync(id, cancellationToken);

            if (existingPersonalInfo == null)
            {
                throw new NotFoundException($"PersonalInfo with ID {id} not found");
            }

            _mapper.Map(personalInfoRequestDto, existingPersonalInfo);

            _personalInfoModelRepository.Update(existingPersonalInfo);

            var updatedPersonalInfo = await _personalInfoModelRepository.GetByIdAsync(id, cancellationToken);
            var result = _mapper.Map<PersonalInfoResponseDto>(updatedPersonalInfo);
            return result;
        }

        public async Task<PersonalInfoResponseDto> DeletePersonalInfoByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var personalInfoToDelete = await _personalInfoModelRepository.DeleteByIdAsync(id, cancellationToken);

            if (personalInfoToDelete == null)
            {
                throw new NotFoundException($"PersonalInfo with ID {id} not found");
            }

            var result = _mapper.Map<PersonalInfoResponseDto>(personalInfoToDelete);
            return result;
        }

    }
}