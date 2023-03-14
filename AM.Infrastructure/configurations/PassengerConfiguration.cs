using AM.Applicationcore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
       public void Configure(EntityTypeBuilder<Passenger> builder)
       {
            //builder.Property(p => p.FirstName)
            //   .IsRequired()
            //   .HasMaxLength(80)
            //    .HasDefaultValue("name")
            //    .HasColumnType("nchar");
            builder.OwnsOne(p => p.FullName1, f =>
            {
                f.Property(j => j.FirstName).HasColumnName("NomPassenger").IsRequired().HasColumnType("char").HasMaxLength(200);
                f.Property(j => j.LastName).HasColumnName("PrenomPassenger").IsRequired().HasColumnType("char");

            });
            //builder.HasDiscriminator<int>("IsTraveller").HasValue<Passenger>(2).HasValue<Traveller>(1).HasValue<Staff>(20);
    }
    }
}