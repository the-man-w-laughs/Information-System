using BLL.Contracts;
using BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions
{
    public static class BLLExtensions
    {
        public static void RegisterBLLDependencies(
            this IServiceCollection services,
            ConfigurationManager config
        )
        {
            services.AddScoped<IPersonalInfoService, PersonalInfoService>();
            services.AddScoped<ICitizenshipService, CitizenshipService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IDisabilityService, DisabilityService>();
            services.AddScoped<IMaritalStatusService, MaritalStatusService>();
        }
    }
}
