using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions
{
    public static class AutoMapperRegistrationExtensions
    {
        public static void RegisterAutomapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
