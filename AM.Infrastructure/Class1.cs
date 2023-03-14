using AM.Applicationcore.Domain;
using Microsoft.EntityFrameworkCore;
using AM.Infrastructure.configurations;
using Microsoft.EntityFrameworkCore.Internal;

namespace AM.Infrastructure
{
    public class AmContext :DbContext

    {
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Flight> Flights{ get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Section> Sections { get; set; }


        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Staff> Staff { get; set; }
  
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=(localdb)\mssqllocaldb;" +
                "initial catalog = EmnaKhanfir; integrated security = true");
            optionsBuilder.UseLazyLoadingProxies(true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//configuratio Fluent API
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new SeatConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());

            /*modelBuilder.Entity<Flight>().HasKey(f=>f.FlightId);
            modelBuilder.Entity<Flight>().ToTable("vols");
            modelBuilder.Entity<Passenger>().Property(p => p.FirstName)
            .IsRequired()
            .HasMaxLength(80)
            .HasDefaultValue("name")
            .HasColumnType("nchar");*/

            // discriminator (une seule table mére) 
            //modelBuilder.Entity<Passenger>().HasDiscriminator<int>("IsTraveller").HasValue<Passenger>(2).HasValue<Traveller>(1).HasValue<Staff>(20);
            // (chaque fils a un table)
            modelBuilder.Entity<Passenger>().ToTable("Passenger");
            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<Traveller>().ToTable("Traveller");

           // modelBuilder.Entity<Ticket>().HasKey(p=> new {p.FlightFk, p.PassengerFk});

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)

        {
            configurationBuilder.Properties<string>()
                .HaveMaxLength(100)
                .HaveColumnType("varchar");
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
            configurationBuilder.Properties<double>().HavePrecision(3, 2);

        }
    

}
}