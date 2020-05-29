using BookSubscription.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookSubscription.Persistance.Configuration
{
    public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
    {
        [System.Obsolete]
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.HasKey(e => new { e.BookId, e.CategoryId }).ForSqlServerIsClustered(false);

            builder.Property(e => e.BookId).HasColumnName("BookId");

            builder.Property(e => e.CategoryId).HasColumnName("CategoryId");

            builder.HasOne(d => d.Book)
                .WithMany(p => p.BookCategories)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookCategories_Books");

            builder.HasOne(d => d.Category)
                .WithMany(p => p.BookCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookCategories_Categories");
        }
    }
}
