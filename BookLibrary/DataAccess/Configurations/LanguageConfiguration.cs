using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class LanguageConfiguration : BaseEntityConfiguration<Language>
    {
        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasIndex(x => x.Name)
                .IsUnique();
        }
    }
}
