using DAL.Contracts;
using DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions
{
    public static class DALExtensions
    {
        public static void RegisterDLLDependencies(
            this IServiceCollection services,
            ConfigurationManager config
        )
        {
            services.ConfigureDatabaseConnection(config);
            services.AddScoped<ICitizenshipModelRepository, CitizenshipModelRepository>();
            services.AddScoped<ICityModelRepository, CityModelRepository>();
            services.AddScoped<IDisabilityModelRepository, DisabilityModelRepository>();
            services.AddScoped<IMaritalStatusModelRepository, MaritalStatusModelRepository>();
            services.AddScoped<IPersonalInfoModelRepository, PersonalInfoModelRepository>();
        }
    }
}