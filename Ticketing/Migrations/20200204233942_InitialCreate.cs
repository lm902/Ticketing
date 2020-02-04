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
                    VenueId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rows",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SectionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rows_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    RowId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Rows_RowId",
                        column: x => x.RowId,
                        principalTable: "Rows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    TicketPurchaseId = table.Column<Guid>(nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000001010101"), null, 2.56m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-00000301010a"), null, 4.28m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000003010201"), null, 6.85m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000003010202"), null, 6.85m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000004010101"), null, 3.55m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000004010102"), null, 0.90m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000004010103"), null, 0.11m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000004010104"), null, 7.77m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000004010105"), null, 7.74m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000004010106"), null, 4.99m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000004010107"), null, 3.73m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000004010108"), null, 3.65m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000004010109"), null, 9.98m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-00000401010a"), null, 7.29m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000004010201"), null, 3.70m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000004010202"), null, 3.70m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000005010101"), null, 0.82m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000005010102"), null, 1.02m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000005010103"), null, 5.93m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000005010104"), null, 6.11m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000005010105"), null, 4.02m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000005010106"), null, 5.29m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000005010107"), null, 0.83m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000005010108"), null, 5.34m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000005010109"), null, 1.77m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-00000501010a"), null, 5.73m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000005010201"), null, 3.25m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000005010202"), null, 3.25m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000003010108"), null, 6.05m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000003010107"), null, 0.22m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000003010109"), null, 7.87m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000003010105"), null, 7.44m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000001010102"), null, 0.74m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000001010103"), null, 3.05m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000001010104"), null, 6.80m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000001010105"), null, 2.45m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000001010106"), null, 4.73m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000001010107"), null, 6.02m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000001010108"), null, 3.94m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000001010109"), null, 1.36m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-00000101010a"), null, 0.66m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000001010201"), null, 7.13m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000001010202"), null, 7.13m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000002010101"), null, 3.75m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000003010106"), null, 4.23m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000002010103"), null, 4.97m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000002010102"), null, 3.34m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000002010105"), null, 3.17m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000003010104"), null, 1.70m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000003010103"), null, 4.06m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000003010102"), null, 7.87m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000002010104"), null, 8.84m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000002010202"), null, 0.01m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000003010101"), null, 5.00m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-00000201010a"), null, 4.83m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000002010109"), null, 1.44m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000002010108"), null, 3.58m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000002010107"), null, 6.48m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000002010106"), null, 5.22m, "Cash" });

            migrationBuilder.InsertData(
                table: "TicketPurchases",
                columns: new[] { "Id", "ConfirmationCode", "PaymentAmount", "PaymentMethod" },
                values: new object[] { new Guid("00000000-0000-0004-0000-000002010201"), null, 0.01m, "Cash" });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004000000"), 100, "Venue 4" });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001000000"), 100, "Venue 1" });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002000000"), 100, "Venue 2" });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003000000"), 100, "Venue 3" });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005000000"), 100, "Venue 5" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Name", "VenueId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000100000000"), "Event 1", new Guid("00000000-0000-0001-0000-000001000000") });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Name", "VenueId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000200000000"), "Event 2", new Guid("00000000-0000-0001-0000-000002000000") });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Name", "VenueId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000300000000"), "Event 3", new Guid("00000000-0000-0001-0000-000003000000") });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Name", "VenueId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000400000000"), "Event 4", new Guid("00000000-0000-0001-0000-000004000000") });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Name", "VenueId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000500000000"), "Event 5", new Guid("00000000-0000-0001-0000-000005000000") });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Name", "VenueId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010000"), "Venue 1 Section 1", new Guid("00000000-0000-0001-0000-000001000000") });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Name", "VenueId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020000"), "Venue 1 Section 2", new Guid("00000000-0000-0001-0000-000001000000") });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Name", "VenueId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010000"), "Venue 2 Section 1", new Guid("00000000-0000-0001-0000-000002000000") });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Name", "VenueId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020000"), "Venue 2 Section 2", new Guid("00000000-0000-0001-0000-000002000000") });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Name", "VenueId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010000"), "Venue 3 Section 1", new Guid("00000000-0000-0001-0000-000003000000") });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Name", "VenueId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020000"), "Venue 3 Section 2", new Guid("00000000-0000-0001-0000-000003000000") });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Name", "VenueId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010000"), "Venue 4 Section 1", new Guid("00000000-0000-0001-0000-000004000000") });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Name", "VenueId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020000"), "Venue 4 Section 2", new Guid("00000000-0000-0001-0000-000004000000") });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Name", "VenueId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010000"), "Venue 5 Section 1", new Guid("00000000-0000-0001-0000-000005000000") });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Name", "VenueId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020000"), "Venue 5 Section 2", new Guid("00000000-0000-0001-0000-000005000000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010100"), "Venue 1 Section 1 Row 1", new Guid("00000000-0000-0001-0000-000001010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020300"), "Venue 3 Section 2 Row 3", new Guid("00000000-0000-0001-0000-000003020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020400"), "Venue 3 Section 2 Row 4", new Guid("00000000-0000-0001-0000-000003020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020500"), "Venue 3 Section 2 Row 5", new Guid("00000000-0000-0001-0000-000003020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010100"), "Venue 4 Section 1 Row 1", new Guid("00000000-0000-0001-0000-000004010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010200"), "Venue 4 Section 1 Row 2", new Guid("00000000-0000-0001-0000-000004010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010300"), "Venue 4 Section 1 Row 3", new Guid("00000000-0000-0001-0000-000004010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010400"), "Venue 4 Section 1 Row 4", new Guid("00000000-0000-0001-0000-000004010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010500"), "Venue 4 Section 1 Row 5", new Guid("00000000-0000-0001-0000-000004010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020100"), "Venue 4 Section 2 Row 1", new Guid("00000000-0000-0001-0000-000004020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020200"), "Venue 4 Section 2 Row 2", new Guid("00000000-0000-0001-0000-000004020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020300"), "Venue 4 Section 2 Row 3", new Guid("00000000-0000-0001-0000-000004020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020400"), "Venue 4 Section 2 Row 4", new Guid("00000000-0000-0001-0000-000004020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020500"), "Venue 4 Section 2 Row 5", new Guid("00000000-0000-0001-0000-000004020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010100"), "Venue 5 Section 1 Row 1", new Guid("00000000-0000-0001-0000-000005010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010200"), "Venue 5 Section 1 Row 2", new Guid("00000000-0000-0001-0000-000005010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010300"), "Venue 5 Section 1 Row 3", new Guid("00000000-0000-0001-0000-000005010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010400"), "Venue 5 Section 1 Row 4", new Guid("00000000-0000-0001-0000-000005010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010500"), "Venue 5 Section 1 Row 5", new Guid("00000000-0000-0001-0000-000005010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020100"), "Venue 5 Section 2 Row 1", new Guid("00000000-0000-0001-0000-000005020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020200"), "Venue 5 Section 2 Row 2", new Guid("00000000-0000-0001-0000-000005020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020300"), "Venue 5 Section 2 Row 3", new Guid("00000000-0000-0001-0000-000005020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020200"), "Venue 3 Section 2 Row 2", new Guid("00000000-0000-0001-0000-000003020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020100"), "Venue 3 Section 2 Row 1", new Guid("00000000-0000-0001-0000-000003020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010500"), "Venue 3 Section 1 Row 5", new Guid("00000000-0000-0001-0000-000003010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010400"), "Venue 3 Section 1 Row 4", new Guid("00000000-0000-0001-0000-000003010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010200"), "Venue 1 Section 1 Row 2", new Guid("00000000-0000-0001-0000-000001010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010300"), "Venue 1 Section 1 Row 3", new Guid("00000000-0000-0001-0000-000001010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010400"), "Venue 1 Section 1 Row 4", new Guid("00000000-0000-0001-0000-000001010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010500"), "Venue 1 Section 1 Row 5", new Guid("00000000-0000-0001-0000-000001010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020100"), "Venue 1 Section 2 Row 1", new Guid("00000000-0000-0001-0000-000001020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020200"), "Venue 1 Section 2 Row 2", new Guid("00000000-0000-0001-0000-000001020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020300"), "Venue 1 Section 2 Row 3", new Guid("00000000-0000-0001-0000-000001020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020400"), "Venue 1 Section 2 Row 4", new Guid("00000000-0000-0001-0000-000001020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020500"), "Venue 1 Section 2 Row 5", new Guid("00000000-0000-0001-0000-000001020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010100"), "Venue 2 Section 1 Row 1", new Guid("00000000-0000-0001-0000-000002010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020400"), "Venue 5 Section 2 Row 4", new Guid("00000000-0000-0001-0000-000005020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010200"), "Venue 2 Section 1 Row 2", new Guid("00000000-0000-0001-0000-000002010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010400"), "Venue 2 Section 1 Row 4", new Guid("00000000-0000-0001-0000-000002010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010500"), "Venue 2 Section 1 Row 5", new Guid("00000000-0000-0001-0000-000002010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020100"), "Venue 2 Section 2 Row 1", new Guid("00000000-0000-0001-0000-000002020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020200"), "Venue 2 Section 2 Row 2", new Guid("00000000-0000-0001-0000-000002020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020300"), "Venue 2 Section 2 Row 3", new Guid("00000000-0000-0001-0000-000002020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020400"), "Venue 2 Section 2 Row 4", new Guid("00000000-0000-0001-0000-000002020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020500"), "Venue 2 Section 2 Row 5", new Guid("00000000-0000-0001-0000-000002020000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010100"), "Venue 3 Section 1 Row 1", new Guid("00000000-0000-0001-0000-000003010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010200"), "Venue 3 Section 1 Row 2", new Guid("00000000-0000-0001-0000-000003010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010300"), "Venue 3 Section 1 Row 3", new Guid("00000000-0000-0001-0000-000003010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010300"), "Venue 2 Section 1 Row 3", new Guid("00000000-0000-0001-0000-000002010000") });

            migrationBuilder.InsertData(
                table: "Rows",
                columns: new[] { "Id", "Name", "SectionId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020500"), "Venue 5 Section 2 Row 5", new Guid("00000000-0000-0001-0000-000005020000") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010101"), "Venue 1 Section 1 Row 1 Seat 1", 4.12m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010502"), "Venue 4 Section 1 Row 5 Seat 2", 2.34m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010501"), "Venue 4 Section 1 Row 5 Seat 1", 7.22m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000401040a"), "Venue 4 Section 1 Row 4 Seat 10", 5.92m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010409"), "Venue 4 Section 1 Row 4 Seat 9", 9.84m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010408"), "Venue 4 Section 1 Row 4 Seat 8", 3.27m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010407"), "Venue 4 Section 1 Row 4 Seat 7", 9.97m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010406"), "Venue 4 Section 1 Row 4 Seat 6", 4.34m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010405"), "Venue 4 Section 1 Row 4 Seat 5", 6.88m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010404"), "Venue 4 Section 1 Row 4 Seat 4", 7.14m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010403"), "Venue 4 Section 1 Row 4 Seat 3", 7.55m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010402"), "Venue 4 Section 1 Row 4 Seat 2", 4.14m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010401"), "Venue 4 Section 1 Row 4 Seat 1", 7.40m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000401030a"), "Venue 4 Section 1 Row 3 Seat 10", 5.85m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010309"), "Venue 4 Section 1 Row 3 Seat 9", 9.05m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010308"), "Venue 4 Section 1 Row 3 Seat 8", 4.74m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010307"), "Venue 4 Section 1 Row 3 Seat 7", 3.91m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010306"), "Venue 4 Section 1 Row 3 Seat 6", 3.30m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010305"), "Venue 4 Section 1 Row 3 Seat 5", 8.78m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010304"), "Venue 4 Section 1 Row 3 Seat 4", 9.28m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010303"), "Venue 4 Section 1 Row 3 Seat 3", 7.16m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010302"), "Venue 4 Section 1 Row 3 Seat 2", 1.67m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010301"), "Venue 4 Section 1 Row 3 Seat 1", 3.46m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000401020a"), "Venue 4 Section 1 Row 2 Seat 10", 7.98m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010209"), "Venue 4 Section 1 Row 2 Seat 9", 9.13m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010208"), "Venue 4 Section 1 Row 2 Seat 8", 7.57m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010207"), "Venue 4 Section 1 Row 2 Seat 7", 1.56m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010206"), "Venue 4 Section 1 Row 2 Seat 6", 3.08m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010503"), "Venue 4 Section 1 Row 5 Seat 3", 5.14m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010205"), "Venue 4 Section 1 Row 2 Seat 5", 5.66m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010504"), "Venue 4 Section 1 Row 5 Seat 4", 9.49m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010506"), "Venue 4 Section 1 Row 5 Seat 6", 2.98m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020303"), "Venue 4 Section 2 Row 3 Seat 3", 9.06m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020302"), "Venue 4 Section 2 Row 3 Seat 2", 7.95m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020301"), "Venue 4 Section 2 Row 3 Seat 1", 5.07m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000402020a"), "Venue 4 Section 2 Row 2 Seat 10", 6.68m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020209"), "Venue 4 Section 2 Row 2 Seat 9", 5.28m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020208"), "Venue 4 Section 2 Row 2 Seat 8", 4.02m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020207"), "Venue 4 Section 2 Row 2 Seat 7", 2.28m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020206"), "Venue 4 Section 2 Row 2 Seat 6", 2.36m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020205"), "Venue 4 Section 2 Row 2 Seat 5", 7.30m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020204"), "Venue 4 Section 2 Row 2 Seat 4", 2.21m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020203"), "Venue 4 Section 2 Row 2 Seat 3", 2.71m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020202"), "Venue 4 Section 2 Row 2 Seat 2", 6.61m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020201"), "Venue 4 Section 2 Row 2 Seat 1", 3.98m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000402010a"), "Venue 4 Section 2 Row 1 Seat 10", 1.80m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020109"), "Venue 4 Section 2 Row 1 Seat 9", 3.30m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020108"), "Venue 4 Section 2 Row 1 Seat 8", 9.43m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020107"), "Venue 4 Section 2 Row 1 Seat 7", 6.36m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020106"), "Venue 4 Section 2 Row 1 Seat 6", 0.23m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020105"), "Venue 4 Section 2 Row 1 Seat 5", 6.07m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020104"), "Venue 4 Section 2 Row 1 Seat 4", 9.91m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020103"), "Venue 4 Section 2 Row 1 Seat 3", 8.21m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020102"), "Venue 4 Section 2 Row 1 Seat 2", 2.15m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020101"), "Venue 4 Section 2 Row 1 Seat 1", 3.80m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000401050a"), "Venue 4 Section 1 Row 5 Seat 10", 1.81m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010509"), "Venue 4 Section 1 Row 5 Seat 9", 7.33m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010508"), "Venue 4 Section 1 Row 5 Seat 8", 4.15m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010507"), "Venue 4 Section 1 Row 5 Seat 7", 3.95m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010505"), "Venue 4 Section 1 Row 5 Seat 5", 6.24m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010204"), "Venue 4 Section 1 Row 2 Seat 4", 4.69m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010203"), "Venue 4 Section 1 Row 2 Seat 3", 6.98m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010202"), "Venue 4 Section 1 Row 2 Seat 2", 1.67m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020309"), "Venue 3 Section 2 Row 3 Seat 9", 7.49m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020308"), "Venue 3 Section 2 Row 3 Seat 8", 0.39m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020307"), "Venue 3 Section 2 Row 3 Seat 7", 4.30m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020306"), "Venue 3 Section 2 Row 3 Seat 6", 1.35m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020305"), "Venue 3 Section 2 Row 3 Seat 5", 4.45m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020304"), "Venue 3 Section 2 Row 3 Seat 4", 3.36m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020303"), "Venue 3 Section 2 Row 3 Seat 3", 8.92m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020302"), "Venue 3 Section 2 Row 3 Seat 2", 0.14m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020301"), "Venue 3 Section 2 Row 3 Seat 1", 1.26m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000302020a"), "Venue 3 Section 2 Row 2 Seat 10", 9.47m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020209"), "Venue 3 Section 2 Row 2 Seat 9", 2.49m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020208"), "Venue 3 Section 2 Row 2 Seat 8", 7.23m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020207"), "Venue 3 Section 2 Row 2 Seat 7", 5.90m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020206"), "Venue 3 Section 2 Row 2 Seat 6", 7.60m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020205"), "Venue 3 Section 2 Row 2 Seat 5", 6.58m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020204"), "Venue 3 Section 2 Row 2 Seat 4", 3.66m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020203"), "Venue 3 Section 2 Row 2 Seat 3", 8.61m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020202"), "Venue 3 Section 2 Row 2 Seat 2", 8.91m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020201"), "Venue 3 Section 2 Row 2 Seat 1", 1.77m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000302010a"), "Venue 3 Section 2 Row 1 Seat 10", 3.22m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020109"), "Venue 3 Section 2 Row 1 Seat 9", 5.15m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020108"), "Venue 3 Section 2 Row 1 Seat 8", 3.07m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020107"), "Venue 3 Section 2 Row 1 Seat 7", 7.19m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020106"), "Venue 3 Section 2 Row 1 Seat 6", 9.62m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020105"), "Venue 3 Section 2 Row 1 Seat 5", 7.37m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020104"), "Venue 3 Section 2 Row 1 Seat 4", 5.73m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020103"), "Venue 3 Section 2 Row 1 Seat 3", 2.30m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000302030a"), "Venue 3 Section 2 Row 3 Seat 10", 9.86m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020401"), "Venue 3 Section 2 Row 4 Seat 1", 0.14m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020402"), "Venue 3 Section 2 Row 4 Seat 2", 1.75m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020403"), "Venue 3 Section 2 Row 4 Seat 3", 0.47m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010201"), "Venue 4 Section 1 Row 2 Seat 1", 9.37m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000401010a"), "Venue 4 Section 1 Row 1 Seat 10", 1.22m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010109"), "Venue 4 Section 1 Row 1 Seat 9", 4.18m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010108"), "Venue 4 Section 1 Row 1 Seat 8", 5.92m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010107"), "Venue 4 Section 1 Row 1 Seat 7", 2.04m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010106"), "Venue 4 Section 1 Row 1 Seat 6", 5.09m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010105"), "Venue 4 Section 1 Row 1 Seat 5", 3.59m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010104"), "Venue 4 Section 1 Row 1 Seat 4", 4.97m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010103"), "Venue 4 Section 1 Row 1 Seat 3", 1.37m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010102"), "Venue 4 Section 1 Row 1 Seat 2", 3.57m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010101"), "Venue 4 Section 1 Row 1 Seat 1", 9.78m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000302050a"), "Venue 3 Section 2 Row 5 Seat 10", 8.00m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020509"), "Venue 3 Section 2 Row 5 Seat 9", 1.17m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020304"), "Venue 4 Section 2 Row 3 Seat 4", 2.29m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020508"), "Venue 3 Section 2 Row 5 Seat 8", 2.09m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020506"), "Venue 3 Section 2 Row 5 Seat 6", 0.09m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020505"), "Venue 3 Section 2 Row 5 Seat 5", 8.58m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020504"), "Venue 3 Section 2 Row 5 Seat 4", 1.87m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020503"), "Venue 3 Section 2 Row 5 Seat 3", 2.63m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020502"), "Venue 3 Section 2 Row 5 Seat 2", 9.12m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020501"), "Venue 3 Section 2 Row 5 Seat 1", 7.58m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000302040a"), "Venue 3 Section 2 Row 4 Seat 10", 2.61m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020409"), "Venue 3 Section 2 Row 4 Seat 9", 1.60m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020408"), "Venue 3 Section 2 Row 4 Seat 8", 5.80m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020407"), "Venue 3 Section 2 Row 4 Seat 7", 7.77m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020406"), "Venue 3 Section 2 Row 4 Seat 6", 9.62m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020405"), "Venue 3 Section 2 Row 4 Seat 5", 8.09m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020404"), "Venue 3 Section 2 Row 4 Seat 4", 4.58m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020507"), "Venue 3 Section 2 Row 5 Seat 7", 5.44m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020102"), "Venue 3 Section 2 Row 1 Seat 2", 5.80m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020305"), "Venue 4 Section 2 Row 3 Seat 5", 3.68m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020307"), "Venue 4 Section 2 Row 3 Seat 7", 4.71m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020207"), "Venue 5 Section 2 Row 2 Seat 7", 3.02m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020206"), "Venue 5 Section 2 Row 2 Seat 6", 2.38m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020205"), "Venue 5 Section 2 Row 2 Seat 5", 6.74m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020204"), "Venue 5 Section 2 Row 2 Seat 4", 5.92m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020203"), "Venue 5 Section 2 Row 2 Seat 3", 9.88m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020202"), "Venue 5 Section 2 Row 2 Seat 2", 6.41m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020201"), "Venue 5 Section 2 Row 2 Seat 1", 9.00m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000502010a"), "Venue 5 Section 2 Row 1 Seat 10", 3.64m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020109"), "Venue 5 Section 2 Row 1 Seat 9", 6.08m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020108"), "Venue 5 Section 2 Row 1 Seat 8", 6.64m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020107"), "Venue 5 Section 2 Row 1 Seat 7", 8.27m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020106"), "Venue 5 Section 2 Row 1 Seat 6", 6.19m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020105"), "Venue 5 Section 2 Row 1 Seat 5", 8.00m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020104"), "Venue 5 Section 2 Row 1 Seat 4", 7.71m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020103"), "Venue 5 Section 2 Row 1 Seat 3", 8.80m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020102"), "Venue 5 Section 2 Row 1 Seat 2", 0.03m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020101"), "Venue 5 Section 2 Row 1 Seat 1", 8.50m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000501050a"), "Venue 5 Section 1 Row 5 Seat 10", 4.95m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010509"), "Venue 5 Section 1 Row 5 Seat 9", 2.23m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010508"), "Venue 5 Section 1 Row 5 Seat 8", 2.07m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010507"), "Venue 5 Section 1 Row 5 Seat 7", 2.89m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010506"), "Venue 5 Section 1 Row 5 Seat 6", 4.88m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010505"), "Venue 5 Section 1 Row 5 Seat 5", 1.89m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010504"), "Venue 5 Section 1 Row 5 Seat 4", 4.86m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010503"), "Venue 5 Section 1 Row 5 Seat 3", 1.51m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010502"), "Venue 5 Section 1 Row 5 Seat 2", 7.89m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010501"), "Venue 5 Section 1 Row 5 Seat 1", 3.06m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020208"), "Venue 5 Section 2 Row 2 Seat 8", 4.62m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000501040a"), "Venue 5 Section 1 Row 4 Seat 10", 3.55m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020209"), "Venue 5 Section 2 Row 2 Seat 9", 5.17m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020301"), "Venue 5 Section 2 Row 3 Seat 1", 4.23m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020508"), "Venue 5 Section 2 Row 5 Seat 8", 7.11m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020507"), "Venue 5 Section 2 Row 5 Seat 7", 2.45m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020506"), "Venue 5 Section 2 Row 5 Seat 6", 9.93m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020505"), "Venue 5 Section 2 Row 5 Seat 5", 5.20m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020504"), "Venue 5 Section 2 Row 5 Seat 4", 6.90m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020503"), "Venue 5 Section 2 Row 5 Seat 3", 5.86m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020502"), "Venue 5 Section 2 Row 5 Seat 2", 9.64m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020501"), "Venue 5 Section 2 Row 5 Seat 1", 3.88m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000502040a"), "Venue 5 Section 2 Row 4 Seat 10", 6.30m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020409"), "Venue 5 Section 2 Row 4 Seat 9", 2.85m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020408"), "Venue 5 Section 2 Row 4 Seat 8", 5.37m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020407"), "Venue 5 Section 2 Row 4 Seat 7", 4.76m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020406"), "Venue 5 Section 2 Row 4 Seat 6", 2.33m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020405"), "Venue 5 Section 2 Row 4 Seat 5", 7.06m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020404"), "Venue 5 Section 2 Row 4 Seat 4", 1.41m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020403"), "Venue 5 Section 2 Row 4 Seat 3", 1.60m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020402"), "Venue 5 Section 2 Row 4 Seat 2", 3.48m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020401"), "Venue 5 Section 2 Row 4 Seat 1", 5.13m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000502030a"), "Venue 5 Section 2 Row 3 Seat 10", 3.68m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020309"), "Venue 5 Section 2 Row 3 Seat 9", 9.25m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020308"), "Venue 5 Section 2 Row 3 Seat 8", 5.57m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020307"), "Venue 5 Section 2 Row 3 Seat 7", 4.00m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020306"), "Venue 5 Section 2 Row 3 Seat 6", 2.50m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020305"), "Venue 5 Section 2 Row 3 Seat 5", 0.83m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020304"), "Venue 5 Section 2 Row 3 Seat 4", 5.79m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020303"), "Venue 5 Section 2 Row 3 Seat 3", 0.16m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020302"), "Venue 5 Section 2 Row 3 Seat 2", 1.34m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000502020a"), "Venue 5 Section 2 Row 2 Seat 10", 3.67m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010409"), "Venue 5 Section 1 Row 4 Seat 9", 6.76m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010408"), "Venue 5 Section 1 Row 4 Seat 8", 5.16m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010407"), "Venue 5 Section 1 Row 4 Seat 7", 6.16m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010104"), "Venue 5 Section 1 Row 1 Seat 4", 6.59m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010103"), "Venue 5 Section 1 Row 1 Seat 3", 3.15m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010102"), "Venue 5 Section 1 Row 1 Seat 2", 0.23m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010101"), "Venue 5 Section 1 Row 1 Seat 1", 8.93m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000402050a"), "Venue 4 Section 2 Row 5 Seat 10", 6.70m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020509"), "Venue 4 Section 2 Row 5 Seat 9", 0.08m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020508"), "Venue 4 Section 2 Row 5 Seat 8", 1.29m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020507"), "Venue 4 Section 2 Row 5 Seat 7", 7.06m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020506"), "Venue 4 Section 2 Row 5 Seat 6", 9.17m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020505"), "Venue 4 Section 2 Row 5 Seat 5", 0.73m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020504"), "Venue 4 Section 2 Row 5 Seat 4", 0.40m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020503"), "Venue 4 Section 2 Row 5 Seat 3", 9.14m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020502"), "Venue 4 Section 2 Row 5 Seat 2", 4.96m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020501"), "Venue 4 Section 2 Row 5 Seat 1", 5.20m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000402040a"), "Venue 4 Section 2 Row 4 Seat 10", 0.31m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020409"), "Venue 4 Section 2 Row 4 Seat 9", 6.97m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020408"), "Venue 4 Section 2 Row 4 Seat 8", 9.27m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020407"), "Venue 4 Section 2 Row 4 Seat 7", 4.35m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020406"), "Venue 4 Section 2 Row 4 Seat 6", 6.46m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020405"), "Venue 4 Section 2 Row 4 Seat 5", 5.81m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020404"), "Venue 4 Section 2 Row 4 Seat 4", 4.47m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020403"), "Venue 4 Section 2 Row 4 Seat 3", 4.49m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020402"), "Venue 4 Section 2 Row 4 Seat 2", 6.95m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020401"), "Venue 4 Section 2 Row 4 Seat 1", 6.71m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000402030a"), "Venue 4 Section 2 Row 3 Seat 10", 2.18m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020309"), "Venue 4 Section 2 Row 3 Seat 9", 1.61m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020308"), "Venue 4 Section 2 Row 3 Seat 8", 1.50m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010105"), "Venue 5 Section 1 Row 1 Seat 5", 2.95m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010106"), "Venue 5 Section 1 Row 1 Seat 6", 4.17m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010107"), "Venue 5 Section 1 Row 1 Seat 7", 5.20m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010108"), "Venue 5 Section 1 Row 1 Seat 8", 8.48m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010406"), "Venue 5 Section 1 Row 4 Seat 6", 1.94m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010405"), "Venue 5 Section 1 Row 4 Seat 5", 1.01m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010404"), "Venue 5 Section 1 Row 4 Seat 4", 1.74m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010403"), "Venue 5 Section 1 Row 4 Seat 3", 9.75m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010402"), "Venue 5 Section 1 Row 4 Seat 2", 9.11m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010401"), "Venue 5 Section 1 Row 4 Seat 1", 0.91m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000501030a"), "Venue 5 Section 1 Row 3 Seat 10", 3.01m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010309"), "Venue 5 Section 1 Row 3 Seat 9", 0.63m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010308"), "Venue 5 Section 1 Row 3 Seat 8", 6.80m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010307"), "Venue 5 Section 1 Row 3 Seat 7", 7.24m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010306"), "Venue 5 Section 1 Row 3 Seat 6", 8.08m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010305"), "Venue 5 Section 1 Row 3 Seat 5", 6.52m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010304"), "Venue 5 Section 1 Row 3 Seat 4", 2.17m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020306"), "Venue 4 Section 2 Row 3 Seat 6", 6.31m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010303"), "Venue 5 Section 1 Row 3 Seat 3", 6.64m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010301"), "Venue 5 Section 1 Row 3 Seat 1", 0.76m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000501020a"), "Venue 5 Section 1 Row 2 Seat 10", 5.40m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010209"), "Venue 5 Section 1 Row 2 Seat 9", 4.10m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010208"), "Venue 5 Section 1 Row 2 Seat 8", 7.51m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010207"), "Venue 5 Section 1 Row 2 Seat 7", 0.71m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010206"), "Venue 5 Section 1 Row 2 Seat 6", 4.02m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010205"), "Venue 5 Section 1 Row 2 Seat 5", 1.41m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010204"), "Venue 5 Section 1 Row 2 Seat 4", 4.45m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010203"), "Venue 5 Section 1 Row 2 Seat 3", 1.57m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010202"), "Venue 5 Section 1 Row 2 Seat 2", 0.89m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010201"), "Venue 5 Section 1 Row 2 Seat 1", 4.16m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000501010a"), "Venue 5 Section 1 Row 1 Seat 10", 9.99m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010109"), "Venue 5 Section 1 Row 1 Seat 9", 2.92m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010302"), "Venue 5 Section 1 Row 3 Seat 2", 1.01m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020101"), "Venue 3 Section 2 Row 1 Seat 1", 8.40m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000301050a"), "Venue 3 Section 1 Row 5 Seat 10", 8.94m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010509"), "Venue 3 Section 1 Row 5 Seat 9", 3.45m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020501"), "Venue 1 Section 2 Row 5 Seat 1", 8.62m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000102040a"), "Venue 1 Section 2 Row 4 Seat 10", 1.34m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020409"), "Venue 1 Section 2 Row 4 Seat 9", 3.46m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020408"), "Venue 1 Section 2 Row 4 Seat 8", 1.14m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020407"), "Venue 1 Section 2 Row 4 Seat 7", 3.40m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020406"), "Venue 1 Section 2 Row 4 Seat 6", 8.11m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020405"), "Venue 1 Section 2 Row 4 Seat 5", 4.12m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020404"), "Venue 1 Section 2 Row 4 Seat 4", 7.24m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020403"), "Venue 1 Section 2 Row 4 Seat 3", 2.73m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020402"), "Venue 1 Section 2 Row 4 Seat 2", 6.76m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020401"), "Venue 1 Section 2 Row 4 Seat 1", 1.52m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000102030a"), "Venue 1 Section 2 Row 3 Seat 10", 8.53m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020309"), "Venue 1 Section 2 Row 3 Seat 9", 1.60m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020308"), "Venue 1 Section 2 Row 3 Seat 8", 5.90m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020307"), "Venue 1 Section 2 Row 3 Seat 7", 6.87m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020306"), "Venue 1 Section 2 Row 3 Seat 6", 3.35m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020305"), "Venue 1 Section 2 Row 3 Seat 5", 3.38m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020304"), "Venue 1 Section 2 Row 3 Seat 4", 9.72m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020303"), "Venue 1 Section 2 Row 3 Seat 3", 0.34m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020302"), "Venue 1 Section 2 Row 3 Seat 2", 1.59m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020301"), "Venue 1 Section 2 Row 3 Seat 1", 8.58m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000102020a"), "Venue 1 Section 2 Row 2 Seat 10", 7.64m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020209"), "Venue 1 Section 2 Row 2 Seat 9", 3.27m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020208"), "Venue 1 Section 2 Row 2 Seat 8", 0.27m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020207"), "Venue 1 Section 2 Row 2 Seat 7", 9.71m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020206"), "Venue 1 Section 2 Row 2 Seat 6", 5.94m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020205"), "Venue 1 Section 2 Row 2 Seat 5", 3.24m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020502"), "Venue 1 Section 2 Row 5 Seat 2", 3.93m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020204"), "Venue 1 Section 2 Row 2 Seat 4", 1.35m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020503"), "Venue 1 Section 2 Row 5 Seat 3", 5.92m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020505"), "Venue 1 Section 2 Row 5 Seat 5", 5.92m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010302"), "Venue 2 Section 1 Row 3 Seat 2", 3.58m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010301"), "Venue 2 Section 1 Row 3 Seat 1", 1.57m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000201020a"), "Venue 2 Section 1 Row 2 Seat 10", 3.99m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010209"), "Venue 2 Section 1 Row 2 Seat 9", 0.20m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010208"), "Venue 2 Section 1 Row 2 Seat 8", 8.98m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010207"), "Venue 2 Section 1 Row 2 Seat 7", 2.53m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010206"), "Venue 2 Section 1 Row 2 Seat 6", 2.91m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010205"), "Venue 2 Section 1 Row 2 Seat 5", 8.46m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010204"), "Venue 2 Section 1 Row 2 Seat 4", 4.39m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010203"), "Venue 2 Section 1 Row 2 Seat 3", 5.14m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010202"), "Venue 2 Section 1 Row 2 Seat 2", 1.37m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010201"), "Venue 2 Section 1 Row 2 Seat 1", 8.00m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000201010a"), "Venue 2 Section 1 Row 1 Seat 10", 3.18m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010109"), "Venue 2 Section 1 Row 1 Seat 9", 0.58m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010108"), "Venue 2 Section 1 Row 1 Seat 8", 7.89m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010107"), "Venue 2 Section 1 Row 1 Seat 7", 7.18m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010106"), "Venue 2 Section 1 Row 1 Seat 6", 2.76m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010105"), "Venue 2 Section 1 Row 1 Seat 5", 8.95m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010104"), "Venue 2 Section 1 Row 1 Seat 4", 6.83m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010103"), "Venue 2 Section 1 Row 1 Seat 3", 0.08m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010102"), "Venue 2 Section 1 Row 1 Seat 2", 4.89m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010101"), "Venue 2 Section 1 Row 1 Seat 1", 5.75m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000102050a"), "Venue 1 Section 2 Row 5 Seat 10", 5.27m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020509"), "Venue 1 Section 2 Row 5 Seat 9", 1.14m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020508"), "Venue 1 Section 2 Row 5 Seat 8", 6.81m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020507"), "Venue 1 Section 2 Row 5 Seat 7", 7.83m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020506"), "Venue 1 Section 2 Row 5 Seat 6", 7.47m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020504"), "Venue 1 Section 2 Row 5 Seat 4", 9.59m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020203"), "Venue 1 Section 2 Row 2 Seat 3", 6.18m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020202"), "Venue 1 Section 2 Row 2 Seat 2", 6.59m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020201"), "Venue 1 Section 2 Row 2 Seat 1", 5.88m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010308"), "Venue 1 Section 1 Row 3 Seat 8", 1.51m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010307"), "Venue 1 Section 1 Row 3 Seat 7", 1.62m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010306"), "Venue 1 Section 1 Row 3 Seat 6", 2.22m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010305"), "Venue 1 Section 1 Row 3 Seat 5", 4.05m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010304"), "Venue 1 Section 1 Row 3 Seat 4", 7.87m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010303"), "Venue 1 Section 1 Row 3 Seat 3", 2.00m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010302"), "Venue 1 Section 1 Row 3 Seat 2", 2.49m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010301"), "Venue 1 Section 1 Row 3 Seat 1", 6.30m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000101020a"), "Venue 1 Section 1 Row 2 Seat 10", 3.81m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010209"), "Venue 1 Section 1 Row 2 Seat 9", 6.83m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010208"), "Venue 1 Section 1 Row 2 Seat 8", 8.74m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010207"), "Venue 1 Section 1 Row 2 Seat 7", 0.12m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010206"), "Venue 1 Section 1 Row 2 Seat 6", 0.88m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010205"), "Venue 1 Section 1 Row 2 Seat 5", 2.94m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010204"), "Venue 1 Section 1 Row 2 Seat 4", 4.45m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010203"), "Venue 1 Section 1 Row 2 Seat 3", 1.93m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010202"), "Venue 1 Section 1 Row 2 Seat 2", 8.68m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010201"), "Venue 1 Section 1 Row 2 Seat 1", 7.03m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000101010a"), "Venue 1 Section 1 Row 1 Seat 10", 4.83m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010109"), "Venue 1 Section 1 Row 1 Seat 9", 5.86m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010108"), "Venue 1 Section 1 Row 1 Seat 8", 9.58m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010107"), "Venue 1 Section 1 Row 1 Seat 7", 6.09m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010106"), "Venue 1 Section 1 Row 1 Seat 6", 7.95m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010105"), "Venue 1 Section 1 Row 1 Seat 5", 3.26m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010104"), "Venue 1 Section 1 Row 1 Seat 4", 8.56m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010103"), "Venue 1 Section 1 Row 1 Seat 3", 5.38m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010102"), "Venue 1 Section 1 Row 1 Seat 2", 7.38m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010309"), "Venue 1 Section 1 Row 3 Seat 9", 5.29m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000101030a"), "Venue 1 Section 1 Row 3 Seat 10", 6.73m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010401"), "Venue 1 Section 1 Row 4 Seat 1", 3.06m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010402"), "Venue 1 Section 1 Row 4 Seat 2", 5.52m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000102010a"), "Venue 1 Section 2 Row 1 Seat 10", 4.00m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020109"), "Venue 1 Section 2 Row 1 Seat 9", 7.72m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020108"), "Venue 1 Section 2 Row 1 Seat 8", 8.38m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020107"), "Venue 1 Section 2 Row 1 Seat 7", 3.54m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020106"), "Venue 1 Section 2 Row 1 Seat 6", 2.32m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020105"), "Venue 1 Section 2 Row 1 Seat 5", 0.88m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020104"), "Venue 1 Section 2 Row 1 Seat 4", 3.41m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020103"), "Venue 1 Section 2 Row 1 Seat 3", 8.63m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020102"), "Venue 1 Section 2 Row 1 Seat 2", 0.20m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020101"), "Venue 1 Section 2 Row 1 Seat 1", 3.85m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000101050a"), "Venue 1 Section 1 Row 5 Seat 10", 0.42m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010509"), "Venue 1 Section 1 Row 5 Seat 9", 8.68m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010508"), "Venue 1 Section 1 Row 5 Seat 8", 0.16m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010303"), "Venue 2 Section 1 Row 3 Seat 3", 7.06m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010507"), "Venue 1 Section 1 Row 5 Seat 7", 9.78m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010505"), "Venue 1 Section 1 Row 5 Seat 5", 4.89m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010504"), "Venue 1 Section 1 Row 5 Seat 4", 6.12m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010503"), "Venue 1 Section 1 Row 5 Seat 3", 9.41m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010502"), "Venue 1 Section 1 Row 5 Seat 2", 9.29m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010501"), "Venue 1 Section 1 Row 5 Seat 1", 5.46m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000101040a"), "Venue 1 Section 1 Row 4 Seat 10", 1.82m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010409"), "Venue 1 Section 1 Row 4 Seat 9", 5.55m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010408"), "Venue 1 Section 1 Row 4 Seat 8", 8.55m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010407"), "Venue 1 Section 1 Row 4 Seat 7", 7.27m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010406"), "Venue 1 Section 1 Row 4 Seat 6", 9.82m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010405"), "Venue 1 Section 1 Row 4 Seat 5", 2.56m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010404"), "Venue 1 Section 1 Row 4 Seat 4", 5.74m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010403"), "Venue 1 Section 1 Row 4 Seat 3", 9.92m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010506"), "Venue 1 Section 1 Row 5 Seat 6", 4.95m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010304"), "Venue 2 Section 1 Row 3 Seat 4", 3.13m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010305"), "Venue 2 Section 1 Row 3 Seat 5", 1.83m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010306"), "Venue 2 Section 1 Row 3 Seat 6", 2.70m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010206"), "Venue 3 Section 1 Row 2 Seat 6", 0.24m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010205"), "Venue 3 Section 1 Row 2 Seat 5", 2.00m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010204"), "Venue 3 Section 1 Row 2 Seat 4", 0.58m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010203"), "Venue 3 Section 1 Row 2 Seat 3", 9.70m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010202"), "Venue 3 Section 1 Row 2 Seat 2", 4.26m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010201"), "Venue 3 Section 1 Row 2 Seat 1", 9.94m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000301010a"), "Venue 3 Section 1 Row 1 Seat 10", 8.19m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010109"), "Venue 3 Section 1 Row 1 Seat 9", 2.38m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010108"), "Venue 3 Section 1 Row 1 Seat 8", 6.88m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010107"), "Venue 3 Section 1 Row 1 Seat 7", 3.95m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010106"), "Venue 3 Section 1 Row 1 Seat 6", 9.42m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010105"), "Venue 3 Section 1 Row 1 Seat 5", 1.30m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010104"), "Venue 3 Section 1 Row 1 Seat 4", 0.87m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010103"), "Venue 3 Section 1 Row 1 Seat 3", 3.97m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010102"), "Venue 3 Section 1 Row 1 Seat 2", 5.66m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010101"), "Venue 3 Section 1 Row 1 Seat 1", 4.85m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000202050a"), "Venue 2 Section 2 Row 5 Seat 10", 7.24m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020509"), "Venue 2 Section 2 Row 5 Seat 9", 5.45m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020508"), "Venue 2 Section 2 Row 5 Seat 8", 7.72m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020507"), "Venue 2 Section 2 Row 5 Seat 7", 3.69m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020506"), "Venue 2 Section 2 Row 5 Seat 6", 5.86m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020505"), "Venue 2 Section 2 Row 5 Seat 5", 9.37m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020504"), "Venue 2 Section 2 Row 5 Seat 4", 6.55m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020503"), "Venue 2 Section 2 Row 5 Seat 3", 9.96m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020502"), "Venue 2 Section 2 Row 5 Seat 2", 2.15m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020501"), "Venue 2 Section 2 Row 5 Seat 1", 5.78m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000202040a"), "Venue 2 Section 2 Row 4 Seat 10", 8.92m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010207"), "Venue 3 Section 1 Row 2 Seat 7", 1.80m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010208"), "Venue 3 Section 1 Row 2 Seat 8", 8.28m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010209"), "Venue 3 Section 1 Row 2 Seat 9", 5.29m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000301020a"), "Venue 3 Section 1 Row 2 Seat 10", 1.01m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010508"), "Venue 3 Section 1 Row 5 Seat 8", 7.39m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010507"), "Venue 3 Section 1 Row 5 Seat 7", 5.68m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010506"), "Venue 3 Section 1 Row 5 Seat 6", 8.27m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010505"), "Venue 3 Section 1 Row 5 Seat 5", 4.75m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010504"), "Venue 3 Section 1 Row 5 Seat 4", 9.46m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010503"), "Venue 3 Section 1 Row 5 Seat 3", 4.25m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010502"), "Venue 3 Section 1 Row 5 Seat 2", 1.98m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010501"), "Venue 3 Section 1 Row 5 Seat 1", 2.20m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000301040a"), "Venue 3 Section 1 Row 4 Seat 10", 9.33m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010409"), "Venue 3 Section 1 Row 4 Seat 9", 1.90m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010408"), "Venue 3 Section 1 Row 4 Seat 8", 8.70m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010407"), "Venue 3 Section 1 Row 4 Seat 7", 9.31m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010406"), "Venue 3 Section 1 Row 4 Seat 6", 9.71m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020409"), "Venue 2 Section 2 Row 4 Seat 9", 0.81m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010405"), "Venue 3 Section 1 Row 4 Seat 5", 8.27m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010403"), "Venue 3 Section 1 Row 4 Seat 3", 2.26m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010402"), "Venue 3 Section 1 Row 4 Seat 2", 7.23m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010401"), "Venue 3 Section 1 Row 4 Seat 1", 8.62m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000301030a"), "Venue 3 Section 1 Row 3 Seat 10", 9.15m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010309"), "Venue 3 Section 1 Row 3 Seat 9", 3.53m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010308"), "Venue 3 Section 1 Row 3 Seat 8", 7.33m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010307"), "Venue 3 Section 1 Row 3 Seat 7", 0.51m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010306"), "Venue 3 Section 1 Row 3 Seat 6", 1.36m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010305"), "Venue 3 Section 1 Row 3 Seat 5", 3.55m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010304"), "Venue 3 Section 1 Row 3 Seat 4", 8.28m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010303"), "Venue 3 Section 1 Row 3 Seat 3", 1.60m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010302"), "Venue 3 Section 1 Row 3 Seat 2", 3.21m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010301"), "Venue 3 Section 1 Row 3 Seat 1", 1.84m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010404"), "Venue 3 Section 1 Row 4 Seat 4", 7.47m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020509"), "Venue 5 Section 2 Row 5 Seat 9", 2.94m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020408"), "Venue 2 Section 2 Row 4 Seat 8", 4.34m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020406"), "Venue 2 Section 2 Row 4 Seat 6", 7.42m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020103"), "Venue 2 Section 2 Row 1 Seat 3", 1.56m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020102"), "Venue 2 Section 2 Row 1 Seat 2", 5.77m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020101"), "Venue 2 Section 2 Row 1 Seat 1", 5.37m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000201050a"), "Venue 2 Section 1 Row 5 Seat 10", 1.31m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010509"), "Venue 2 Section 1 Row 5 Seat 9", 3.48m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010508"), "Venue 2 Section 1 Row 5 Seat 8", 8.94m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010507"), "Venue 2 Section 1 Row 5 Seat 7", 5.57m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010506"), "Venue 2 Section 1 Row 5 Seat 6", 8.20m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010505"), "Venue 2 Section 1 Row 5 Seat 5", 5.21m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010504"), "Venue 2 Section 1 Row 5 Seat 4", 9.47m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010503"), "Venue 2 Section 1 Row 5 Seat 3", 6.84m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010502"), "Venue 2 Section 1 Row 5 Seat 2", 7.45m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010501"), "Venue 2 Section 1 Row 5 Seat 1", 7.05m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000201040a"), "Venue 2 Section 1 Row 4 Seat 10", 5.82m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010409"), "Venue 2 Section 1 Row 4 Seat 9", 8.78m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010408"), "Venue 2 Section 1 Row 4 Seat 8", 4.32m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010407"), "Venue 2 Section 1 Row 4 Seat 7", 3.92m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010406"), "Venue 2 Section 1 Row 4 Seat 6", 2.37m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010405"), "Venue 2 Section 1 Row 4 Seat 5", 1.92m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010404"), "Venue 2 Section 1 Row 4 Seat 4", 2.32m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010403"), "Venue 2 Section 1 Row 4 Seat 3", 2.40m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010402"), "Venue 2 Section 1 Row 4 Seat 2", 6.29m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010401"), "Venue 2 Section 1 Row 4 Seat 1", 6.84m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000201030a"), "Venue 2 Section 1 Row 3 Seat 10", 5.58m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010309"), "Venue 2 Section 1 Row 3 Seat 9", 4.85m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010308"), "Venue 2 Section 1 Row 3 Seat 8", 6.39m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010307"), "Venue 2 Section 1 Row 3 Seat 7", 5.43m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020104"), "Venue 2 Section 2 Row 1 Seat 4", 3.90m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020105"), "Venue 2 Section 2 Row 1 Seat 5", 2.23m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020106"), "Venue 2 Section 2 Row 1 Seat 6", 6.40m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020107"), "Venue 2 Section 2 Row 1 Seat 7", 7.99m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020405"), "Venue 2 Section 2 Row 4 Seat 5", 4.26m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020404"), "Venue 2 Section 2 Row 4 Seat 4", 9.04m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020403"), "Venue 2 Section 2 Row 4 Seat 3", 1.61m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020402"), "Venue 2 Section 2 Row 4 Seat 2", 7.78m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020401"), "Venue 2 Section 2 Row 4 Seat 1", 7.64m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000202030a"), "Venue 2 Section 2 Row 3 Seat 10", 8.56m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020309"), "Venue 2 Section 2 Row 3 Seat 9", 5.41m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020308"), "Venue 2 Section 2 Row 3 Seat 8", 9.03m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020307"), "Venue 2 Section 2 Row 3 Seat 7", 9.83m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020306"), "Venue 2 Section 2 Row 3 Seat 6", 2.13m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020305"), "Venue 2 Section 2 Row 3 Seat 5", 9.46m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020304"), "Venue 2 Section 2 Row 3 Seat 4", 0.19m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020303"), "Venue 2 Section 2 Row 3 Seat 3", 9.20m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020407"), "Venue 2 Section 2 Row 4 Seat 7", 7.02m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020302"), "Venue 2 Section 2 Row 3 Seat 2", 5.53m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000202020a"), "Venue 2 Section 2 Row 2 Seat 10", 4.75m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020209"), "Venue 2 Section 2 Row 2 Seat 9", 2.72m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020208"), "Venue 2 Section 2 Row 2 Seat 8", 3.87m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020207"), "Venue 2 Section 2 Row 2 Seat 7", 8.14m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020206"), "Venue 2 Section 2 Row 2 Seat 6", 6.55m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020205"), "Venue 2 Section 2 Row 2 Seat 5", 0.25m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020204"), "Venue 2 Section 2 Row 2 Seat 4", 5.64m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020203"), "Venue 2 Section 2 Row 2 Seat 3", 8.43m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020202"), "Venue 2 Section 2 Row 2 Seat 2", 2.15m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020201"), "Venue 2 Section 2 Row 2 Seat 1", 0.17m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000202010a"), "Venue 2 Section 2 Row 1 Seat 10", 4.35m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020109"), "Venue 2 Section 2 Row 1 Seat 9", 1.89m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020108"), "Venue 2 Section 2 Row 1 Seat 8", 4.64m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020301"), "Venue 2 Section 2 Row 3 Seat 1", 2.97m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000502050a"), "Venue 5 Section 2 Row 5 Seat 10", 8.09m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010101"), new Guid("00000000-0000-0001-0000-000100000000"), 6.70m, new Guid("00000000-0000-0001-0000-000001010101") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010502"), new Guid("00000000-0000-0001-0000-000400000000"), 7.63m, new Guid("00000000-0000-0001-0000-000004010502") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010501"), new Guid("00000000-0000-0001-0000-000400000000"), 0.18m, new Guid("00000000-0000-0001-0000-000004010501") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000401040a"), new Guid("00000000-0000-0001-0000-000400000000"), 0.56m, new Guid("00000000-0000-0001-0000-00000401040a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010409"), new Guid("00000000-0000-0001-0000-000400000000"), 6.83m, new Guid("00000000-0000-0001-0000-000004010409") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010408"), new Guid("00000000-0000-0001-0000-000400000000"), 2.42m, new Guid("00000000-0000-0001-0000-000004010408") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010407"), new Guid("00000000-0000-0001-0000-000400000000"), 4.19m, new Guid("00000000-0000-0001-0000-000004010407") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010406"), new Guid("00000000-0000-0001-0000-000400000000"), 8.90m, new Guid("00000000-0000-0001-0000-000004010406") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010405"), new Guid("00000000-0000-0001-0000-000400000000"), 8.42m, new Guid("00000000-0000-0001-0000-000004010405") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010404"), new Guid("00000000-0000-0001-0000-000400000000"), 5.59m, new Guid("00000000-0000-0001-0000-000004010404") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010403"), new Guid("00000000-0000-0001-0000-000400000000"), 6.21m, new Guid("00000000-0000-0001-0000-000004010403") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010402"), new Guid("00000000-0000-0001-0000-000400000000"), 9.68m, new Guid("00000000-0000-0001-0000-000004010402") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010401"), new Guid("00000000-0000-0001-0000-000400000000"), 8.38m, new Guid("00000000-0000-0001-0000-000004010401") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000401030a"), new Guid("00000000-0000-0001-0000-000400000000"), 9.39m, new Guid("00000000-0000-0001-0000-00000401030a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010309"), new Guid("00000000-0000-0001-0000-000400000000"), 5.01m, new Guid("00000000-0000-0001-0000-000004010309") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010308"), new Guid("00000000-0000-0001-0000-000400000000"), 2.80m, new Guid("00000000-0000-0001-0000-000004010308") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010307"), new Guid("00000000-0000-0001-0000-000400000000"), 2.07m, new Guid("00000000-0000-0001-0000-000004010307") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010306"), new Guid("00000000-0000-0001-0000-000400000000"), 2.62m, new Guid("00000000-0000-0001-0000-000004010306") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010305"), new Guid("00000000-0000-0001-0000-000400000000"), 5.29m, new Guid("00000000-0000-0001-0000-000004010305") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010304"), new Guid("00000000-0000-0001-0000-000400000000"), 1.77m, new Guid("00000000-0000-0001-0000-000004010304") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010303"), new Guid("00000000-0000-0001-0000-000400000000"), 3.68m, new Guid("00000000-0000-0001-0000-000004010303") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010302"), new Guid("00000000-0000-0001-0000-000400000000"), 2.10m, new Guid("00000000-0000-0001-0000-000004010302") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010301"), new Guid("00000000-0000-0001-0000-000400000000"), 4.21m, new Guid("00000000-0000-0001-0000-000004010301") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000401020a"), new Guid("00000000-0000-0001-0000-000400000000"), 4.29m, new Guid("00000000-0000-0001-0000-00000401020a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010209"), new Guid("00000000-0000-0001-0000-000400000000"), 2.54m, new Guid("00000000-0000-0001-0000-000004010209") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010208"), new Guid("00000000-0000-0001-0000-000400000000"), 4.77m, new Guid("00000000-0000-0001-0000-000004010208") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010207"), new Guid("00000000-0000-0001-0000-000400000000"), 3.72m, new Guid("00000000-0000-0001-0000-000004010207") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010206"), new Guid("00000000-0000-0001-0000-000400000000"), 6.14m, new Guid("00000000-0000-0001-0000-000004010206") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010503"), new Guid("00000000-0000-0001-0000-000400000000"), 7.72m, new Guid("00000000-0000-0001-0000-000004010503") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010205"), new Guid("00000000-0000-0001-0000-000400000000"), 1.18m, new Guid("00000000-0000-0001-0000-000004010205") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010504"), new Guid("00000000-0000-0001-0000-000400000000"), 6.75m, new Guid("00000000-0000-0001-0000-000004010504") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010506"), new Guid("00000000-0000-0001-0000-000400000000"), 1.38m, new Guid("00000000-0000-0001-0000-000004010506") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020303"), new Guid("00000000-0000-0001-0000-000400000000"), 0.75m, new Guid("00000000-0000-0001-0000-000004020303") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020302"), new Guid("00000000-0000-0001-0000-000400000000"), 3.92m, new Guid("00000000-0000-0001-0000-000004020302") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020301"), new Guid("00000000-0000-0001-0000-000400000000"), 9.77m, new Guid("00000000-0000-0001-0000-000004020301") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000402020a"), new Guid("00000000-0000-0001-0000-000400000000"), 0.74m, new Guid("00000000-0000-0001-0000-00000402020a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020209"), new Guid("00000000-0000-0001-0000-000400000000"), 1.98m, new Guid("00000000-0000-0001-0000-000004020209") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020208"), new Guid("00000000-0000-0001-0000-000400000000"), 3.53m, new Guid("00000000-0000-0001-0000-000004020208") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020207"), new Guid("00000000-0000-0001-0000-000400000000"), 4.97m, new Guid("00000000-0000-0001-0000-000004020207") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020206"), new Guid("00000000-0000-0001-0000-000400000000"), 7.85m, new Guid("00000000-0000-0001-0000-000004020206") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020205"), new Guid("00000000-0000-0001-0000-000400000000"), 8.19m, new Guid("00000000-0000-0001-0000-000004020205") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020204"), new Guid("00000000-0000-0001-0000-000400000000"), 1.38m, new Guid("00000000-0000-0001-0000-000004020204") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020203"), new Guid("00000000-0000-0001-0000-000400000000"), 0.22m, new Guid("00000000-0000-0001-0000-000004020203") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020202"), new Guid("00000000-0000-0001-0000-000400000000"), 2.11m, new Guid("00000000-0000-0001-0000-000004020202") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020201"), new Guid("00000000-0000-0001-0000-000400000000"), 7.66m, new Guid("00000000-0000-0001-0000-000004020201") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000402010a"), new Guid("00000000-0000-0001-0000-000400000000"), 7.09m, new Guid("00000000-0000-0001-0000-00000402010a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020109"), new Guid("00000000-0000-0001-0000-000400000000"), 3.77m, new Guid("00000000-0000-0001-0000-000004020109") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020108"), new Guid("00000000-0000-0001-0000-000400000000"), 4.48m, new Guid("00000000-0000-0001-0000-000004020108") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020107"), new Guid("00000000-0000-0001-0000-000400000000"), 2.56m, new Guid("00000000-0000-0001-0000-000004020107") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020106"), new Guid("00000000-0000-0001-0000-000400000000"), 9.48m, new Guid("00000000-0000-0001-0000-000004020106") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020105"), new Guid("00000000-0000-0001-0000-000400000000"), 9.58m, new Guid("00000000-0000-0001-0000-000004020105") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020104"), new Guid("00000000-0000-0001-0000-000400000000"), 6.99m, new Guid("00000000-0000-0001-0000-000004020104") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020103"), new Guid("00000000-0000-0001-0000-000400000000"), 1.66m, new Guid("00000000-0000-0001-0000-000004020103") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020102"), new Guid("00000000-0000-0001-0000-000400000000"), 7.62m, new Guid("00000000-0000-0001-0000-000004020102") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020101"), new Guid("00000000-0000-0001-0000-000400000000"), 0.96m, new Guid("00000000-0000-0001-0000-000004020101") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000401050a"), new Guid("00000000-0000-0001-0000-000400000000"), 8.22m, new Guid("00000000-0000-0001-0000-00000401050a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010509"), new Guid("00000000-0000-0001-0000-000400000000"), 9.25m, new Guid("00000000-0000-0001-0000-000004010509") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010508"), new Guid("00000000-0000-0001-0000-000400000000"), 2.34m, new Guid("00000000-0000-0001-0000-000004010508") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010507"), new Guid("00000000-0000-0001-0000-000400000000"), 5.85m, new Guid("00000000-0000-0001-0000-000004010507") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010505"), new Guid("00000000-0000-0001-0000-000400000000"), 2.03m, new Guid("00000000-0000-0001-0000-000004010505") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010204"), new Guid("00000000-0000-0001-0000-000400000000"), 3.86m, new Guid("00000000-0000-0001-0000-000004010204") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010203"), new Guid("00000000-0000-0001-0000-000400000000"), 9.24m, new Guid("00000000-0000-0001-0000-000004010203") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010202"), new Guid("00000000-0000-0001-0000-000400000000"), 5.82m, new Guid("00000000-0000-0001-0000-000004010202") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020309"), new Guid("00000000-0000-0001-0000-000300000000"), 8.80m, new Guid("00000000-0000-0001-0000-000003020309") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020308"), new Guid("00000000-0000-0001-0000-000300000000"), 1.18m, new Guid("00000000-0000-0001-0000-000003020308") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020307"), new Guid("00000000-0000-0001-0000-000300000000"), 6.41m, new Guid("00000000-0000-0001-0000-000003020307") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020306"), new Guid("00000000-0000-0001-0000-000300000000"), 0.73m, new Guid("00000000-0000-0001-0000-000003020306") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020305"), new Guid("00000000-0000-0001-0000-000300000000"), 9.80m, new Guid("00000000-0000-0001-0000-000003020305") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020304"), new Guid("00000000-0000-0001-0000-000300000000"), 4.89m, new Guid("00000000-0000-0001-0000-000003020304") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020303"), new Guid("00000000-0000-0001-0000-000300000000"), 2.32m, new Guid("00000000-0000-0001-0000-000003020303") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020302"), new Guid("00000000-0000-0001-0000-000300000000"), 1.20m, new Guid("00000000-0000-0001-0000-000003020302") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020301"), new Guid("00000000-0000-0001-0000-000300000000"), 5.66m, new Guid("00000000-0000-0001-0000-000003020301") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000302020a"), new Guid("00000000-0000-0001-0000-000300000000"), 4.97m, new Guid("00000000-0000-0001-0000-00000302020a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020209"), new Guid("00000000-0000-0001-0000-000300000000"), 8.03m, new Guid("00000000-0000-0001-0000-000003020209") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020208"), new Guid("00000000-0000-0001-0000-000300000000"), 0.32m, new Guid("00000000-0000-0001-0000-000003020208") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020207"), new Guid("00000000-0000-0001-0000-000300000000"), 1.70m, new Guid("00000000-0000-0001-0000-000003020207") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020206"), new Guid("00000000-0000-0001-0000-000300000000"), 8.91m, new Guid("00000000-0000-0001-0000-000003020206") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020205"), new Guid("00000000-0000-0001-0000-000300000000"), 6.72m, new Guid("00000000-0000-0001-0000-000003020205") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020204"), new Guid("00000000-0000-0001-0000-000300000000"), 6.31m, new Guid("00000000-0000-0001-0000-000003020204") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020203"), new Guid("00000000-0000-0001-0000-000300000000"), 3.68m, new Guid("00000000-0000-0001-0000-000003020203") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020202"), new Guid("00000000-0000-0001-0000-000300000000"), 4.26m, new Guid("00000000-0000-0001-0000-000003020202") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020201"), new Guid("00000000-0000-0001-0000-000300000000"), 4.48m, new Guid("00000000-0000-0001-0000-000003020201") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000302010a"), new Guid("00000000-0000-0001-0000-000300000000"), 9.80m, new Guid("00000000-0000-0001-0000-00000302010a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020109"), new Guid("00000000-0000-0001-0000-000300000000"), 9.98m, new Guid("00000000-0000-0001-0000-000003020109") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020108"), new Guid("00000000-0000-0001-0000-000300000000"), 4.85m, new Guid("00000000-0000-0001-0000-000003020108") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020107"), new Guid("00000000-0000-0001-0000-000300000000"), 8.05m, new Guid("00000000-0000-0001-0000-000003020107") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020106"), new Guid("00000000-0000-0001-0000-000300000000"), 3.22m, new Guid("00000000-0000-0001-0000-000003020106") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020105"), new Guid("00000000-0000-0001-0000-000300000000"), 0.81m, new Guid("00000000-0000-0001-0000-000003020105") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020104"), new Guid("00000000-0000-0001-0000-000300000000"), 1.07m, new Guid("00000000-0000-0001-0000-000003020104") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020103"), new Guid("00000000-0000-0001-0000-000300000000"), 6.55m, new Guid("00000000-0000-0001-0000-000003020103") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000302030a"), new Guid("00000000-0000-0001-0000-000300000000"), 5.89m, new Guid("00000000-0000-0001-0000-00000302030a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020401"), new Guid("00000000-0000-0001-0000-000300000000"), 6.68m, new Guid("00000000-0000-0001-0000-000003020401") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020402"), new Guid("00000000-0000-0001-0000-000300000000"), 7.91m, new Guid("00000000-0000-0001-0000-000003020402") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020403"), new Guid("00000000-0000-0001-0000-000300000000"), 7.98m, new Guid("00000000-0000-0001-0000-000003020403") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010201"), new Guid("00000000-0000-0001-0000-000400000000"), 4.24m, new Guid("00000000-0000-0001-0000-000004010201") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000401010a"), new Guid("00000000-0000-0001-0000-000400000000"), 9.47m, new Guid("00000000-0000-0001-0000-00000401010a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010109"), new Guid("00000000-0000-0001-0000-000400000000"), 0.69m, new Guid("00000000-0000-0001-0000-000004010109") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010108"), new Guid("00000000-0000-0001-0000-000400000000"), 6.21m, new Guid("00000000-0000-0001-0000-000004010108") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010107"), new Guid("00000000-0000-0001-0000-000400000000"), 7.19m, new Guid("00000000-0000-0001-0000-000004010107") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010106"), new Guid("00000000-0000-0001-0000-000400000000"), 1.44m, new Guid("00000000-0000-0001-0000-000004010106") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010105"), new Guid("00000000-0000-0001-0000-000400000000"), 3.37m, new Guid("00000000-0000-0001-0000-000004010105") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010104"), new Guid("00000000-0000-0001-0000-000400000000"), 2.54m, new Guid("00000000-0000-0001-0000-000004010104") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010103"), new Guid("00000000-0000-0001-0000-000400000000"), 4.82m, new Guid("00000000-0000-0001-0000-000004010103") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010102"), new Guid("00000000-0000-0001-0000-000400000000"), 5.57m, new Guid("00000000-0000-0001-0000-000004010102") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004010101"), new Guid("00000000-0000-0001-0000-000400000000"), 3.45m, new Guid("00000000-0000-0001-0000-000004010101") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000302050a"), new Guid("00000000-0000-0001-0000-000300000000"), 8.20m, new Guid("00000000-0000-0001-0000-00000302050a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020509"), new Guid("00000000-0000-0001-0000-000300000000"), 9.49m, new Guid("00000000-0000-0001-0000-000003020509") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020304"), new Guid("00000000-0000-0001-0000-000400000000"), 8.65m, new Guid("00000000-0000-0001-0000-000004020304") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020508"), new Guid("00000000-0000-0001-0000-000300000000"), 1.85m, new Guid("00000000-0000-0001-0000-000003020508") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020506"), new Guid("00000000-0000-0001-0000-000300000000"), 0.96m, new Guid("00000000-0000-0001-0000-000003020506") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020505"), new Guid("00000000-0000-0001-0000-000300000000"), 3.31m, new Guid("00000000-0000-0001-0000-000003020505") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020504"), new Guid("00000000-0000-0001-0000-000300000000"), 6.75m, new Guid("00000000-0000-0001-0000-000003020504") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020503"), new Guid("00000000-0000-0001-0000-000300000000"), 4.14m, new Guid("00000000-0000-0001-0000-000003020503") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020502"), new Guid("00000000-0000-0001-0000-000300000000"), 4.04m, new Guid("00000000-0000-0001-0000-000003020502") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020501"), new Guid("00000000-0000-0001-0000-000300000000"), 6.04m, new Guid("00000000-0000-0001-0000-000003020501") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000302040a"), new Guid("00000000-0000-0001-0000-000300000000"), 3.55m, new Guid("00000000-0000-0001-0000-00000302040a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020409"), new Guid("00000000-0000-0001-0000-000300000000"), 4.97m, new Guid("00000000-0000-0001-0000-000003020409") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020408"), new Guid("00000000-0000-0001-0000-000300000000"), 3.37m, new Guid("00000000-0000-0001-0000-000003020408") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020407"), new Guid("00000000-0000-0001-0000-000300000000"), 5.51m, new Guid("00000000-0000-0001-0000-000003020407") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020406"), new Guid("00000000-0000-0001-0000-000300000000"), 4.38m, new Guid("00000000-0000-0001-0000-000003020406") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020405"), new Guid("00000000-0000-0001-0000-000300000000"), 0.02m, new Guid("00000000-0000-0001-0000-000003020405") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020404"), new Guid("00000000-0000-0001-0000-000300000000"), 2.76m, new Guid("00000000-0000-0001-0000-000003020404") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020507"), new Guid("00000000-0000-0001-0000-000300000000"), 0.85m, new Guid("00000000-0000-0001-0000-000003020507") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020102"), new Guid("00000000-0000-0001-0000-000300000000"), 1.20m, new Guid("00000000-0000-0001-0000-000003020102") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020305"), new Guid("00000000-0000-0001-0000-000400000000"), 6.94m, new Guid("00000000-0000-0001-0000-000004020305") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020307"), new Guid("00000000-0000-0001-0000-000400000000"), 1.99m, new Guid("00000000-0000-0001-0000-000004020307") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020207"), new Guid("00000000-0000-0001-0000-000500000000"), 3.51m, new Guid("00000000-0000-0001-0000-000005020207") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020206"), new Guid("00000000-0000-0001-0000-000500000000"), 3.64m, new Guid("00000000-0000-0001-0000-000005020206") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020205"), new Guid("00000000-0000-0001-0000-000500000000"), 1.10m, new Guid("00000000-0000-0001-0000-000005020205") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020204"), new Guid("00000000-0000-0001-0000-000500000000"), 3.21m, new Guid("00000000-0000-0001-0000-000005020204") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020203"), new Guid("00000000-0000-0001-0000-000500000000"), 2.40m, new Guid("00000000-0000-0001-0000-000005020203") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020202"), new Guid("00000000-0000-0001-0000-000500000000"), 9.19m, new Guid("00000000-0000-0001-0000-000005020202") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020201"), new Guid("00000000-0000-0001-0000-000500000000"), 6.93m, new Guid("00000000-0000-0001-0000-000005020201") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000502010a"), new Guid("00000000-0000-0001-0000-000500000000"), 2.34m, new Guid("00000000-0000-0001-0000-00000502010a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020109"), new Guid("00000000-0000-0001-0000-000500000000"), 1.17m, new Guid("00000000-0000-0001-0000-000005020109") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020108"), new Guid("00000000-0000-0001-0000-000500000000"), 0.24m, new Guid("00000000-0000-0001-0000-000005020108") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020107"), new Guid("00000000-0000-0001-0000-000500000000"), 4.42m, new Guid("00000000-0000-0001-0000-000005020107") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020106"), new Guid("00000000-0000-0001-0000-000500000000"), 7.17m, new Guid("00000000-0000-0001-0000-000005020106") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020105"), new Guid("00000000-0000-0001-0000-000500000000"), 6.72m, new Guid("00000000-0000-0001-0000-000005020105") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020104"), new Guid("00000000-0000-0001-0000-000500000000"), 2.96m, new Guid("00000000-0000-0001-0000-000005020104") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020103"), new Guid("00000000-0000-0001-0000-000500000000"), 3.79m, new Guid("00000000-0000-0001-0000-000005020103") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020102"), new Guid("00000000-0000-0001-0000-000500000000"), 6.29m, new Guid("00000000-0000-0001-0000-000005020102") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020101"), new Guid("00000000-0000-0001-0000-000500000000"), 8.40m, new Guid("00000000-0000-0001-0000-000005020101") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000501050a"), new Guid("00000000-0000-0001-0000-000500000000"), 7.31m, new Guid("00000000-0000-0001-0000-00000501050a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010509"), new Guid("00000000-0000-0001-0000-000500000000"), 0.38m, new Guid("00000000-0000-0001-0000-000005010509") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010508"), new Guid("00000000-0000-0001-0000-000500000000"), 1.32m, new Guid("00000000-0000-0001-0000-000005010508") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010507"), new Guid("00000000-0000-0001-0000-000500000000"), 0.21m, new Guid("00000000-0000-0001-0000-000005010507") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010506"), new Guid("00000000-0000-0001-0000-000500000000"), 6.80m, new Guid("00000000-0000-0001-0000-000005010506") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010505"), new Guid("00000000-0000-0001-0000-000500000000"), 9.08m, new Guid("00000000-0000-0001-0000-000005010505") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010504"), new Guid("00000000-0000-0001-0000-000500000000"), 2.08m, new Guid("00000000-0000-0001-0000-000005010504") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010503"), new Guid("00000000-0000-0001-0000-000500000000"), 4.67m, new Guid("00000000-0000-0001-0000-000005010503") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010502"), new Guid("00000000-0000-0001-0000-000500000000"), 5.20m, new Guid("00000000-0000-0001-0000-000005010502") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010501"), new Guid("00000000-0000-0001-0000-000500000000"), 7.93m, new Guid("00000000-0000-0001-0000-000005010501") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020208"), new Guid("00000000-0000-0001-0000-000500000000"), 1.93m, new Guid("00000000-0000-0001-0000-000005020208") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000501040a"), new Guid("00000000-0000-0001-0000-000500000000"), 5.85m, new Guid("00000000-0000-0001-0000-00000501040a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020209"), new Guid("00000000-0000-0001-0000-000500000000"), 8.86m, new Guid("00000000-0000-0001-0000-000005020209") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020301"), new Guid("00000000-0000-0001-0000-000500000000"), 9.16m, new Guid("00000000-0000-0001-0000-000005020301") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020508"), new Guid("00000000-0000-0001-0000-000500000000"), 9.74m, new Guid("00000000-0000-0001-0000-000005020508") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020507"), new Guid("00000000-0000-0001-0000-000500000000"), 7.28m, new Guid("00000000-0000-0001-0000-000005020507") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020506"), new Guid("00000000-0000-0001-0000-000500000000"), 4.33m, new Guid("00000000-0000-0001-0000-000005020506") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020505"), new Guid("00000000-0000-0001-0000-000500000000"), 3.05m, new Guid("00000000-0000-0001-0000-000005020505") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020504"), new Guid("00000000-0000-0001-0000-000500000000"), 0.41m, new Guid("00000000-0000-0001-0000-000005020504") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020503"), new Guid("00000000-0000-0001-0000-000500000000"), 1.32m, new Guid("00000000-0000-0001-0000-000005020503") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020502"), new Guid("00000000-0000-0001-0000-000500000000"), 4.91m, new Guid("00000000-0000-0001-0000-000005020502") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020501"), new Guid("00000000-0000-0001-0000-000500000000"), 7.46m, new Guid("00000000-0000-0001-0000-000005020501") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000502040a"), new Guid("00000000-0000-0001-0000-000500000000"), 2.17m, new Guid("00000000-0000-0001-0000-00000502040a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020409"), new Guid("00000000-0000-0001-0000-000500000000"), 1.24m, new Guid("00000000-0000-0001-0000-000005020409") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020408"), new Guid("00000000-0000-0001-0000-000500000000"), 7.10m, new Guid("00000000-0000-0001-0000-000005020408") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020407"), new Guid("00000000-0000-0001-0000-000500000000"), 5.92m, new Guid("00000000-0000-0001-0000-000005020407") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020406"), new Guid("00000000-0000-0001-0000-000500000000"), 4.48m, new Guid("00000000-0000-0001-0000-000005020406") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020405"), new Guid("00000000-0000-0001-0000-000500000000"), 1.98m, new Guid("00000000-0000-0001-0000-000005020405") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020404"), new Guid("00000000-0000-0001-0000-000500000000"), 2.03m, new Guid("00000000-0000-0001-0000-000005020404") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020403"), new Guid("00000000-0000-0001-0000-000500000000"), 9.81m, new Guid("00000000-0000-0001-0000-000005020403") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020402"), new Guid("00000000-0000-0001-0000-000500000000"), 4.16m, new Guid("00000000-0000-0001-0000-000005020402") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020401"), new Guid("00000000-0000-0001-0000-000500000000"), 1.76m, new Guid("00000000-0000-0001-0000-000005020401") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000502030a"), new Guid("00000000-0000-0001-0000-000500000000"), 3.66m, new Guid("00000000-0000-0001-0000-00000502030a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020309"), new Guid("00000000-0000-0001-0000-000500000000"), 8.10m, new Guid("00000000-0000-0001-0000-000005020309") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020308"), new Guid("00000000-0000-0001-0000-000500000000"), 8.83m, new Guid("00000000-0000-0001-0000-000005020308") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020307"), new Guid("00000000-0000-0001-0000-000500000000"), 9.88m, new Guid("00000000-0000-0001-0000-000005020307") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020306"), new Guid("00000000-0000-0001-0000-000500000000"), 8.33m, new Guid("00000000-0000-0001-0000-000005020306") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020305"), new Guid("00000000-0000-0001-0000-000500000000"), 9.09m, new Guid("00000000-0000-0001-0000-000005020305") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020304"), new Guid("00000000-0000-0001-0000-000500000000"), 5.73m, new Guid("00000000-0000-0001-0000-000005020304") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020303"), new Guid("00000000-0000-0001-0000-000500000000"), 4.97m, new Guid("00000000-0000-0001-0000-000005020303") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020302"), new Guid("00000000-0000-0001-0000-000500000000"), 2.43m, new Guid("00000000-0000-0001-0000-000005020302") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000502020a"), new Guid("00000000-0000-0001-0000-000500000000"), 4.98m, new Guid("00000000-0000-0001-0000-00000502020a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010409"), new Guid("00000000-0000-0001-0000-000500000000"), 0.72m, new Guid("00000000-0000-0001-0000-000005010409") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010408"), new Guid("00000000-0000-0001-0000-000500000000"), 7.35m, new Guid("00000000-0000-0001-0000-000005010408") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010407"), new Guid("00000000-0000-0001-0000-000500000000"), 1.55m, new Guid("00000000-0000-0001-0000-000005010407") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010104"), new Guid("00000000-0000-0001-0000-000500000000"), 3.26m, new Guid("00000000-0000-0001-0000-000005010104") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010103"), new Guid("00000000-0000-0001-0000-000500000000"), 8.09m, new Guid("00000000-0000-0001-0000-000005010103") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010102"), new Guid("00000000-0000-0001-0000-000500000000"), 7.32m, new Guid("00000000-0000-0001-0000-000005010102") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010101"), new Guid("00000000-0000-0001-0000-000500000000"), 4.26m, new Guid("00000000-0000-0001-0000-000005010101") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000402050a"), new Guid("00000000-0000-0001-0000-000400000000"), 6.68m, new Guid("00000000-0000-0001-0000-00000402050a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020509"), new Guid("00000000-0000-0001-0000-000400000000"), 0.07m, new Guid("00000000-0000-0001-0000-000004020509") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020508"), new Guid("00000000-0000-0001-0000-000400000000"), 6.54m, new Guid("00000000-0000-0001-0000-000004020508") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020507"), new Guid("00000000-0000-0001-0000-000400000000"), 8.69m, new Guid("00000000-0000-0001-0000-000004020507") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020506"), new Guid("00000000-0000-0001-0000-000400000000"), 5.24m, new Guid("00000000-0000-0001-0000-000004020506") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020505"), new Guid("00000000-0000-0001-0000-000400000000"), 7.87m, new Guid("00000000-0000-0001-0000-000004020505") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020504"), new Guid("00000000-0000-0001-0000-000400000000"), 7.55m, new Guid("00000000-0000-0001-0000-000004020504") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020503"), new Guid("00000000-0000-0001-0000-000400000000"), 8.80m, new Guid("00000000-0000-0001-0000-000004020503") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020502"), new Guid("00000000-0000-0001-0000-000400000000"), 7.62m, new Guid("00000000-0000-0001-0000-000004020502") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020501"), new Guid("00000000-0000-0001-0000-000400000000"), 0.82m, new Guid("00000000-0000-0001-0000-000004020501") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000402040a"), new Guid("00000000-0000-0001-0000-000400000000"), 9.22m, new Guid("00000000-0000-0001-0000-00000402040a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020409"), new Guid("00000000-0000-0001-0000-000400000000"), 9.95m, new Guid("00000000-0000-0001-0000-000004020409") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020408"), new Guid("00000000-0000-0001-0000-000400000000"), 1.47m, new Guid("00000000-0000-0001-0000-000004020408") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020407"), new Guid("00000000-0000-0001-0000-000400000000"), 8.33m, new Guid("00000000-0000-0001-0000-000004020407") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020406"), new Guid("00000000-0000-0001-0000-000400000000"), 8.58m, new Guid("00000000-0000-0001-0000-000004020406") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020405"), new Guid("00000000-0000-0001-0000-000400000000"), 3.17m, new Guid("00000000-0000-0001-0000-000004020405") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020404"), new Guid("00000000-0000-0001-0000-000400000000"), 8.65m, new Guid("00000000-0000-0001-0000-000004020404") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020403"), new Guid("00000000-0000-0001-0000-000400000000"), 9.64m, new Guid("00000000-0000-0001-0000-000004020403") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020402"), new Guid("00000000-0000-0001-0000-000400000000"), 5.14m, new Guid("00000000-0000-0001-0000-000004020402") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020401"), new Guid("00000000-0000-0001-0000-000400000000"), 5.79m, new Guid("00000000-0000-0001-0000-000004020401") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000402030a"), new Guid("00000000-0000-0001-0000-000400000000"), 5.25m, new Guid("00000000-0000-0001-0000-00000402030a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020309"), new Guid("00000000-0000-0001-0000-000400000000"), 7.31m, new Guid("00000000-0000-0001-0000-000004020309") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020308"), new Guid("00000000-0000-0001-0000-000400000000"), 3.41m, new Guid("00000000-0000-0001-0000-000004020308") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010105"), new Guid("00000000-0000-0001-0000-000500000000"), 6.50m, new Guid("00000000-0000-0001-0000-000005010105") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010106"), new Guid("00000000-0000-0001-0000-000500000000"), 5.18m, new Guid("00000000-0000-0001-0000-000005010106") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010107"), new Guid("00000000-0000-0001-0000-000500000000"), 1.26m, new Guid("00000000-0000-0001-0000-000005010107") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010108"), new Guid("00000000-0000-0001-0000-000500000000"), 8.78m, new Guid("00000000-0000-0001-0000-000005010108") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010406"), new Guid("00000000-0000-0001-0000-000500000000"), 1.55m, new Guid("00000000-0000-0001-0000-000005010406") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010405"), new Guid("00000000-0000-0001-0000-000500000000"), 7.50m, new Guid("00000000-0000-0001-0000-000005010405") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010404"), new Guid("00000000-0000-0001-0000-000500000000"), 1.03m, new Guid("00000000-0000-0001-0000-000005010404") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010403"), new Guid("00000000-0000-0001-0000-000500000000"), 6.60m, new Guid("00000000-0000-0001-0000-000005010403") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010402"), new Guid("00000000-0000-0001-0000-000500000000"), 7.89m, new Guid("00000000-0000-0001-0000-000005010402") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010401"), new Guid("00000000-0000-0001-0000-000500000000"), 6.70m, new Guid("00000000-0000-0001-0000-000005010401") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000501030a"), new Guid("00000000-0000-0001-0000-000500000000"), 2.44m, new Guid("00000000-0000-0001-0000-00000501030a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010309"), new Guid("00000000-0000-0001-0000-000500000000"), 4.56m, new Guid("00000000-0000-0001-0000-000005010309") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010308"), new Guid("00000000-0000-0001-0000-000500000000"), 5.69m, new Guid("00000000-0000-0001-0000-000005010308") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010307"), new Guid("00000000-0000-0001-0000-000500000000"), 5.89m, new Guid("00000000-0000-0001-0000-000005010307") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010306"), new Guid("00000000-0000-0001-0000-000500000000"), 6.61m, new Guid("00000000-0000-0001-0000-000005010306") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010305"), new Guid("00000000-0000-0001-0000-000500000000"), 3.47m, new Guid("00000000-0000-0001-0000-000005010305") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010304"), new Guid("00000000-0000-0001-0000-000500000000"), 3.78m, new Guid("00000000-0000-0001-0000-000005010304") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000004020306"), new Guid("00000000-0000-0001-0000-000400000000"), 0.82m, new Guid("00000000-0000-0001-0000-000004020306") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010303"), new Guid("00000000-0000-0001-0000-000500000000"), 2.97m, new Guid("00000000-0000-0001-0000-000005010303") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010301"), new Guid("00000000-0000-0001-0000-000500000000"), 4.08m, new Guid("00000000-0000-0001-0000-000005010301") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000501020a"), new Guid("00000000-0000-0001-0000-000500000000"), 5.71m, new Guid("00000000-0000-0001-0000-00000501020a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010209"), new Guid("00000000-0000-0001-0000-000500000000"), 8.64m, new Guid("00000000-0000-0001-0000-000005010209") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010208"), new Guid("00000000-0000-0001-0000-000500000000"), 8.25m, new Guid("00000000-0000-0001-0000-000005010208") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010207"), new Guid("00000000-0000-0001-0000-000500000000"), 1.43m, new Guid("00000000-0000-0001-0000-000005010207") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010206"), new Guid("00000000-0000-0001-0000-000500000000"), 4.84m, new Guid("00000000-0000-0001-0000-000005010206") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010205"), new Guid("00000000-0000-0001-0000-000500000000"), 2.32m, new Guid("00000000-0000-0001-0000-000005010205") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010204"), new Guid("00000000-0000-0001-0000-000500000000"), 7.15m, new Guid("00000000-0000-0001-0000-000005010204") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010203"), new Guid("00000000-0000-0001-0000-000500000000"), 7.97m, new Guid("00000000-0000-0001-0000-000005010203") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010202"), new Guid("00000000-0000-0001-0000-000500000000"), 2.93m, new Guid("00000000-0000-0001-0000-000005010202") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010201"), new Guid("00000000-0000-0001-0000-000500000000"), 0.51m, new Guid("00000000-0000-0001-0000-000005010201") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000501010a"), new Guid("00000000-0000-0001-0000-000500000000"), 8.65m, new Guid("00000000-0000-0001-0000-00000501010a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010109"), new Guid("00000000-0000-0001-0000-000500000000"), 4.30m, new Guid("00000000-0000-0001-0000-000005010109") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005010302"), new Guid("00000000-0000-0001-0000-000500000000"), 7.44m, new Guid("00000000-0000-0001-0000-000005010302") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003020101"), new Guid("00000000-0000-0001-0000-000300000000"), 9.14m, new Guid("00000000-0000-0001-0000-000003020101") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000301050a"), new Guid("00000000-0000-0001-0000-000300000000"), 4.89m, new Guid("00000000-0000-0001-0000-00000301050a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010509"), new Guid("00000000-0000-0001-0000-000300000000"), 0.26m, new Guid("00000000-0000-0001-0000-000003010509") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020501"), new Guid("00000000-0000-0001-0000-000100000000"), 8.71m, new Guid("00000000-0000-0001-0000-000001020501") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000102040a"), new Guid("00000000-0000-0001-0000-000100000000"), 0.90m, new Guid("00000000-0000-0001-0000-00000102040a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020409"), new Guid("00000000-0000-0001-0000-000100000000"), 3.11m, new Guid("00000000-0000-0001-0000-000001020409") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020408"), new Guid("00000000-0000-0001-0000-000100000000"), 2.51m, new Guid("00000000-0000-0001-0000-000001020408") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020407"), new Guid("00000000-0000-0001-0000-000100000000"), 0.19m, new Guid("00000000-0000-0001-0000-000001020407") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020406"), new Guid("00000000-0000-0001-0000-000100000000"), 5.88m, new Guid("00000000-0000-0001-0000-000001020406") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020405"), new Guid("00000000-0000-0001-0000-000100000000"), 3.84m, new Guid("00000000-0000-0001-0000-000001020405") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020404"), new Guid("00000000-0000-0001-0000-000100000000"), 6.24m, new Guid("00000000-0000-0001-0000-000001020404") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020403"), new Guid("00000000-0000-0001-0000-000100000000"), 0.38m, new Guid("00000000-0000-0001-0000-000001020403") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020402"), new Guid("00000000-0000-0001-0000-000100000000"), 6.14m, new Guid("00000000-0000-0001-0000-000001020402") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020401"), new Guid("00000000-0000-0001-0000-000100000000"), 0.63m, new Guid("00000000-0000-0001-0000-000001020401") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000102030a"), new Guid("00000000-0000-0001-0000-000100000000"), 4.81m, new Guid("00000000-0000-0001-0000-00000102030a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020309"), new Guid("00000000-0000-0001-0000-000100000000"), 3.04m, new Guid("00000000-0000-0001-0000-000001020309") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020308"), new Guid("00000000-0000-0001-0000-000100000000"), 3.33m, new Guid("00000000-0000-0001-0000-000001020308") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020307"), new Guid("00000000-0000-0001-0000-000100000000"), 5.23m, new Guid("00000000-0000-0001-0000-000001020307") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020306"), new Guid("00000000-0000-0001-0000-000100000000"), 2.16m, new Guid("00000000-0000-0001-0000-000001020306") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020305"), new Guid("00000000-0000-0001-0000-000100000000"), 3.30m, new Guid("00000000-0000-0001-0000-000001020305") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020304"), new Guid("00000000-0000-0001-0000-000100000000"), 9.91m, new Guid("00000000-0000-0001-0000-000001020304") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020303"), new Guid("00000000-0000-0001-0000-000100000000"), 2.53m, new Guid("00000000-0000-0001-0000-000001020303") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020302"), new Guid("00000000-0000-0001-0000-000100000000"), 0.74m, new Guid("00000000-0000-0001-0000-000001020302") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020301"), new Guid("00000000-0000-0001-0000-000100000000"), 0.64m, new Guid("00000000-0000-0001-0000-000001020301") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000102020a"), new Guid("00000000-0000-0001-0000-000100000000"), 1.07m, new Guid("00000000-0000-0001-0000-00000102020a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020209"), new Guid("00000000-0000-0001-0000-000100000000"), 9.10m, new Guid("00000000-0000-0001-0000-000001020209") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020208"), new Guid("00000000-0000-0001-0000-000100000000"), 1.80m, new Guid("00000000-0000-0001-0000-000001020208") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020207"), new Guid("00000000-0000-0001-0000-000100000000"), 4.56m, new Guid("00000000-0000-0001-0000-000001020207") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020206"), new Guid("00000000-0000-0001-0000-000100000000"), 9.20m, new Guid("00000000-0000-0001-0000-000001020206") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020205"), new Guid("00000000-0000-0001-0000-000100000000"), 2.01m, new Guid("00000000-0000-0001-0000-000001020205") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020502"), new Guid("00000000-0000-0001-0000-000100000000"), 7.20m, new Guid("00000000-0000-0001-0000-000001020502") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020204"), new Guid("00000000-0000-0001-0000-000100000000"), 0.04m, new Guid("00000000-0000-0001-0000-000001020204") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020503"), new Guid("00000000-0000-0001-0000-000100000000"), 1.04m, new Guid("00000000-0000-0001-0000-000001020503") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020505"), new Guid("00000000-0000-0001-0000-000100000000"), 4.21m, new Guid("00000000-0000-0001-0000-000001020505") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010302"), new Guid("00000000-0000-0001-0000-000200000000"), 6.45m, new Guid("00000000-0000-0001-0000-000002010302") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010301"), new Guid("00000000-0000-0001-0000-000200000000"), 2.50m, new Guid("00000000-0000-0001-0000-000002010301") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000201020a"), new Guid("00000000-0000-0001-0000-000200000000"), 8.52m, new Guid("00000000-0000-0001-0000-00000201020a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010209"), new Guid("00000000-0000-0001-0000-000200000000"), 3.89m, new Guid("00000000-0000-0001-0000-000002010209") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010208"), new Guid("00000000-0000-0001-0000-000200000000"), 5.79m, new Guid("00000000-0000-0001-0000-000002010208") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010207"), new Guid("00000000-0000-0001-0000-000200000000"), 4.34m, new Guid("00000000-0000-0001-0000-000002010207") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010206"), new Guid("00000000-0000-0001-0000-000200000000"), 7.65m, new Guid("00000000-0000-0001-0000-000002010206") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010205"), new Guid("00000000-0000-0001-0000-000200000000"), 2.28m, new Guid("00000000-0000-0001-0000-000002010205") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010204"), new Guid("00000000-0000-0001-0000-000200000000"), 2.01m, new Guid("00000000-0000-0001-0000-000002010204") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010203"), new Guid("00000000-0000-0001-0000-000200000000"), 2.92m, new Guid("00000000-0000-0001-0000-000002010203") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010202"), new Guid("00000000-0000-0001-0000-000200000000"), 5.61m, new Guid("00000000-0000-0001-0000-000002010202") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010201"), new Guid("00000000-0000-0001-0000-000200000000"), 5.10m, new Guid("00000000-0000-0001-0000-000002010201") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000201010a"), new Guid("00000000-0000-0001-0000-000200000000"), 8.63m, new Guid("00000000-0000-0001-0000-00000201010a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010109"), new Guid("00000000-0000-0001-0000-000200000000"), 0.65m, new Guid("00000000-0000-0001-0000-000002010109") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010108"), new Guid("00000000-0000-0001-0000-000200000000"), 5.31m, new Guid("00000000-0000-0001-0000-000002010108") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010107"), new Guid("00000000-0000-0001-0000-000200000000"), 3.64m, new Guid("00000000-0000-0001-0000-000002010107") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010106"), new Guid("00000000-0000-0001-0000-000200000000"), 7.58m, new Guid("00000000-0000-0001-0000-000002010106") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010105"), new Guid("00000000-0000-0001-0000-000200000000"), 8.05m, new Guid("00000000-0000-0001-0000-000002010105") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010104"), new Guid("00000000-0000-0001-0000-000200000000"), 7.48m, new Guid("00000000-0000-0001-0000-000002010104") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010103"), new Guid("00000000-0000-0001-0000-000200000000"), 3.96m, new Guid("00000000-0000-0001-0000-000002010103") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010102"), new Guid("00000000-0000-0001-0000-000200000000"), 3.46m, new Guid("00000000-0000-0001-0000-000002010102") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010101"), new Guid("00000000-0000-0001-0000-000200000000"), 8.96m, new Guid("00000000-0000-0001-0000-000002010101") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000102050a"), new Guid("00000000-0000-0001-0000-000100000000"), 7.23m, new Guid("00000000-0000-0001-0000-00000102050a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020509"), new Guid("00000000-0000-0001-0000-000100000000"), 2.72m, new Guid("00000000-0000-0001-0000-000001020509") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020508"), new Guid("00000000-0000-0001-0000-000100000000"), 5.22m, new Guid("00000000-0000-0001-0000-000001020508") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020507"), new Guid("00000000-0000-0001-0000-000100000000"), 0.08m, new Guid("00000000-0000-0001-0000-000001020507") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020506"), new Guid("00000000-0000-0001-0000-000100000000"), 7.49m, new Guid("00000000-0000-0001-0000-000001020506") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020504"), new Guid("00000000-0000-0001-0000-000100000000"), 1.74m, new Guid("00000000-0000-0001-0000-000001020504") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020203"), new Guid("00000000-0000-0001-0000-000100000000"), 1.08m, new Guid("00000000-0000-0001-0000-000001020203") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020202"), new Guid("00000000-0000-0001-0000-000100000000"), 4.42m, new Guid("00000000-0000-0001-0000-000001020202") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020201"), new Guid("00000000-0000-0001-0000-000100000000"), 7.79m, new Guid("00000000-0000-0001-0000-000001020201") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010308"), new Guid("00000000-0000-0001-0000-000100000000"), 0.60m, new Guid("00000000-0000-0001-0000-000001010308") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010307"), new Guid("00000000-0000-0001-0000-000100000000"), 2.17m, new Guid("00000000-0000-0001-0000-000001010307") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010306"), new Guid("00000000-0000-0001-0000-000100000000"), 3.42m, new Guid("00000000-0000-0001-0000-000001010306") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010305"), new Guid("00000000-0000-0001-0000-000100000000"), 1.19m, new Guid("00000000-0000-0001-0000-000001010305") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010304"), new Guid("00000000-0000-0001-0000-000100000000"), 5.50m, new Guid("00000000-0000-0001-0000-000001010304") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010303"), new Guid("00000000-0000-0001-0000-000100000000"), 2.33m, new Guid("00000000-0000-0001-0000-000001010303") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010302"), new Guid("00000000-0000-0001-0000-000100000000"), 3.08m, new Guid("00000000-0000-0001-0000-000001010302") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010301"), new Guid("00000000-0000-0001-0000-000100000000"), 6.93m, new Guid("00000000-0000-0001-0000-000001010301") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000101020a"), new Guid("00000000-0000-0001-0000-000100000000"), 5.96m, new Guid("00000000-0000-0001-0000-00000101020a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010209"), new Guid("00000000-0000-0001-0000-000100000000"), 9.25m, new Guid("00000000-0000-0001-0000-000001010209") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010208"), new Guid("00000000-0000-0001-0000-000100000000"), 2.98m, new Guid("00000000-0000-0001-0000-000001010208") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010207"), new Guid("00000000-0000-0001-0000-000100000000"), 9.14m, new Guid("00000000-0000-0001-0000-000001010207") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010206"), new Guid("00000000-0000-0001-0000-000100000000"), 0.47m, new Guid("00000000-0000-0001-0000-000001010206") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010205"), new Guid("00000000-0000-0001-0000-000100000000"), 4.37m, new Guid("00000000-0000-0001-0000-000001010205") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010204"), new Guid("00000000-0000-0001-0000-000100000000"), 6.08m, new Guid("00000000-0000-0001-0000-000001010204") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010203"), new Guid("00000000-0000-0001-0000-000100000000"), 6.07m, new Guid("00000000-0000-0001-0000-000001010203") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010202"), new Guid("00000000-0000-0001-0000-000100000000"), 6.55m, new Guid("00000000-0000-0001-0000-000001010202") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010201"), new Guid("00000000-0000-0001-0000-000100000000"), 0.78m, new Guid("00000000-0000-0001-0000-000001010201") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000101010a"), new Guid("00000000-0000-0001-0000-000100000000"), 7.59m, new Guid("00000000-0000-0001-0000-00000101010a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010109"), new Guid("00000000-0000-0001-0000-000100000000"), 3.82m, new Guid("00000000-0000-0001-0000-000001010109") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010108"), new Guid("00000000-0000-0001-0000-000100000000"), 9.39m, new Guid("00000000-0000-0001-0000-000001010108") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010107"), new Guid("00000000-0000-0001-0000-000100000000"), 4.03m, new Guid("00000000-0000-0001-0000-000001010107") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010106"), new Guid("00000000-0000-0001-0000-000100000000"), 8.60m, new Guid("00000000-0000-0001-0000-000001010106") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010105"), new Guid("00000000-0000-0001-0000-000100000000"), 3.53m, new Guid("00000000-0000-0001-0000-000001010105") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010104"), new Guid("00000000-0000-0001-0000-000100000000"), 1.20m, new Guid("00000000-0000-0001-0000-000001010104") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010103"), new Guid("00000000-0000-0001-0000-000100000000"), 0.25m, new Guid("00000000-0000-0001-0000-000001010103") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010102"), new Guid("00000000-0000-0001-0000-000100000000"), 1.40m, new Guid("00000000-0000-0001-0000-000001010102") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010309"), new Guid("00000000-0000-0001-0000-000100000000"), 8.09m, new Guid("00000000-0000-0001-0000-000001010309") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000101030a"), new Guid("00000000-0000-0001-0000-000100000000"), 6.58m, new Guid("00000000-0000-0001-0000-00000101030a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010401"), new Guid("00000000-0000-0001-0000-000100000000"), 9.75m, new Guid("00000000-0000-0001-0000-000001010401") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010402"), new Guid("00000000-0000-0001-0000-000100000000"), 6.15m, new Guid("00000000-0000-0001-0000-000001010402") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000102010a"), new Guid("00000000-0000-0001-0000-000100000000"), 2.45m, new Guid("00000000-0000-0001-0000-00000102010a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020109"), new Guid("00000000-0000-0001-0000-000100000000"), 3.78m, new Guid("00000000-0000-0001-0000-000001020109") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020108"), new Guid("00000000-0000-0001-0000-000100000000"), 4.12m, new Guid("00000000-0000-0001-0000-000001020108") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020107"), new Guid("00000000-0000-0001-0000-000100000000"), 7.13m, new Guid("00000000-0000-0001-0000-000001020107") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020106"), new Guid("00000000-0000-0001-0000-000100000000"), 9.68m, new Guid("00000000-0000-0001-0000-000001020106") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020105"), new Guid("00000000-0000-0001-0000-000100000000"), 1.41m, new Guid("00000000-0000-0001-0000-000001020105") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020104"), new Guid("00000000-0000-0001-0000-000100000000"), 2.74m, new Guid("00000000-0000-0001-0000-000001020104") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020103"), new Guid("00000000-0000-0001-0000-000100000000"), 5.61m, new Guid("00000000-0000-0001-0000-000001020103") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020102"), new Guid("00000000-0000-0001-0000-000100000000"), 7.45m, new Guid("00000000-0000-0001-0000-000001020102") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001020101"), new Guid("00000000-0000-0001-0000-000100000000"), 0.92m, new Guid("00000000-0000-0001-0000-000001020101") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000101050a"), new Guid("00000000-0000-0001-0000-000100000000"), 4.52m, new Guid("00000000-0000-0001-0000-00000101050a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010509"), new Guid("00000000-0000-0001-0000-000100000000"), 3.61m, new Guid("00000000-0000-0001-0000-000001010509") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010508"), new Guid("00000000-0000-0001-0000-000100000000"), 3.81m, new Guid("00000000-0000-0001-0000-000001010508") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010303"), new Guid("00000000-0000-0001-0000-000200000000"), 0.43m, new Guid("00000000-0000-0001-0000-000002010303") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010507"), new Guid("00000000-0000-0001-0000-000100000000"), 4.49m, new Guid("00000000-0000-0001-0000-000001010507") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010505"), new Guid("00000000-0000-0001-0000-000100000000"), 5.40m, new Guid("00000000-0000-0001-0000-000001010505") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010504"), new Guid("00000000-0000-0001-0000-000100000000"), 5.21m, new Guid("00000000-0000-0001-0000-000001010504") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010503"), new Guid("00000000-0000-0001-0000-000100000000"), 4.72m, new Guid("00000000-0000-0001-0000-000001010503") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010502"), new Guid("00000000-0000-0001-0000-000100000000"), 9.01m, new Guid("00000000-0000-0001-0000-000001010502") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010501"), new Guid("00000000-0000-0001-0000-000100000000"), 6.21m, new Guid("00000000-0000-0001-0000-000001010501") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000101040a"), new Guid("00000000-0000-0001-0000-000100000000"), 6.86m, new Guid("00000000-0000-0001-0000-00000101040a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010409"), new Guid("00000000-0000-0001-0000-000100000000"), 2.87m, new Guid("00000000-0000-0001-0000-000001010409") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010408"), new Guid("00000000-0000-0001-0000-000100000000"), 7.36m, new Guid("00000000-0000-0001-0000-000001010408") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010407"), new Guid("00000000-0000-0001-0000-000100000000"), 6.14m, new Guid("00000000-0000-0001-0000-000001010407") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010406"), new Guid("00000000-0000-0001-0000-000100000000"), 3.87m, new Guid("00000000-0000-0001-0000-000001010406") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010405"), new Guid("00000000-0000-0001-0000-000100000000"), 3.87m, new Guid("00000000-0000-0001-0000-000001010405") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010404"), new Guid("00000000-0000-0001-0000-000100000000"), 4.22m, new Guid("00000000-0000-0001-0000-000001010404") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010403"), new Guid("00000000-0000-0001-0000-000100000000"), 4.74m, new Guid("00000000-0000-0001-0000-000001010403") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000001010506"), new Guid("00000000-0000-0001-0000-000100000000"), 6.00m, new Guid("00000000-0000-0001-0000-000001010506") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010304"), new Guid("00000000-0000-0001-0000-000200000000"), 0.43m, new Guid("00000000-0000-0001-0000-000002010304") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010305"), new Guid("00000000-0000-0001-0000-000200000000"), 6.67m, new Guid("00000000-0000-0001-0000-000002010305") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010306"), new Guid("00000000-0000-0001-0000-000200000000"), 0.56m, new Guid("00000000-0000-0001-0000-000002010306") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010206"), new Guid("00000000-0000-0001-0000-000300000000"), 2.71m, new Guid("00000000-0000-0001-0000-000003010206") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010205"), new Guid("00000000-0000-0001-0000-000300000000"), 8.35m, new Guid("00000000-0000-0001-0000-000003010205") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010204"), new Guid("00000000-0000-0001-0000-000300000000"), 8.27m, new Guid("00000000-0000-0001-0000-000003010204") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010203"), new Guid("00000000-0000-0001-0000-000300000000"), 3.22m, new Guid("00000000-0000-0001-0000-000003010203") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010202"), new Guid("00000000-0000-0001-0000-000300000000"), 3.66m, new Guid("00000000-0000-0001-0000-000003010202") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010201"), new Guid("00000000-0000-0001-0000-000300000000"), 7.85m, new Guid("00000000-0000-0001-0000-000003010201") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000301010a"), new Guid("00000000-0000-0001-0000-000300000000"), 3.28m, new Guid("00000000-0000-0001-0000-00000301010a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010109"), new Guid("00000000-0000-0001-0000-000300000000"), 3.06m, new Guid("00000000-0000-0001-0000-000003010109") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010108"), new Guid("00000000-0000-0001-0000-000300000000"), 7.74m, new Guid("00000000-0000-0001-0000-000003010108") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010107"), new Guid("00000000-0000-0001-0000-000300000000"), 9.29m, new Guid("00000000-0000-0001-0000-000003010107") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010106"), new Guid("00000000-0000-0001-0000-000300000000"), 2.01m, new Guid("00000000-0000-0001-0000-000003010106") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010105"), new Guid("00000000-0000-0001-0000-000300000000"), 5.24m, new Guid("00000000-0000-0001-0000-000003010105") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010104"), new Guid("00000000-0000-0001-0000-000300000000"), 1.97m, new Guid("00000000-0000-0001-0000-000003010104") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010103"), new Guid("00000000-0000-0001-0000-000300000000"), 1.93m, new Guid("00000000-0000-0001-0000-000003010103") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010102"), new Guid("00000000-0000-0001-0000-000300000000"), 1.59m, new Guid("00000000-0000-0001-0000-000003010102") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010101"), new Guid("00000000-0000-0001-0000-000300000000"), 0.52m, new Guid("00000000-0000-0001-0000-000003010101") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000202050a"), new Guid("00000000-0000-0001-0000-000200000000"), 1.92m, new Guid("00000000-0000-0001-0000-00000202050a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020509"), new Guid("00000000-0000-0001-0000-000200000000"), 8.13m, new Guid("00000000-0000-0001-0000-000002020509") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020508"), new Guid("00000000-0000-0001-0000-000200000000"), 3.42m, new Guid("00000000-0000-0001-0000-000002020508") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020507"), new Guid("00000000-0000-0001-0000-000200000000"), 1.90m, new Guid("00000000-0000-0001-0000-000002020507") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020506"), new Guid("00000000-0000-0001-0000-000200000000"), 7.80m, new Guid("00000000-0000-0001-0000-000002020506") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020505"), new Guid("00000000-0000-0001-0000-000200000000"), 7.57m, new Guid("00000000-0000-0001-0000-000002020505") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020504"), new Guid("00000000-0000-0001-0000-000200000000"), 6.89m, new Guid("00000000-0000-0001-0000-000002020504") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020503"), new Guid("00000000-0000-0001-0000-000200000000"), 7.57m, new Guid("00000000-0000-0001-0000-000002020503") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020502"), new Guid("00000000-0000-0001-0000-000200000000"), 4.18m, new Guid("00000000-0000-0001-0000-000002020502") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020501"), new Guid("00000000-0000-0001-0000-000200000000"), 0.93m, new Guid("00000000-0000-0001-0000-000002020501") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000202040a"), new Guid("00000000-0000-0001-0000-000200000000"), 0.16m, new Guid("00000000-0000-0001-0000-00000202040a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010207"), new Guid("00000000-0000-0001-0000-000300000000"), 4.82m, new Guid("00000000-0000-0001-0000-000003010207") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010208"), new Guid("00000000-0000-0001-0000-000300000000"), 4.54m, new Guid("00000000-0000-0001-0000-000003010208") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010209"), new Guid("00000000-0000-0001-0000-000300000000"), 7.57m, new Guid("00000000-0000-0001-0000-000003010209") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000301020a"), new Guid("00000000-0000-0001-0000-000300000000"), 8.75m, new Guid("00000000-0000-0001-0000-00000301020a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010508"), new Guid("00000000-0000-0001-0000-000300000000"), 9.24m, new Guid("00000000-0000-0001-0000-000003010508") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010507"), new Guid("00000000-0000-0001-0000-000300000000"), 0.26m, new Guid("00000000-0000-0001-0000-000003010507") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010506"), new Guid("00000000-0000-0001-0000-000300000000"), 3.29m, new Guid("00000000-0000-0001-0000-000003010506") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010505"), new Guid("00000000-0000-0001-0000-000300000000"), 1.28m, new Guid("00000000-0000-0001-0000-000003010505") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010504"), new Guid("00000000-0000-0001-0000-000300000000"), 0.25m, new Guid("00000000-0000-0001-0000-000003010504") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010503"), new Guid("00000000-0000-0001-0000-000300000000"), 9.73m, new Guid("00000000-0000-0001-0000-000003010503") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010502"), new Guid("00000000-0000-0001-0000-000300000000"), 4.51m, new Guid("00000000-0000-0001-0000-000003010502") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010501"), new Guid("00000000-0000-0001-0000-000300000000"), 1.03m, new Guid("00000000-0000-0001-0000-000003010501") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000301040a"), new Guid("00000000-0000-0001-0000-000300000000"), 8.36m, new Guid("00000000-0000-0001-0000-00000301040a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010409"), new Guid("00000000-0000-0001-0000-000300000000"), 7.58m, new Guid("00000000-0000-0001-0000-000003010409") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010408"), new Guid("00000000-0000-0001-0000-000300000000"), 3.79m, new Guid("00000000-0000-0001-0000-000003010408") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010407"), new Guid("00000000-0000-0001-0000-000300000000"), 6.71m, new Guid("00000000-0000-0001-0000-000003010407") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010406"), new Guid("00000000-0000-0001-0000-000300000000"), 2.08m, new Guid("00000000-0000-0001-0000-000003010406") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020409"), new Guid("00000000-0000-0001-0000-000200000000"), 7.83m, new Guid("00000000-0000-0001-0000-000002020409") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010405"), new Guid("00000000-0000-0001-0000-000300000000"), 9.61m, new Guid("00000000-0000-0001-0000-000003010405") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010403"), new Guid("00000000-0000-0001-0000-000300000000"), 3.97m, new Guid("00000000-0000-0001-0000-000003010403") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010402"), new Guid("00000000-0000-0001-0000-000300000000"), 0.21m, new Guid("00000000-0000-0001-0000-000003010402") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010401"), new Guid("00000000-0000-0001-0000-000300000000"), 9.86m, new Guid("00000000-0000-0001-0000-000003010401") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000301030a"), new Guid("00000000-0000-0001-0000-000300000000"), 8.01m, new Guid("00000000-0000-0001-0000-00000301030a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010309"), new Guid("00000000-0000-0001-0000-000300000000"), 9.26m, new Guid("00000000-0000-0001-0000-000003010309") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010308"), new Guid("00000000-0000-0001-0000-000300000000"), 4.26m, new Guid("00000000-0000-0001-0000-000003010308") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010307"), new Guid("00000000-0000-0001-0000-000300000000"), 8.81m, new Guid("00000000-0000-0001-0000-000003010307") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010306"), new Guid("00000000-0000-0001-0000-000300000000"), 7.78m, new Guid("00000000-0000-0001-0000-000003010306") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010305"), new Guid("00000000-0000-0001-0000-000300000000"), 4.75m, new Guid("00000000-0000-0001-0000-000003010305") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010304"), new Guid("00000000-0000-0001-0000-000300000000"), 6.81m, new Guid("00000000-0000-0001-0000-000003010304") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010303"), new Guid("00000000-0000-0001-0000-000300000000"), 8.60m, new Guid("00000000-0000-0001-0000-000003010303") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010302"), new Guid("00000000-0000-0001-0000-000300000000"), 3.94m, new Guid("00000000-0000-0001-0000-000003010302") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010301"), new Guid("00000000-0000-0001-0000-000300000000"), 3.42m, new Guid("00000000-0000-0001-0000-000003010301") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000003010404"), new Guid("00000000-0000-0001-0000-000300000000"), 6.40m, new Guid("00000000-0000-0001-0000-000003010404") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000005020509"), new Guid("00000000-0000-0001-0000-000500000000"), 4.44m, new Guid("00000000-0000-0001-0000-000005020509") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020408"), new Guid("00000000-0000-0001-0000-000200000000"), 1.46m, new Guid("00000000-0000-0001-0000-000002020408") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020406"), new Guid("00000000-0000-0001-0000-000200000000"), 4.17m, new Guid("00000000-0000-0001-0000-000002020406") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020103"), new Guid("00000000-0000-0001-0000-000200000000"), 6.01m, new Guid("00000000-0000-0001-0000-000002020103") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020102"), new Guid("00000000-0000-0001-0000-000200000000"), 9.72m, new Guid("00000000-0000-0001-0000-000002020102") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020101"), new Guid("00000000-0000-0001-0000-000200000000"), 0.30m, new Guid("00000000-0000-0001-0000-000002020101") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000201050a"), new Guid("00000000-0000-0001-0000-000200000000"), 1.94m, new Guid("00000000-0000-0001-0000-00000201050a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010509"), new Guid("00000000-0000-0001-0000-000200000000"), 6.92m, new Guid("00000000-0000-0001-0000-000002010509") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010508"), new Guid("00000000-0000-0001-0000-000200000000"), 6.76m, new Guid("00000000-0000-0001-0000-000002010508") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010507"), new Guid("00000000-0000-0001-0000-000200000000"), 6.83m, new Guid("00000000-0000-0001-0000-000002010507") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010506"), new Guid("00000000-0000-0001-0000-000200000000"), 0.92m, new Guid("00000000-0000-0001-0000-000002010506") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010505"), new Guid("00000000-0000-0001-0000-000200000000"), 8.33m, new Guid("00000000-0000-0001-0000-000002010505") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010504"), new Guid("00000000-0000-0001-0000-000200000000"), 0.50m, new Guid("00000000-0000-0001-0000-000002010504") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010503"), new Guid("00000000-0000-0001-0000-000200000000"), 9.61m, new Guid("00000000-0000-0001-0000-000002010503") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010502"), new Guid("00000000-0000-0001-0000-000200000000"), 9.05m, new Guid("00000000-0000-0001-0000-000002010502") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010501"), new Guid("00000000-0000-0001-0000-000200000000"), 1.22m, new Guid("00000000-0000-0001-0000-000002010501") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000201040a"), new Guid("00000000-0000-0001-0000-000200000000"), 1.98m, new Guid("00000000-0000-0001-0000-00000201040a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010409"), new Guid("00000000-0000-0001-0000-000200000000"), 2.19m, new Guid("00000000-0000-0001-0000-000002010409") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010408"), new Guid("00000000-0000-0001-0000-000200000000"), 2.76m, new Guid("00000000-0000-0001-0000-000002010408") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010407"), new Guid("00000000-0000-0001-0000-000200000000"), 1.93m, new Guid("00000000-0000-0001-0000-000002010407") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010406"), new Guid("00000000-0000-0001-0000-000200000000"), 3.95m, new Guid("00000000-0000-0001-0000-000002010406") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010405"), new Guid("00000000-0000-0001-0000-000200000000"), 9.36m, new Guid("00000000-0000-0001-0000-000002010405") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010404"), new Guid("00000000-0000-0001-0000-000200000000"), 0.10m, new Guid("00000000-0000-0001-0000-000002010404") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010403"), new Guid("00000000-0000-0001-0000-000200000000"), 2.38m, new Guid("00000000-0000-0001-0000-000002010403") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010402"), new Guid("00000000-0000-0001-0000-000200000000"), 3.93m, new Guid("00000000-0000-0001-0000-000002010402") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010401"), new Guid("00000000-0000-0001-0000-000200000000"), 2.08m, new Guid("00000000-0000-0001-0000-000002010401") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000201030a"), new Guid("00000000-0000-0001-0000-000200000000"), 4.42m, new Guid("00000000-0000-0001-0000-00000201030a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010309"), new Guid("00000000-0000-0001-0000-000200000000"), 6.54m, new Guid("00000000-0000-0001-0000-000002010309") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010308"), new Guid("00000000-0000-0001-0000-000200000000"), 7.91m, new Guid("00000000-0000-0001-0000-000002010308") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002010307"), new Guid("00000000-0000-0001-0000-000200000000"), 9.29m, new Guid("00000000-0000-0001-0000-000002010307") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020104"), new Guid("00000000-0000-0001-0000-000200000000"), 0.77m, new Guid("00000000-0000-0001-0000-000002020104") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020105"), new Guid("00000000-0000-0001-0000-000200000000"), 0.89m, new Guid("00000000-0000-0001-0000-000002020105") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020106"), new Guid("00000000-0000-0001-0000-000200000000"), 9.93m, new Guid("00000000-0000-0001-0000-000002020106") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020107"), new Guid("00000000-0000-0001-0000-000200000000"), 0.86m, new Guid("00000000-0000-0001-0000-000002020107") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020405"), new Guid("00000000-0000-0001-0000-000200000000"), 7.89m, new Guid("00000000-0000-0001-0000-000002020405") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020404"), new Guid("00000000-0000-0001-0000-000200000000"), 4.11m, new Guid("00000000-0000-0001-0000-000002020404") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020403"), new Guid("00000000-0000-0001-0000-000200000000"), 4.53m, new Guid("00000000-0000-0001-0000-000002020403") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020402"), new Guid("00000000-0000-0001-0000-000200000000"), 4.67m, new Guid("00000000-0000-0001-0000-000002020402") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020401"), new Guid("00000000-0000-0001-0000-000200000000"), 6.82m, new Guid("00000000-0000-0001-0000-000002020401") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000202030a"), new Guid("00000000-0000-0001-0000-000200000000"), 0.11m, new Guid("00000000-0000-0001-0000-00000202030a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020309"), new Guid("00000000-0000-0001-0000-000200000000"), 2.18m, new Guid("00000000-0000-0001-0000-000002020309") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020308"), new Guid("00000000-0000-0001-0000-000200000000"), 3.56m, new Guid("00000000-0000-0001-0000-000002020308") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020307"), new Guid("00000000-0000-0001-0000-000200000000"), 8.52m, new Guid("00000000-0000-0001-0000-000002020307") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020306"), new Guid("00000000-0000-0001-0000-000200000000"), 6.24m, new Guid("00000000-0000-0001-0000-000002020306") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020305"), new Guid("00000000-0000-0001-0000-000200000000"), 3.33m, new Guid("00000000-0000-0001-0000-000002020305") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020304"), new Guid("00000000-0000-0001-0000-000200000000"), 1.97m, new Guid("00000000-0000-0001-0000-000002020304") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020303"), new Guid("00000000-0000-0001-0000-000200000000"), 5.54m, new Guid("00000000-0000-0001-0000-000002020303") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020407"), new Guid("00000000-0000-0001-0000-000200000000"), 3.52m, new Guid("00000000-0000-0001-0000-000002020407") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020302"), new Guid("00000000-0000-0001-0000-000200000000"), 1.58m, new Guid("00000000-0000-0001-0000-000002020302") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000202020a"), new Guid("00000000-0000-0001-0000-000200000000"), 8.09m, new Guid("00000000-0000-0001-0000-00000202020a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020209"), new Guid("00000000-0000-0001-0000-000200000000"), 4.99m, new Guid("00000000-0000-0001-0000-000002020209") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020208"), new Guid("00000000-0000-0001-0000-000200000000"), 4.01m, new Guid("00000000-0000-0001-0000-000002020208") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020207"), new Guid("00000000-0000-0001-0000-000200000000"), 1.14m, new Guid("00000000-0000-0001-0000-000002020207") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020206"), new Guid("00000000-0000-0001-0000-000200000000"), 9.12m, new Guid("00000000-0000-0001-0000-000002020206") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020205"), new Guid("00000000-0000-0001-0000-000200000000"), 4.83m, new Guid("00000000-0000-0001-0000-000002020205") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020204"), new Guid("00000000-0000-0001-0000-000200000000"), 4.35m, new Guid("00000000-0000-0001-0000-000002020204") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020203"), new Guid("00000000-0000-0001-0000-000200000000"), 8.71m, new Guid("00000000-0000-0001-0000-000002020203") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020202"), new Guid("00000000-0000-0001-0000-000200000000"), 0.85m, new Guid("00000000-0000-0001-0000-000002020202") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020201"), new Guid("00000000-0000-0001-0000-000200000000"), 9.08m, new Guid("00000000-0000-0001-0000-000002020201") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000202010a"), new Guid("00000000-0000-0001-0000-000200000000"), 0.05m, new Guid("00000000-0000-0001-0000-00000202010a") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020109"), new Guid("00000000-0000-0001-0000-000200000000"), 4.50m, new Guid("00000000-0000-0001-0000-000002020109") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020108"), new Guid("00000000-0000-0001-0000-000200000000"), 2.87m, new Guid("00000000-0000-0001-0000-000002020108") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-000002020301"), new Guid("00000000-0000-0001-0000-000200000000"), 5.97m, new Guid("00000000-0000-0001-0000-000002020301") });

            migrationBuilder.InsertData(
                table: "EventSeats",
                columns: new[] { "Id", "EventId", "Price", "SeatId" },
                values: new object[] { new Guid("00000000-0000-0002-0000-00000502050a"), new Guid("00000000-0000-0001-0000-000500000000"), 7.61m, new Guid("00000000-0000-0001-0000-00000502050a") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000001010101"), new Guid("00000000-0000-0002-0000-000001010101"), 2.56m, new Guid("00000000-0000-0004-0000-000001010101") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000003010109"), new Guid("00000000-0000-0002-0000-000003010109"), 7.87m, new Guid("00000000-0000-0004-0000-000003010109") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-00000301010a"), new Guid("00000000-0000-0002-0000-00000301010a"), 4.28m, new Guid("00000000-0000-0004-0000-00000301010a") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000003010201"), new Guid("00000000-0000-0002-0000-000003010201"), 6.85m, new Guid("00000000-0000-0004-0000-000003010201") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000003010202"), new Guid("00000000-0000-0002-0000-000003010202"), 6.85m, new Guid("00000000-0000-0004-0000-000003010202") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000004010101"), new Guid("00000000-0000-0002-0000-000004010101"), 3.55m, new Guid("00000000-0000-0004-0000-000004010101") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000004010102"), new Guid("00000000-0000-0002-0000-000004010102"), 0.90m, new Guid("00000000-0000-0004-0000-000004010102") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000004010103"), new Guid("00000000-0000-0002-0000-000004010103"), 0.11m, new Guid("00000000-0000-0004-0000-000004010103") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000004010104"), new Guid("00000000-0000-0002-0000-000004010104"), 7.77m, new Guid("00000000-0000-0004-0000-000004010104") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000004010105"), new Guid("00000000-0000-0002-0000-000004010105"), 7.74m, new Guid("00000000-0000-0004-0000-000004010105") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000004010106"), new Guid("00000000-0000-0002-0000-000004010106"), 4.99m, new Guid("00000000-0000-0004-0000-000004010106") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000004010107"), new Guid("00000000-0000-0002-0000-000004010107"), 3.73m, new Guid("00000000-0000-0004-0000-000004010107") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000004010108"), new Guid("00000000-0000-0002-0000-000004010108"), 3.65m, new Guid("00000000-0000-0004-0000-000004010108") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000003010108"), new Guid("00000000-0000-0002-0000-000003010108"), 6.05m, new Guid("00000000-0000-0004-0000-000003010108") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000004010109"), new Guid("00000000-0000-0002-0000-000004010109"), 9.98m, new Guid("00000000-0000-0004-0000-000004010109") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000004010201"), new Guid("00000000-0000-0002-0000-000004010201"), 3.70m, new Guid("00000000-0000-0004-0000-000004010201") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000004010202"), new Guid("00000000-0000-0002-0000-000004010202"), 3.70m, new Guid("00000000-0000-0004-0000-000004010202") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000005010101"), new Guid("00000000-0000-0002-0000-000005010101"), 0.82m, new Guid("00000000-0000-0004-0000-000005010101") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000005010102"), new Guid("00000000-0000-0002-0000-000005010102"), 1.02m, new Guid("00000000-0000-0004-0000-000005010102") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000005010103"), new Guid("00000000-0000-0002-0000-000005010103"), 5.93m, new Guid("00000000-0000-0004-0000-000005010103") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000005010104"), new Guid("00000000-0000-0002-0000-000005010104"), 6.11m, new Guid("00000000-0000-0004-0000-000005010104") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000005010105"), new Guid("00000000-0000-0002-0000-000005010105"), 4.02m, new Guid("00000000-0000-0004-0000-000005010105") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000005010106"), new Guid("00000000-0000-0002-0000-000005010106"), 5.29m, new Guid("00000000-0000-0004-0000-000005010106") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000005010107"), new Guid("00000000-0000-0002-0000-000005010107"), 0.83m, new Guid("00000000-0000-0004-0000-000005010107") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000005010108"), new Guid("00000000-0000-0002-0000-000005010108"), 5.34m, new Guid("00000000-0000-0004-0000-000005010108") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000005010109"), new Guid("00000000-0000-0002-0000-000005010109"), 1.77m, new Guid("00000000-0000-0004-0000-000005010109") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-00000501010a"), new Guid("00000000-0000-0002-0000-00000501010a"), 5.73m, new Guid("00000000-0000-0004-0000-00000501010a") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-00000401010a"), new Guid("00000000-0000-0002-0000-00000401010a"), 7.29m, new Guid("00000000-0000-0004-0000-00000401010a") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000003010107"), new Guid("00000000-0000-0002-0000-000003010107"), 0.22m, new Guid("00000000-0000-0004-0000-000003010107") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000003010106"), new Guid("00000000-0000-0002-0000-000003010106"), 4.23m, new Guid("00000000-0000-0004-0000-000003010106") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000003010105"), new Guid("00000000-0000-0002-0000-000003010105"), 7.44m, new Guid("00000000-0000-0004-0000-000003010105") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000001010102"), new Guid("00000000-0000-0002-0000-000001010102"), 0.74m, new Guid("00000000-0000-0004-0000-000001010102") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000001010103"), new Guid("00000000-0000-0002-0000-000001010103"), 3.05m, new Guid("00000000-0000-0004-0000-000001010103") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000001010104"), new Guid("00000000-0000-0002-0000-000001010104"), 6.80m, new Guid("00000000-0000-0004-0000-000001010104") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000001010105"), new Guid("00000000-0000-0002-0000-000001010105"), 2.45m, new Guid("00000000-0000-0004-0000-000001010105") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000001010106"), new Guid("00000000-0000-0002-0000-000001010106"), 4.73m, new Guid("00000000-0000-0004-0000-000001010106") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000001010107"), new Guid("00000000-0000-0002-0000-000001010107"), 6.02m, new Guid("00000000-0000-0004-0000-000001010107") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000001010108"), new Guid("00000000-0000-0002-0000-000001010108"), 3.94m, new Guid("00000000-0000-0004-0000-000001010108") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000001010109"), new Guid("00000000-0000-0002-0000-000001010109"), 1.36m, new Guid("00000000-0000-0004-0000-000001010109") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-00000101010a"), new Guid("00000000-0000-0002-0000-00000101010a"), 0.66m, new Guid("00000000-0000-0004-0000-00000101010a") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000001010201"), new Guid("00000000-0000-0002-0000-000001010201"), 7.13m, new Guid("00000000-0000-0004-0000-000001010201") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000001010202"), new Guid("00000000-0000-0002-0000-000001010202"), 7.13m, new Guid("00000000-0000-0004-0000-000001010202") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000002010101"), new Guid("00000000-0000-0002-0000-000002010101"), 3.75m, new Guid("00000000-0000-0004-0000-000002010101") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000002010102"), new Guid("00000000-0000-0002-0000-000002010102"), 3.34m, new Guid("00000000-0000-0004-0000-000002010102") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000002010103"), new Guid("00000000-0000-0002-0000-000002010103"), 4.97m, new Guid("00000000-0000-0004-0000-000002010103") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000002010104"), new Guid("00000000-0000-0002-0000-000002010104"), 8.84m, new Guid("00000000-0000-0004-0000-000002010104") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000002010105"), new Guid("00000000-0000-0002-0000-000002010105"), 3.17m, new Guid("00000000-0000-0004-0000-000002010105") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000002010106"), new Guid("00000000-0000-0002-0000-000002010106"), 5.22m, new Guid("00000000-0000-0004-0000-000002010106") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000002010107"), new Guid("00000000-0000-0002-0000-000002010107"), 6.48m, new Guid("00000000-0000-0004-0000-000002010107") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000002010108"), new Guid("00000000-0000-0002-0000-000002010108"), 3.58m, new Guid("00000000-0000-0004-0000-000002010108") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000002010109"), new Guid("00000000-0000-0002-0000-000002010109"), 1.44m, new Guid("00000000-0000-0004-0000-000002010109") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-00000201010a"), new Guid("00000000-0000-0002-0000-00000201010a"), 4.83m, new Guid("00000000-0000-0004-0000-00000201010a") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000002010201"), new Guid("00000000-0000-0002-0000-000002010201"), 0.01m, new Guid("00000000-0000-0004-0000-000002010201") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000002010202"), new Guid("00000000-0000-0002-0000-000002010202"), 0.01m, new Guid("00000000-0000-0004-0000-000002010202") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000003010101"), new Guid("00000000-0000-0002-0000-000003010101"), 5.00m, new Guid("00000000-0000-0004-0000-000003010101") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000003010102"), new Guid("00000000-0000-0002-0000-000003010102"), 7.87m, new Guid("00000000-0000-0004-0000-000003010102") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000003010103"), new Guid("00000000-0000-0002-0000-000003010103"), 4.06m, new Guid("00000000-0000-0004-0000-000003010103") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000003010104"), new Guid("00000000-0000-0002-0000-000003010104"), 1.70m, new Guid("00000000-0000-0004-0000-000003010104") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000005010201"), new Guid("00000000-0000-0002-0000-000005010201"), 3.25m, new Guid("00000000-0000-0004-0000-000005010201") });

            migrationBuilder.InsertData(
                table: "TicketPurchaseSeats",
                columns: new[] { "Id", "EventSeatId", "Subtotal", "TicketPurchaseId" },
                values: new object[] { new Guid("00000000-0000-0003-0000-000005010202"), new Guid("00000000-0000-0002-0000-000005010202"), 3.25m, new Guid("00000000-0000-0004-0000-000005010202") });

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
                column: "EventSeatId",
                unique: true);

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
