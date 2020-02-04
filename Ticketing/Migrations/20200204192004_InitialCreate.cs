using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticketing.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketPurchases",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "money", nullable: false),
                    ConfirmationCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPurchases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    VenueId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    VenueId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rows",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SectionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rows_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    RowId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Rows_RowId",
                        column: x => x.RowId,
                        principalTable: "Rows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventSeats",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SeatId = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventSeats_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventSeats_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketPurchaseSeats",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventSeatId = table.Column<Guid>(nullable: false),
                    Subtotal = table.Column<decimal>(type: "money", nullable: false),
                    TicketPurchaseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPurchaseSeats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketPurchaseSeats_EventSeats_EventSeatId",
                        column: x => x.EventSeatId,
                        principalTable: "EventSeats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketPurchaseSeats_TicketPurchases_TicketPurchaseId",
                        column: x => x.TicketPurchaseId,
                        principalTable: "TicketPurchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_VenueId",
                table: "Events",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSeats_EventId",
                table: "EventSeats",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventSeats_SeatId",
                table: "EventSeats",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Rows_SectionId",
                table: "Rows",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_RowId",
                table: "Seats",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_VenueId",
                table: "Sections",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchaseSeats_EventSeatId",
                table: "TicketPurchaseSeats",
                column: "EventSeatId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketPurchaseSeats_TicketPurchaseId",
                table: "TicketPurchaseSeats",
                column: "TicketPurchaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketPurchaseSeats");

            migrationBuilder.DropTable(
                name: "EventSeats");

            migrationBuilder.DropTable(
                name: "TicketPurchases");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Rows");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
