using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyPlanes",
                columns: table => new
                {
                    PlaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaneCapacity = table.Column<int>(type: "int", nullable: false),
                    ManufactureDate = table.Column<DateTime>(type: "date", nullable: false),
                    PalneType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyPlanes", x => x.PlaneId);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassportNumber = table.Column<int>(type: "int", maxLength: 7, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassengerId = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NomPassenger = table.Column<string>(type: "char(200)", maxLength: 200, nullable: false),
                    PrenomPassenger = table.Column<string>(type: "char(100)", maxLength: 100, nullable: false),
                    TelNumber = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "date", nullable: true),
                    Function = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Salary = table.Column<float>(type: "real", nullable: true),
                    HealthInformation = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Nationality = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassportNumber);
                });

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
                name: "Vols",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Departure = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    FlightDate = table.Column<DateTime>(type: "date", nullable: false),
                    EffectiveArrival = table.Column<DateTime>(type: "date", nullable: false),
                    EstimatedDuration = table.Column<int>(type: "int", nullable: false),
                    FlightStatus = table.Column<int>(type: "int", nullable: false),
                    PlaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vols", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Vols_MyPlanes_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "MyPlanes",
                        principalColumn: "PlaneId",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Seats_Passengers_PassengerPassportNumber",
                        column: x => x.PassengerPassportNumber,
                        principalTable: "Passengers",
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
                name: "Ticket",
                columns: table => new
                {
                    PassengerFk = table.Column<int>(type: "int", nullable: false),
                    FlightFk = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<double>(type: "float(3)", precision: 3, scale: 2, nullable: false),
                    Siege = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    VIP = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => new { x.FlightFk, x.PassengerFk });
                    table.ForeignKey(
                        name: "FK_Ticket_Passengers_PassengerFk",
                        column: x => x.PassengerFk,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Vols_FlightFk",
                        column: x => x.FlightFk,
                        principalTable: "Vols",
                        principalColumn: "FlightId",
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
                        name: "FK_Reservations_Passengers_PassengerFK",
                        column: x => x.PassengerFK,
                        principalTable: "Passengers",
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

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PassengerFk",
                table: "Ticket",
                column: "PassengerFk");

            migrationBuilder.CreateIndex(
                name: "IX_Vols_PlaneId",
                table: "Vols",
                column: "PlaneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Vols");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "MyPlanes");
        }
    }
}
