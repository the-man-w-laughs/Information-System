using AutoMapper;
using BLL.Contracts;
using BLL.DTOs;
using BLL.Exceptions;
using DAL.Contracts;
using DAL.Models;
using FluentValidation;

namespace BLL.Services
{
    public class PersonalInfoService : IPersonalInfoService
    {
        private readonly IPersonalInfoModelRepository _personalInfoModelRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<PersonalInfoRequestDto> _validator;

        public PersonalInfoService(
            IPersonalInfoModelRepository personalInfoModelRepository,
            IMapper mapper,
            IValidator<PersonalInfoRequestDto> validator
        )
        {
            _personalInfoModelRepository = personalInfoModelRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<PersonalInfoResponseDto> CreatePersonalInfoAsync(
            PersonalInfoRequestDto personalInfoRequestDto,
            CancellationToken cancellationToken = default
        )
        {
            await _validator.ValidateAndThrowAsync(personalInfoRequestDto);

            await EnsureUniquePassportNumberAsync(
                personalInfoRequestDto.PassportNumber,
                null,
                cancellationToken
            );

            await EnsureUniqueIdentificationNumberAsync(
                personalInfoRequestDto.IdentificationNumber,
                null,
                cancellationToken
            );

            var personalInfoToCreate = _mapper.Map<PersonalInfoModel>(personalInfoRequestDto);
            var createdPersonalInfo = await _personalInfoModelRepository.AddAsync(
                personalInfoToCreate,
                cancellationToken
            );
            await _personalInfoModelRepository.SaveAsync(cancellationToken);
            createdPersonalInfo = await _personalInfoModelRepository.GetByIdAsync(
                createdPersonalInfo.Id,
                cancellationToken
            );

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
                throw new NotFoundException(
                    $"Персональная информация с идентификатором {id} не найдена."
                );
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
            await _validator.ValidateAndThrowAsync(personalInfoRequestDto);

            var existingPersonalInfo = await _personalInfoModelRepository.GetByIdAsync(
                id,
                cancellationToken
            );

            if (existingPersonalInfo == null)
            {
                throw new NotFoundException(
                    $"Персональная информация с идентификатором {id} не найдена."
                );
            }

            await EnsureUniquePassportNumberAsync(
                personalInfoRequestDto.PassportNumber,
                existingPersonalInfo.Id,
                cancellationToken
            );
            await EnsureUniqueIdentificationNumberAsync(
                personalInfoRequestDto.IdentificationNumber,
                id,
                cancellationToken
            );

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
                throw new NotFoundException(
                    $"Персональная информация с идентификатором {id} не найдена."
                );
            }

            var result = _mapper.Map<PersonalInfoResponseDto>(personalInfoToDelete);

            return result;
        }

        private async Task EnsureUniquePassportNumberAsync(
            string? passportNumber,
            int? currentUserId,
            CancellationToken cancellationToken = default
        )
        {
            var existingUser = await _personalInfoModelRepository.GetAsync(
                personalInfo => personalInfo.PassportNumber == passportNumber,
                cancellationToken
            );

            if (existingUser != null && existingUser.Id != currentUserId)
            {
                throw new WrongActionException(
                    $"Пользователь с номером паспорта '{passportNumber}' уже существует."
                );
            }
        }

        private async Task EnsureUniqueIdentificationNumberAsync(
            string? identificationNumber,
            int? currentUserId,
            CancellationToken cancellationToken = default
        )
        {
            var existingUser = await _personalInfoModelRepository.GetAsync(
                personalInfo => personalInfo.IdentificationNumber == identificationNumber,
                cancellationToken
            );

            if (existingUser != null && existingUser.Id != currentUserId)
            {
                throw new WrongActionException(
                    $"Пользователь с идентификационным номером '{identificationNumber}' уже существует."
                );
            }
        }
    }
}
