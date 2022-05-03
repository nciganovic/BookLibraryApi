using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class FormatConfiguration : BaseEntityConfiguration<Format>
    {
        public override void Configure(EntityTypeBuilder<Format> builder)
        {
            base.Configure(builder);

            builder.HasIndex(x => x.Name)
                .IsUnique(true);

            builder.Property(x => x.Name)
                .HasMaxLength(30)
                .IsRequired(true);
        }
    }
}
