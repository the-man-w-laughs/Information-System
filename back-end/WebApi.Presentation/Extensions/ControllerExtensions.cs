using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace WebApi.Presentation.Extensions
{
    public static class ControllerExtensions
    {
        public static IServiceCollection AddCustomControllers(this IServiceCollection services)
        {
            services.AddControllers(
                opts =>
                    opts.Conventions.Add(
                        new RouteTokenTransformerConvention(new ToKebabParameterTransformer())
                    )
            );

            return services;
        }
    }

    public class ToKebabParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object? value) => value?.ToString()?.ToKebabCase();
    }
}