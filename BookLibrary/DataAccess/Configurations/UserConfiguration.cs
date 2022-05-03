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
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(au => au.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(au => au.LastName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(au => au.Email)
                .IsRequired();

            builder.Property(au => au.Password)
                .IsRequired();

            builder.Property(au => au.Salt)
                .IsRequired();

            builder.HasIndex(au => au.Email)
                .IsUnique();

            builder.HasOne(x => x.Role)
                .WithMany(r => r.Users)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Membership)
               .WithMany(m => m.Users)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
