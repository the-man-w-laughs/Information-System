using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions
{
    public static class DbConfigurationExtension
    {
        public static void ConfigureDatabaseConnection(
            this IServiceCollection services,
            ConfigurationManager config
        )
        {
            var connectionString = config.GetConnectionString("Default");
            services.AddDbContext<ClientDBContext>(options =>
            {
                options.UseMySQL(connectionString);
                options.UseLazyLoadingProxies();
            });
        }
    }
}
