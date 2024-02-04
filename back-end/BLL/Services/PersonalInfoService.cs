using AutoMapper;
using BLL.Contracts;
using BLL.DTOs;
using BLL.Exceptions;
using DAL.Contracts;
using DAL.Models;
using Shared.Repository.Sql;

namespace BLL.Services
{
    public class PersonalInfoService : IPersonalInfoService
    {
        private readonly IPersonalInfoModelRepository _personalInfoModelRepository;
        private readonly ICitizenshipModelRepository _citizenshipModelRepository;
        private readonly ICityModelRepository _cityModelRepository;
        private readonly IDisabilityModelRepository _disabilityModelRepository;
        private readonly IMaritalStatusModelRepository _maritalStatusModelRepository;
        private readonly IMapper _mapper;

        public PersonalInfoService(
            IPersonalInfoModelRepository personalInfoModelRepository,
            ICitizenshipModelRepository citizenshipModelRepository,
            ICityModelRepository cityModelRepository,
            IDisabilityModelRepository disabilityModelRepository,
            IMaritalStatusModelRepository maritalStatusModelRepository,
            IMapper mapper
        )
        {
            _personalInfoModelRepository = personalInfoModelRepository;
            _citizenshipModelRepository = citizenshipModelRepository;
            _cityModelRepository = cityModelRepository;
            _disabilityModelRepository = disabilityModelRepository;
            _maritalStatusModelRepository = maritalStatusModelRepository;
            _mapper = mapper;
        }

        public async Task<PersonalInfoResponseDto> CreatePersonalInfoAsync(
            PersonalInfoRequestDto personalInfoRequestDto,
            CancellationToken cancellationToken = default
        )
        {
            await ValidateRelatedEntities(personalInfoRequestDto, cancellationToken);

            var personalInfoToCreate = _mapper.Map<PersonalInfoModel>(personalInfoRequestDto);
            var createdPersonalInfo = await _personalInfoModelRepository.AddAsync(
                personalInfoToCreate,
                cancellationToken
            );
            await _personalInfoModelRepository.SaveAsync(cancellationToken);

            var result = _mapper.Map<PersonalInfoResponseDto>(createdPersonalInfo);

            return result;
        }

        public async Task<List<PersonalInfoResponseDto>> GetAllPersonalInfoAsync(
            CancellationToken cancellationToken = default
        )
        {
            var personalInfoList = await _personalInfoModelRepository.GetAllAsync(
                cancellationToken
            );
            var result = _mapper.Map<List<PersonalInfoResponseDto>>(personalInfoList);

            return result;
        }

        public async Task<PersonalInfoResponseDto> GetPersonalInfoByIdAsync(
            int id,
            CancellationToken cancellationToken = default
        )
        {
            var personalInfo = await _personalInfoModelRepository.GetByIdAsync(
                id,
                cancellationToken
            );

            if (personalInfo == null)
            {
                throw new NotFoundException($"PersonalInfo with ID {id} not found.");
            }

            var result = _mapper.Map<PersonalInfoResponseDto>(personalInfo);

            return result;
        }

        public async Task<PersonalInfoResponseDto> UpdatePersonalInfoByIdAsync(
            int id,
            PersonalInfoRequestDto personalInfoRequestDto,
            CancellationToken cancellationToken = default
        )
        {
            var existingPersonalInfo = await _personalInfoModelRepository.GetByIdAsync(
                id,
                cancellationToken
            );

            if (existingPersonalInfo == null)
            {
                throw new NotFoundException($"PersonalInfo with ID {id} not found");
            }

            await ValidateRelatedEntities(personalInfoRequestDto, cancellationToken);

            _mapper.Map(personalInfoRequestDto, existingPersonalInfo);

            _personalInfoModelRepository.Update(existingPersonalInfo);
            await _personalInfoModelRepository.SaveAsync();

            var result = _mapper.Map<PersonalInfoResponseDto>(existingPersonalInfo);

            return result;
        }

        public async Task<PersonalInfoResponseDto> DeletePersonalInfoByIdAsync(
            int id,
            CancellationToken cancellationToken = default
        )
        {
            var personalInfoToDelete = await _personalInfoModelRepository.DeleteByIdAsync(
                id,
                cancellationToken
            );

            await _personalInfoModelRepository.SaveAsync();

            if (personalInfoToDelete == null)
            {
                throw new NotFoundException($"PersonalInfo with ID {id} not found");
            }

            var result = _mapper.Map<PersonalInfoResponseDto>(personalInfoToDelete);

            return result;
        }

        private async Task ValidateEntityAsync<T>(
            IBaseRepository<T> repository,
            int entityId,
            string entityName,
            CancellationToken cancellationToken = default
        )
            where T : class, new()
        {
            var entity = await repository.GetByIdAsync(entityId, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException($"{entityName} with ID {entityId} not found.");
            }
        }

        private async Task ValidateRelatedEntities(
            PersonalInfoRequestDto personalInfoRequestDto,
            CancellationToken cancellationToken = default
        )
        {
            // Validate Disability
            await ValidateEntityAsync(
                _disabilityModelRepository,
                personalInfoRequestDto.DisabilityId,
                "Disability",
                cancellationToken
            );

            // Validate Citizenship
            await ValidateEntityAsync(
                _citizenshipModelRepository,
                personalInfoRequestDto.CitizenshipId,
                "Citizenship",
                cancellationToken
            );

            // Validate Current City
            await ValidateEntityAsync(
                _cityModelRepository,
                personalInfoRequestDto.CurrentCityId,
                "Current city",
                cancellationToken
            );

            // Validate Registration City
            await ValidateEntityAsync(
                _cityModelRepository,
                personalInfoRequestDto.RegistrationCityId,
                "Registration city",
                cancellationToken
            );

            // Validate Marital Status
            await ValidateEntityAsync(
                _maritalStatusModelRepository,
                personalInfoRequestDto.MaritalStatusId,
                "Marital status",
                cancellationToken
            );
        }
    }
}
