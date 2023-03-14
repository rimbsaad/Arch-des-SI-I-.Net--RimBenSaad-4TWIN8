using AM.Applicationcore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.configurations
{
   
        public class SeatConfiguration : IEntityTypeConfiguration<Seat>
        {
            public void Configure(EntityTypeBuilder<Seat> builder)
            {
                builder
                 .HasOne(s => s.Section)
                 .WithMany(s => s.Seats)
                 .HasForeignKey(s => s.SectionFK);
            }
        }
   
}
