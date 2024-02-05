using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Presentation.Extensions
{
    public static class CorsExtensions
    {
        public static void ConfigureCors(
            this IServiceCollection services,
            ConfigurationManager config
        )
        {
            var reactClientOrigin = config["AllowedOrigins:ReactClientOrigin"];
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .SetIsOriginAllowed(origin => true)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }
    }
}
