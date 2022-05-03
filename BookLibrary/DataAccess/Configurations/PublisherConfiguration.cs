using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class PublisherConfiguration : BaseEntityConfiguration<Publisher>
    {
        public override void Configure(EntityTypeBuilder<Publisher> builder)
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
