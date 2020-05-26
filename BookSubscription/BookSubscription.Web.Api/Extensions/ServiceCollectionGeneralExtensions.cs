using BookSubscription.Infrastructure.Configurations;
using BookSubscription.Infrastructure.Configurations.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace BookSubscription.Web.Api.Extensions
{
    public static class ServiceCollectionGeneralExtensions
    {
        /// <summary>
        /// Add swagger configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var swaggerConfig = configuration.GetSection(ConfigurationSectionNames.SwaggerOptions).Get<SwaggerOptions>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    swaggerConfig.Version, 
                    new OpenApiInfo 
                    { 
                        Title = swaggerConfig.Title,
                        Description = swaggerConfig.Description,
                        Version = swaggerConfig.Version,
                        Contact = new OpenApiContact
                        {
                            Name = swaggerConfig.Contract.Name,
                            Email = swaggerConfig.Contract.Email,
                            Url = swaggerConfig.Contract.Url
                        }
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
