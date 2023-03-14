using AM.Applicationcore.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
             .HasOne(s => s.Seat)
             .WithMany(s => s.Reservations)
             .HasForeignKey(s => s.SeatFK);
            builder
           .HasOne(r => r.Passenger)
           .WithMany(s => s.Reservations)
           .HasForeignKey(s => s.PassengerFK);
            builder.HasKey(s => new { s.SeatFK, s.PassengerFK, s.DateReservation });
        }
    }
}
