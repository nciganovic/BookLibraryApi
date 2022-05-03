using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Title)
                .HasMaxLength(80)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired(true);

            builder.Property(x => x.Pages)
                .IsRequired(true);

            builder.Property(x => x.AvailableUnits)
               .IsRequired(true);

            builder.Property(x => x.CoverImageSource)
              .IsRequired(true);

            builder.Property(x => x.ContentFileSource)
              .IsRequired(false);

            builder.Property(x => x.Year)
              .IsRequired(true);

            builder.HasOne(x => x.Publisher)
                .WithMany(p => p.Books)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Languague)
                .WithMany(l => l.Books)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Category)
               .WithMany(c => c.Books)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Category)
               .WithMany(c => c.Books)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Format)
              .WithMany(f => f.Books)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Property(au => au.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
