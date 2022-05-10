using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class MembershipConfiguration : BaseEntityConfiguration<Membership>
    {
        public override void Configure(EntityTypeBuilder<Membership> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .HasMaxLength(30)
                .IsRequired(true);

            builder.Property(x => x.MonthlyFee)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .HasMaxLength(300)
                .IsRequired(true);

            builder.HasIndex(x => x.Name)
                .IsUnique(true);
        }
    }
}
