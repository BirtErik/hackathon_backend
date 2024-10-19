using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Service.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVenueEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "capacity",
                schema: "hackathon",
                table: "Venues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "price",
                schema: "hackathon",
                table: "Venues",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "security_deposit",
                schema: "hackathon",
                table: "Venues",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "capacity",
                schema: "hackathon",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "price",
                schema: "hackathon",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "security_deposit",
                schema: "hackathon",
                table: "Venues");
        }
    }
}
