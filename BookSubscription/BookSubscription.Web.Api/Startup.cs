using AutoMapper;
using BookSubscription.Infrastructure.Configurations.Options;
using BookSubscription.Persistance;
using BookSubscription.Web.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace BookSubscription.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add DbContext using SQL Server Provider
            services.AddDbContext<BookSubscriptionDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default")));

            
            services.ConfigureAppsettingsOptions(Configuration);
            services.InjectApplicationServices();
            services.AddSwaggerConfiguration(Configuration);
            services.AddIdentityConfiguration();

            services.AddCors(options =>
            {
                options.AddPolicy("BookSubscriptionClient", policy =>
                {
                    policy
                        .AllowCredentials()
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env,
            IOptions<SwaggerOptions> swaggerOptions)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("BookSubscriptionClient");

            // 10. Endpoint Routing Middleware (UseEndpoints with MapRazorPages).
            
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(string.Format(swaggerOptions.Value.UrlFormat, swaggerOptions.Value.Version), swaggerOptions.Value.Title);
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
