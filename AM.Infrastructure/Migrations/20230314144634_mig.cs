using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    IdSection = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.IdSection);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    SeatNumber = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    SectionFK = table.Column<int>(type: "int", nullable: false),
                    PlaneFK = table.Column<int>(type: "int", nullable: false),
                    PassengerPassportNumber = table.Column<int>(type: "int", nullable: true),
                    SeatId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seats_MyPlanes_PlaneFK",
                        column: x => x.PlaneFK,
                        principalTable: "MyPlanes",
                        principalColumn: "PlaneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seats_Passenger_PassengerPassportNumber",
                        column: x => x.PassengerPassportNumber,
                        principalTable: "Passenger",
                        principalColumn: "PassportNumber");
                    table.ForeignKey(
                        name: "FK_Seats_Seats_SeatId1",
                        column: x => x.SeatId1,
                        principalTable: "Seats",
                        principalColumn: "SeatId");
                    table.ForeignKey(
                        name: "FK_Seats_Sections_SectionFK",
                        column: x => x.SectionFK,
                        principalTable: "Sections",
                        principalColumn: "IdSection",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    DateReservation = table.Column<DateTime>(type: "date", nullable: false),
                    PassengerFK = table.Column<int>(type: "int", nullable: false),
                    SeatFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => new { x.SeatFK, x.PassengerFK, x.DateReservation });
                    table.ForeignKey(
                        name: "FK_Reservations_Passenger_PassengerFK",
                        column: x => x.PassengerFK,
                        principalTable: "Passenger",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Seats_SeatFK",
                        column: x => x.SeatFK,
                        principalTable: "Seats",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PassengerFK",
                table: "Reservations",
                column: "PassengerFK");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_PassengerPassportNumber",
                table: "Seats",
                column: "PassengerPassportNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_PlaneFK",
                table: "Seats",
                column: "PlaneFK");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SeatId1",
                table: "Seats",
                column: "SeatId1");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SectionFK",
                table: "Seats",
                column: "SectionFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
