using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Service.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationRequestEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "tenant_id",
                schema: "hackathon",
                table: "ReservationRequests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRequests_tenant_id",
                schema: "hackathon",
                table: "ReservationRequests",
                column: "tenant_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRequests_Tenants_tenant_id",
                schema: "hackathon",
                table: "ReservationRequests",
                column: "tenant_id",
                principalSchema: "hackathon",
                principalTable: "Tenants",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRequests_Tenants_tenant_id",
                schema: "hackathon",
                table: "ReservationRequests");

            migrationBuilder.DropIndex(
                name: "IX_ReservationRequests_tenant_id",
                schema: "hackathon",
                table: "ReservationRequests");

            migrationBuilder.DropColumn(
                name: "tenant_id",
                schema: "hackathon",
                table: "ReservationRequests");
        }
    }
}
