using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions
{
    public static class BLLExtensions
    {
        public static void RegisterDLLDependencies(
            this IServiceCollection services,
            ConfigurationManager config
        )
        {
        }
    }
}