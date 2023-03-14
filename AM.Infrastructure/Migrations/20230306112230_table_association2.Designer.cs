﻿// <auto-generated />
using System;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    [DbContext(typeof(AmContext))]
    [Migration("20230306112230_table_association2")]
    partial class table_association2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AM.Applicationcore.Domain.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<string>("Departure")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("EffectiveArrival")
                        .HasColumnType("date");

                    b.Property<int>("EstimatedDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("date");

                    b.Property<int>("FlightStatus")
                        .HasColumnType("int");

                    b.Property<int>("PlaneId")
                        .HasColumnType("int");

                    b.HasKey("FlightId");

                    b.HasIndex("PlaneId");

                    b.ToTable("Vols", (string)null);
                });

            modelBuilder.Entity("AM.Applicationcore.Domain.Passenger", b =>
                {
                    b.Property<int>("PassportNumber")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(7)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassportNumber"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.Property<int>("TelNumber")
                        .HasColumnType("int");

                    b.HasKey("PassportNumber");

                    b.ToTable("Passenger", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("AM.Applicationcore.Domain.Plane", b =>
                {
                    b.Property<int>("PlaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaneId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("PlaneCapacity");

                    b.Property<DateTime>("ManufactureDate")
                        .HasColumnType("date");

                    b.Property<int>("PalneType")
                        .HasColumnType("int");

                    b.HasKey("PlaneId");

                    b.ToTable("MyPlanes", (string)null);
                });

            modelBuilder.Entity("AM.Applicationcore.Domain.Ticket", b =>
                {
                    b.Property<int>("FlightFk")
                        .HasColumnType("int");

                    b.Property<int>("PassengerFk")
                        .HasColumnType("int");

                    b.Property<double>("Prix")
                        .HasPrecision(3, 2)
                        .HasColumnType("float(3)");

                    b.Property<string>("Siege")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<bool>("VIP")
                        .HasColumnType("bit");

                    b.HasKey("FlightFk", "PassengerFk");

                    b.HasIndex("PassengerFk");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("AM.Applicationcore.Domain.Staff", b =>
                {
                    b.HasBaseType("AM.Applicationcore.Domain.Passenger");

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("date");

                    b.Property<string>("Function")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.ToTable("Staff", (string)null);
                });

            modelBuilder.Entity("AM.Applicationcore.Domain.Traveller", b =>
                {
                    b.HasBaseType("AM.Applicationcore.Domain.Passenger");

                    b.Property<string>("HealthInformation")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.ToTable("Traveller", (string)null);
                });

            modelBuilder.Entity("AM.Applicationcore.Domain.Flight", b =>
                {
                    b.HasOne("AM.Applicationcore.Domain.Plane", "plane")
                        .WithMany()
                        .HasForeignKey("PlaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("plane");
                });

            modelBuilder.Entity("AM.Applicationcore.Domain.Passenger", b =>
                {
                    b.OwnsOne("AM.Applicationcore.Domain.FullName", "FullName1", b1 =>
                        {
                            b1.Property<int>("PassengerPassportNumber")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("char")
                                .HasColumnName("NomPassenger");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("char")
                                .HasColumnName("PrenomPassenger");

                            b1.HasKey("PassengerPassportNumber");

                            b1.ToTable("Passenger");

                            b1.WithOwner()
                                .HasForeignKey("PassengerPassportNumber");
                        });

                    b.Navigation("FullName1")
                        .IsRequired();
                });

            modelBuilder.Entity("AM.Applicationcore.Domain.Ticket", b =>
                {
                    b.HasOne("AM.Applicationcore.Domain.Flight", "Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("FlightFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.Applicationcore.Domain.Passenger", "Passenger")
                        .WithMany("Tickets")
                        .HasForeignKey("PassengerFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("AM.Applicationcore.Domain.Staff", b =>
                {
                    b.HasOne("AM.Applicationcore.Domain.Passenger", null)
                        .WithOne()
                        .HasForeignKey("AM.Applicationcore.Domain.Staff", "PassportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AM.Applicationcore.Domain.Traveller", b =>
                {
                    b.HasOne("AM.Applicationcore.Domain.Passenger", null)
                        .WithOne()
                        .HasForeignKey("AM.Applicationcore.Domain.Traveller", "PassportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AM.Applicationcore.Domain.Flight", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("AM.Applicationcore.Domain.Passenger", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
