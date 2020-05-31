using BookSubscription.Application.Interfaces;
using BookSubscription.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookSubscription.Persistance
{
    public class BookSubscriptionDbContext : DbContext
    {
        public BookSubscriptionDbContext(DbContextOptions<BookSubscriptionDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
