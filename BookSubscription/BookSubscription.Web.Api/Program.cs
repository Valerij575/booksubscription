using System;
using BookSubscription.Application.Interfaces;
using BookSubscription.Persistance;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookSubscription.Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetService<BookSubscriptionDbContext>();

                    var concreteContext = (BookSubscriptionDbContext)context;
                    concreteContext.Database.Migrate();
                    BookSubscriptionInitializer.Initialize(concreteContext);
                }
                catch(Exception ex)
                {
                    
                }
            }
            host.Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}
