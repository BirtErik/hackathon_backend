using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.Service.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestAndContractAndReportEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "venueItemEntities",
                schema: "hackathon");

            migrationBuilder.DropTable(
                name: "VenueReservationItems",
                schema: "hackathon");

            migrationBuilder.DropTable(
                name: "VenueReservations",
                schema: "hackathon");

            migrationBuilder.CreateTable(
                name: "Contracts",
                schema: "hackathon",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    venue_id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    oib = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    post_number = table.Column<string>(type: "text", nullable: false),
                    place = table.Column<string>(type: "text", nullable: false),
                    venue_name = table.Column<string>(type: "text", nullable: false),
                    venue_address = table.Column<string>(type: "text", nullable: false),
                    start_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    deposit = table.Column<double>(type: "double precision", nullable: false),
                    bills = table.Column<double>(type: "double precision", nullable: false),
                    vat = table.Column<double>(type: "double precision", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contracts_Venues_venue_id",
                        column: x => x.venue_id,
                        principalSchema: "hackathon",
                        principalTable: "Venues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationRequests",
                schema: "hackathon",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    venue_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    street_address = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    oib = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    bank_name = table.Column<string>(type: "text", nullable: false),
                    iban = table.Column<string>(type: "text", nullable: false),
                    purpose = table.Column<string>(type: "text", nullable: false),
                    start_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_ReservationRequests_Venues_venue_id",
                        column: x => x.venue_id,
                        principalSchema: "hackathon",
                        principalTable: "Venues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenueReports",
                schema: "hackathon",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    venue_id = table.Column<Guid>(type: "uuid", nullable: false),
                    venue_name = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    oib = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    post_number = table.Column<string>(type: "text", nullable: false),
                    place = table.Column<string>(type: "text", nullable: false),
                    state_before_usage = table.Column<string>(type: "text", nullable: false),
                    state_after_usage = table.Column<string>(type: "text", nullable: false),
                    damage = table.Column<string>(type: "text", nullable: false),
                    problems = table.Column<string>(type: "text", nullable: false),
                    inspection_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueReports", x => x.id);
                    table.ForeignKey(
                        name: "FK_VenueReports_Venues_venue_id",
                        column: x => x.venue_id,
                        principalSchema: "hackathon",
                        principalTable: "Venues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_venue_id",
                schema: "hackathon",
                table: "Contracts",
                column: "venue_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRequests_venue_id",
                schema: "hackathon",
                table: "ReservationRequests",
                column: "venue_id");

            migrationBuilder.CreateIndex(
                name: "IX_VenueReports_venue_id",
                schema: "hackathon",
                table: "VenueReports",
                column: "venue_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts",
                schema: "hackathon");

            migrationBuilder.DropTable(
                name: "ReservationRequests",
                schema: "hackathon");

            migrationBuilder.DropTable(
                name: "VenueReports",
                schema: "hackathon");

            migrationBuilder.CreateTable(
                name: "venueItemEntities",
                schema: "hackathon",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    venue_id = table.Column<Guid>(type: "uuid", nullable: false)
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
                    contact_email = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    end_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    start_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    venue_id = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "VenueReservationItems",
                schema: "hackathon",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    updated_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    venue_reservation_id = table.Column<Guid>(type: "uuid", nullable: false)
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
        }
    }
}
