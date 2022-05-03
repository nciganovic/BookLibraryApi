using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ReservationConfiguration : BaseEntityConfiguration<Reservation>
    {
        public override void Configure(EntityTypeBuilder<Reservation> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.StartTime)
                .IsRequired();

            builder.Property(x => x.EndTime)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(u => u.Reservations)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Books)
                .WithMany(x => x.Reservations);
        }
    }
}
