using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class RoleUserCaseConfiguration : BaseEntityConfiguration<RoleUserCase>
    {
        public override void Configure(EntityTypeBuilder<RoleUserCase> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.UseCaseId)
                .IsRequired(true);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.RoleUserCases)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
