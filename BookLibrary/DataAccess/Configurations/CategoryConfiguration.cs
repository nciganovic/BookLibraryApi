using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
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
