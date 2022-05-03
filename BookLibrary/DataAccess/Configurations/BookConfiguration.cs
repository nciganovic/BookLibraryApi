using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class BookConfiguration : BaseEntityConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            base.Configure(builder);

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
        }
    }
}
