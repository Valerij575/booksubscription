using BookSubscription.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSubscription.Persistance.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("BookId");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.Text)
                .IsRequired()
                .HasColumnType("ntext");

            builder.Property(e => e.Price)
                .IsRequired()
                .HasColumnType("money")
                .HasDefaultValueSql("((0))");
        }
    }
}
