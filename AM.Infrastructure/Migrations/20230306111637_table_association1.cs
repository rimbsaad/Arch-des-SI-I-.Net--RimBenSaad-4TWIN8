using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class table_association1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightPassenger");

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
                        name: "FK_Ticket_Passenger_PassengerFk",
                        column: x => x.PassengerFk,
                        principalTable: "Passenger",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Vols_FlightFk",
                        column: x => x.FlightFk,
                        principalTable: "Vols",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PassengerFk",
                table: "Ticket",
                column: "PassengerFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.CreateTable(
                name: "FlightPassenger",
                columns: table => new
                {
                    PassengersPassportNumber = table.Column<int>(type: "int", nullable: false),
                    flightsFlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightPassenger", x => new { x.PassengersPassportNumber, x.flightsFlightId });
                    table.ForeignKey(
                        name: "FK_FlightPassenger_Passenger_PassengersPassportNumber",
                        column: x => x.PassengersPassportNumber,
                        principalTable: "Passenger",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightPassenger_Vols_flightsFlightId",
                        column: x => x.flightsFlightId,
                        principalTable: "Vols",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPassenger_flightsFlightId",
                table: "FlightPassenger",
                column: "flightsFlightId");
        }
    }
}
