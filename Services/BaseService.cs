using AutoMapper;
using Services.Utilities;
using ORMLibrary;

namespace Services
{
    public abstract class BaseService
    {
        static BaseService()
        {
        }

        protected static AppContext Context { get; private set; } = new AppContext();
        protected IMapper Mapper { get; private set; }

        protected BaseService()
        {
            Mapper = MappingRegistrar.CreateMapperConfiguration().CreateMapper();
        }
    }
}
