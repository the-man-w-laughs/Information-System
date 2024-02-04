using System.Reflection;

namespace WebApi.Presentation.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerWithXmlComments(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
