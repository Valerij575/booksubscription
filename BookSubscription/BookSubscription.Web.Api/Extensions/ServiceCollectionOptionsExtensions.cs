using BookSubscription.Infrastructure.Configurations;
using BookSubscription.Infrastructure.Configurations.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookSubscription.Web.Api.Extensions
{
    public static class ServiceCollectionOptionsExtensions
    {
        public static void ConfigureAppsettingsOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SwaggerOptions>(configuration.GetSection(ConfigurationSectionNames.SwaggerOptions));
        }
    }
}
