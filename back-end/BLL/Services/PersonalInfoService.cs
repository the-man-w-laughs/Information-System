using AutoMapper;
using BLL.Contracts;
using DAL.Contracts;

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
    }
}