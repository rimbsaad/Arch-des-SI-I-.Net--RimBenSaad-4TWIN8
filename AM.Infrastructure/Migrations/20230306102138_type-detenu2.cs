using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class typedetenu2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EmploymentDate",
                table: "Passengers",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Function",
                table: "Passengers",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HealthInformation",
                table: "Passengers",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsTraveller",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Passengers",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Salary",
                table: "Passengers",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmploymentDate",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Function",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "HealthInformation",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "IsTraveller",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Passengers");
        }
    }
}
