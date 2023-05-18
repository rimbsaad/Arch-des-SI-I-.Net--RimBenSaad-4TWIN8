using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PalneType",
                table: "MyPlanes",
                newName: "PlaneType");

            migrationBuilder.AddColumn<string>(
                name: "Pilote",
                table: "Vols",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pilote",
                table: "Vols");

            migrationBuilder.RenameColumn(
                name: "PlaneType",
                table: "MyPlanes",
                newName: "PalneType");
        }
    }
}
