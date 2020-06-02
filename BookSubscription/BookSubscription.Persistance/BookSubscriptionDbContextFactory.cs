using BookSubscription.Persistance.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSubscription.Persistance
{
    public class BookSubscriptionDbContextFactory : DesignTimeDbContextFactoryBase<BookSubscriptionDbContext>
    {
        protected override BookSubscriptionDbContext CreateNewInstance(DbContextOptions<BookSubscriptionDbContext> options)
        {
            return new BookSubscriptionDbContext(options);
        }
    }
}
