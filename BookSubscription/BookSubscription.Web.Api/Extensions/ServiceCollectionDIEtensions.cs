using BookSubscription.Application.Interfaces;
using BookSubscription.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookSubscription.Web.Api.Extensions
{
    public static class ServiceCollectionDIEtensions
    {
        /// <summary>
        /// Inject services.
        /// </summary>
        /// <param name="services"></param>
        public static void InjectApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IAccountService, AccountService>();
        }
    }
}
