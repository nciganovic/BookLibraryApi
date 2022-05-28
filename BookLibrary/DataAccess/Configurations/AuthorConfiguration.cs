using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class AuthorConfiguration : BaseEntityConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.FirstName)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(x => x.LastName)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(x => x.Bio)
               .HasMaxLength(300)
               .IsRequired(true);
        }
    }
}
