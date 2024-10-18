using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Service.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "hackathon");

            migrationBuilder.CreateTable(
                name: "Tenants",
                schema: "hackathon",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                schema: "hackathon",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    is_rentable = table.Column<bool>(type: "boolean", nullable: false),
                    location = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.id);
                    table.ForeignKey(
                        name: "FK_Venues_Tenants_tenantId",
                        column: x => x.tenantId,
                        principalSchema: "hackathon",
                        principalTable: "Tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "venueItemEntities",
                schema: "hackathon",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    venue_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venueItemEntities", x => x.id);
                    table.ForeignKey(
                        name: "FK_venueItemEntities_Venues_venue_id",
                        column: x => x.venue_id,
                        principalSchema: "hackathon",
                        principalTable: "Venues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenueReservations",
                schema: "hackathon",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    venue_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    start_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    contact_email = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueReservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_VenueReservations_Venues_venue_id",
                        column: x => x.venue_id,
                        principalSchema: "hackathon",
                        principalTable: "Venues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenueRooms",
                schema: "hackathon",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    venue_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: false),
                    is_rentable = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueRooms", x => x.id);
                    table.ForeignKey(
                        name: "FK_VenueRooms_Venues_venue_id",
                        column: x => x.venue_id,
                        principalSchema: "hackathon",
                        principalTable: "Venues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenueReservationItems",
                schema: "hackathon",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    venue_reservation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueReservationItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_VenueReservationItems_VenueReservations_venue_reservation_id",
                        column: x => x.venue_reservation_id,
                        principalSchema: "hackathon",
                        principalTable: "VenueReservations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_venueItemEntities_venue_id",
                schema: "hackathon",
                table: "venueItemEntities",
                column: "venue_id");

            migrationBuilder.CreateIndex(
                name: "IX_VenueReservationItems_venue_reservation_id",
                schema: "hackathon",
                table: "VenueReservationItems",
                column: "venue_reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_VenueReservations_venue_id",
                schema: "hackathon",
                table: "VenueReservations",
                column: "venue_id");

            migrationBuilder.CreateIndex(
                name: "IX_VenueRooms_venue_id",
                schema: "hackathon",
                table: "VenueRooms",
                column: "venue_id");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_tenantId",
                schema: "hackathon",
                table: "Venues",
                column: "tenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "venueItemEntities",
                schema: "hackathon");

            migrationBuilder.DropTable(
                name: "VenueReservationItems",
                schema: "hackathon");

            migrationBuilder.DropTable(
                name: "VenueRooms",
                schema: "hackathon");

            migrationBuilder.DropTable(
                name: "VenueReservations",
                schema: "hackathon");

            migrationBuilder.DropTable(
                name: "Venues",
                schema: "hackathon");

            migrationBuilder.DropTable(
                name: "Tenants",
                schema: "hackathon");
        }
    }
}
