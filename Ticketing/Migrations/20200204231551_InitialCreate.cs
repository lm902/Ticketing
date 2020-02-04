﻿using System;
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
                values: new object[] { new Guid("00000000-0000-0001-0000-000004000000"), 100, "Venue 4" });

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
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010101"), "Venue 1 Section 1 Row 1 Seat 1", 7.46m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010502"), "Venue 4 Section 1 Row 5 Seat 2", 4.16m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010501"), "Venue 4 Section 1 Row 5 Seat 1", 2.70m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000401040a"), "Venue 4 Section 1 Row 4 Seat 10", 4.03m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010409"), "Venue 4 Section 1 Row 4 Seat 9", 9.58m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010408"), "Venue 4 Section 1 Row 4 Seat 8", 5.94m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010407"), "Venue 4 Section 1 Row 4 Seat 7", 2.07m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010406"), "Venue 4 Section 1 Row 4 Seat 6", 0.99m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010405"), "Venue 4 Section 1 Row 4 Seat 5", 5.56m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010404"), "Venue 4 Section 1 Row 4 Seat 4", 7.70m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010403"), "Venue 4 Section 1 Row 4 Seat 3", 9.87m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010402"), "Venue 4 Section 1 Row 4 Seat 2", 2.66m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010401"), "Venue 4 Section 1 Row 4 Seat 1", 3.82m, new Guid("00000000-0000-0001-0000-000004010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000401030a"), "Venue 4 Section 1 Row 3 Seat 10", 3.51m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010309"), "Venue 4 Section 1 Row 3 Seat 9", 2.19m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010308"), "Venue 4 Section 1 Row 3 Seat 8", 1.46m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010307"), "Venue 4 Section 1 Row 3 Seat 7", 5.93m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010306"), "Venue 4 Section 1 Row 3 Seat 6", 4.79m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010305"), "Venue 4 Section 1 Row 3 Seat 5", 7.77m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010304"), "Venue 4 Section 1 Row 3 Seat 4", 2.44m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010303"), "Venue 4 Section 1 Row 3 Seat 3", 9.01m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010302"), "Venue 4 Section 1 Row 3 Seat 2", 8.73m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010301"), "Venue 4 Section 1 Row 3 Seat 1", 1.68m, new Guid("00000000-0000-0001-0000-000004010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000401020a"), "Venue 4 Section 1 Row 2 Seat 10", 3.28m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010209"), "Venue 4 Section 1 Row 2 Seat 9", 8.72m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010208"), "Venue 4 Section 1 Row 2 Seat 8", 3.67m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010207"), "Venue 4 Section 1 Row 2 Seat 7", 3.76m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010206"), "Venue 4 Section 1 Row 2 Seat 6", 0.94m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010503"), "Venue 4 Section 1 Row 5 Seat 3", 7.57m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010205"), "Venue 4 Section 1 Row 2 Seat 5", 1.22m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010504"), "Venue 4 Section 1 Row 5 Seat 4", 7.91m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010506"), "Venue 4 Section 1 Row 5 Seat 6", 1.94m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020303"), "Venue 4 Section 2 Row 3 Seat 3", 1.36m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020302"), "Venue 4 Section 2 Row 3 Seat 2", 5.08m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020301"), "Venue 4 Section 2 Row 3 Seat 1", 6.13m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000402020a"), "Venue 4 Section 2 Row 2 Seat 10", 7.49m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020209"), "Venue 4 Section 2 Row 2 Seat 9", 8.97m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020208"), "Venue 4 Section 2 Row 2 Seat 8", 7.68m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020207"), "Venue 4 Section 2 Row 2 Seat 7", 8.14m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020206"), "Venue 4 Section 2 Row 2 Seat 6", 1.82m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020205"), "Venue 4 Section 2 Row 2 Seat 5", 6.41m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020204"), "Venue 4 Section 2 Row 2 Seat 4", 2.17m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020203"), "Venue 4 Section 2 Row 2 Seat 3", 2.96m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020202"), "Venue 4 Section 2 Row 2 Seat 2", 4.15m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020201"), "Venue 4 Section 2 Row 2 Seat 1", 6.22m, new Guid("00000000-0000-0001-0000-000004020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000402010a"), "Venue 4 Section 2 Row 1 Seat 10", 0.97m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020109"), "Venue 4 Section 2 Row 1 Seat 9", 3.67m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020108"), "Venue 4 Section 2 Row 1 Seat 8", 1.73m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020107"), "Venue 4 Section 2 Row 1 Seat 7", 3.02m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020106"), "Venue 4 Section 2 Row 1 Seat 6", 0.26m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020105"), "Venue 4 Section 2 Row 1 Seat 5", 3.62m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020104"), "Venue 4 Section 2 Row 1 Seat 4", 1.34m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020103"), "Venue 4 Section 2 Row 1 Seat 3", 1.60m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020102"), "Venue 4 Section 2 Row 1 Seat 2", 5.94m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020101"), "Venue 4 Section 2 Row 1 Seat 1", 1.36m, new Guid("00000000-0000-0001-0000-000004020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000401050a"), "Venue 4 Section 1 Row 5 Seat 10", 3.18m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010509"), "Venue 4 Section 1 Row 5 Seat 9", 1.90m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010508"), "Venue 4 Section 1 Row 5 Seat 8", 2.34m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010507"), "Venue 4 Section 1 Row 5 Seat 7", 1.07m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010505"), "Venue 4 Section 1 Row 5 Seat 5", 0.40m, new Guid("00000000-0000-0001-0000-000004010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010204"), "Venue 4 Section 1 Row 2 Seat 4", 7.27m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010203"), "Venue 4 Section 1 Row 2 Seat 3", 8.11m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010202"), "Venue 4 Section 1 Row 2 Seat 2", 0.75m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020309"), "Venue 3 Section 2 Row 3 Seat 9", 8.47m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020308"), "Venue 3 Section 2 Row 3 Seat 8", 9.97m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020307"), "Venue 3 Section 2 Row 3 Seat 7", 8.46m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020306"), "Venue 3 Section 2 Row 3 Seat 6", 8.91m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020305"), "Venue 3 Section 2 Row 3 Seat 5", 4.11m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020304"), "Venue 3 Section 2 Row 3 Seat 4", 1.79m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020303"), "Venue 3 Section 2 Row 3 Seat 3", 0.06m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020302"), "Venue 3 Section 2 Row 3 Seat 2", 1.01m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020301"), "Venue 3 Section 2 Row 3 Seat 1", 9.45m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000302020a"), "Venue 3 Section 2 Row 2 Seat 10", 5.93m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020209"), "Venue 3 Section 2 Row 2 Seat 9", 5.52m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020208"), "Venue 3 Section 2 Row 2 Seat 8", 5.36m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020207"), "Venue 3 Section 2 Row 2 Seat 7", 0.19m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020206"), "Venue 3 Section 2 Row 2 Seat 6", 9.20m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020205"), "Venue 3 Section 2 Row 2 Seat 5", 9.81m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020204"), "Venue 3 Section 2 Row 2 Seat 4", 3.11m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020203"), "Venue 3 Section 2 Row 2 Seat 3", 7.22m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020202"), "Venue 3 Section 2 Row 2 Seat 2", 9.36m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020201"), "Venue 3 Section 2 Row 2 Seat 1", 5.40m, new Guid("00000000-0000-0001-0000-000003020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000302010a"), "Venue 3 Section 2 Row 1 Seat 10", 2.44m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020109"), "Venue 3 Section 2 Row 1 Seat 9", 0.04m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020108"), "Venue 3 Section 2 Row 1 Seat 8", 9.32m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020107"), "Venue 3 Section 2 Row 1 Seat 7", 3.45m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020106"), "Venue 3 Section 2 Row 1 Seat 6", 8.41m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020105"), "Venue 3 Section 2 Row 1 Seat 5", 4.61m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020104"), "Venue 3 Section 2 Row 1 Seat 4", 5.25m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020103"), "Venue 3 Section 2 Row 1 Seat 3", 2.42m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000302030a"), "Venue 3 Section 2 Row 3 Seat 10", 0.03m, new Guid("00000000-0000-0001-0000-000003020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020401"), "Venue 3 Section 2 Row 4 Seat 1", 8.49m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020402"), "Venue 3 Section 2 Row 4 Seat 2", 1.72m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020403"), "Venue 3 Section 2 Row 4 Seat 3", 2.86m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010201"), "Venue 4 Section 1 Row 2 Seat 1", 7.22m, new Guid("00000000-0000-0001-0000-000004010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000401010a"), "Venue 4 Section 1 Row 1 Seat 10", 2.97m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010109"), "Venue 4 Section 1 Row 1 Seat 9", 8.41m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010108"), "Venue 4 Section 1 Row 1 Seat 8", 7.89m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010107"), "Venue 4 Section 1 Row 1 Seat 7", 8.35m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010106"), "Venue 4 Section 1 Row 1 Seat 6", 4.88m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010105"), "Venue 4 Section 1 Row 1 Seat 5", 8.50m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010104"), "Venue 4 Section 1 Row 1 Seat 4", 4.18m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010103"), "Venue 4 Section 1 Row 1 Seat 3", 6.91m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010102"), "Venue 4 Section 1 Row 1 Seat 2", 4.76m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004010101"), "Venue 4 Section 1 Row 1 Seat 1", 1.73m, new Guid("00000000-0000-0001-0000-000004010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000302050a"), "Venue 3 Section 2 Row 5 Seat 10", 8.03m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020509"), "Venue 3 Section 2 Row 5 Seat 9", 7.35m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020304"), "Venue 4 Section 2 Row 3 Seat 4", 1.95m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020508"), "Venue 3 Section 2 Row 5 Seat 8", 3.06m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020506"), "Venue 3 Section 2 Row 5 Seat 6", 7.86m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020505"), "Venue 3 Section 2 Row 5 Seat 5", 6.87m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020504"), "Venue 3 Section 2 Row 5 Seat 4", 5.86m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020503"), "Venue 3 Section 2 Row 5 Seat 3", 2.34m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020502"), "Venue 3 Section 2 Row 5 Seat 2", 1.92m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020501"), "Venue 3 Section 2 Row 5 Seat 1", 5.43m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000302040a"), "Venue 3 Section 2 Row 4 Seat 10", 0.35m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020409"), "Venue 3 Section 2 Row 4 Seat 9", 3.62m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020408"), "Venue 3 Section 2 Row 4 Seat 8", 8.72m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020407"), "Venue 3 Section 2 Row 4 Seat 7", 4.78m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020406"), "Venue 3 Section 2 Row 4 Seat 6", 3.80m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020405"), "Venue 3 Section 2 Row 4 Seat 5", 1.65m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020404"), "Venue 3 Section 2 Row 4 Seat 4", 0.81m, new Guid("00000000-0000-0001-0000-000003020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020507"), "Venue 3 Section 2 Row 5 Seat 7", 2.35m, new Guid("00000000-0000-0001-0000-000003020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020102"), "Venue 3 Section 2 Row 1 Seat 2", 1.15m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020305"), "Venue 4 Section 2 Row 3 Seat 5", 7.84m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020307"), "Venue 4 Section 2 Row 3 Seat 7", 8.42m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020207"), "Venue 5 Section 2 Row 2 Seat 7", 2.34m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020206"), "Venue 5 Section 2 Row 2 Seat 6", 3.35m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020205"), "Venue 5 Section 2 Row 2 Seat 5", 9.78m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020204"), "Venue 5 Section 2 Row 2 Seat 4", 8.74m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020203"), "Venue 5 Section 2 Row 2 Seat 3", 0.05m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020202"), "Venue 5 Section 2 Row 2 Seat 2", 6.35m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020201"), "Venue 5 Section 2 Row 2 Seat 1", 8.00m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000502010a"), "Venue 5 Section 2 Row 1 Seat 10", 5.78m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020109"), "Venue 5 Section 2 Row 1 Seat 9", 9.43m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020108"), "Venue 5 Section 2 Row 1 Seat 8", 4.23m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020107"), "Venue 5 Section 2 Row 1 Seat 7", 4.33m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020106"), "Venue 5 Section 2 Row 1 Seat 6", 8.72m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020105"), "Venue 5 Section 2 Row 1 Seat 5", 2.33m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020104"), "Venue 5 Section 2 Row 1 Seat 4", 7.51m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020103"), "Venue 5 Section 2 Row 1 Seat 3", 9.91m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020102"), "Venue 5 Section 2 Row 1 Seat 2", 1.78m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020101"), "Venue 5 Section 2 Row 1 Seat 1", 8.48m, new Guid("00000000-0000-0001-0000-000005020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000501050a"), "Venue 5 Section 1 Row 5 Seat 10", 9.71m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010509"), "Venue 5 Section 1 Row 5 Seat 9", 5.87m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010508"), "Venue 5 Section 1 Row 5 Seat 8", 8.95m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010507"), "Venue 5 Section 1 Row 5 Seat 7", 5.17m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010506"), "Venue 5 Section 1 Row 5 Seat 6", 0.58m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010505"), "Venue 5 Section 1 Row 5 Seat 5", 0.72m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010504"), "Venue 5 Section 1 Row 5 Seat 4", 2.50m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010503"), "Venue 5 Section 1 Row 5 Seat 3", 2.30m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010502"), "Venue 5 Section 1 Row 5 Seat 2", 8.67m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010501"), "Venue 5 Section 1 Row 5 Seat 1", 0.57m, new Guid("00000000-0000-0001-0000-000005010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020208"), "Venue 5 Section 2 Row 2 Seat 8", 6.23m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000501040a"), "Venue 5 Section 1 Row 4 Seat 10", 3.12m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020209"), "Venue 5 Section 2 Row 2 Seat 9", 5.81m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020301"), "Venue 5 Section 2 Row 3 Seat 1", 2.42m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020508"), "Venue 5 Section 2 Row 5 Seat 8", 0.82m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020507"), "Venue 5 Section 2 Row 5 Seat 7", 5.88m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020506"), "Venue 5 Section 2 Row 5 Seat 6", 1.48m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020505"), "Venue 5 Section 2 Row 5 Seat 5", 2.38m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020504"), "Venue 5 Section 2 Row 5 Seat 4", 0.70m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020503"), "Venue 5 Section 2 Row 5 Seat 3", 0.23m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020502"), "Venue 5 Section 2 Row 5 Seat 2", 0.50m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020501"), "Venue 5 Section 2 Row 5 Seat 1", 0.51m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000502040a"), "Venue 5 Section 2 Row 4 Seat 10", 7.84m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020409"), "Venue 5 Section 2 Row 4 Seat 9", 5.66m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020408"), "Venue 5 Section 2 Row 4 Seat 8", 6.60m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020407"), "Venue 5 Section 2 Row 4 Seat 7", 0.37m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020406"), "Venue 5 Section 2 Row 4 Seat 6", 9.06m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020405"), "Venue 5 Section 2 Row 4 Seat 5", 8.07m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020404"), "Venue 5 Section 2 Row 4 Seat 4", 1.68m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020403"), "Venue 5 Section 2 Row 4 Seat 3", 4.15m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020402"), "Venue 5 Section 2 Row 4 Seat 2", 1.12m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020401"), "Venue 5 Section 2 Row 4 Seat 1", 7.89m, new Guid("00000000-0000-0001-0000-000005020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000502030a"), "Venue 5 Section 2 Row 3 Seat 10", 6.20m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020309"), "Venue 5 Section 2 Row 3 Seat 9", 0.21m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020308"), "Venue 5 Section 2 Row 3 Seat 8", 8.35m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020307"), "Venue 5 Section 2 Row 3 Seat 7", 4.57m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020306"), "Venue 5 Section 2 Row 3 Seat 6", 9.36m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020305"), "Venue 5 Section 2 Row 3 Seat 5", 5.22m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020304"), "Venue 5 Section 2 Row 3 Seat 4", 4.17m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020303"), "Venue 5 Section 2 Row 3 Seat 3", 1.99m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020302"), "Venue 5 Section 2 Row 3 Seat 2", 9.46m, new Guid("00000000-0000-0001-0000-000005020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000502020a"), "Venue 5 Section 2 Row 2 Seat 10", 6.94m, new Guid("00000000-0000-0001-0000-000005020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010409"), "Venue 5 Section 1 Row 4 Seat 9", 9.22m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010408"), "Venue 5 Section 1 Row 4 Seat 8", 2.40m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010407"), "Venue 5 Section 1 Row 4 Seat 7", 7.48m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010104"), "Venue 5 Section 1 Row 1 Seat 4", 1.68m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010103"), "Venue 5 Section 1 Row 1 Seat 3", 0.64m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010102"), "Venue 5 Section 1 Row 1 Seat 2", 0.66m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010101"), "Venue 5 Section 1 Row 1 Seat 1", 1.06m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000402050a"), "Venue 4 Section 2 Row 5 Seat 10", 5.83m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020509"), "Venue 4 Section 2 Row 5 Seat 9", 8.77m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020508"), "Venue 4 Section 2 Row 5 Seat 8", 2.67m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020507"), "Venue 4 Section 2 Row 5 Seat 7", 8.47m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020506"), "Venue 4 Section 2 Row 5 Seat 6", 5.81m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020505"), "Venue 4 Section 2 Row 5 Seat 5", 5.08m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020504"), "Venue 4 Section 2 Row 5 Seat 4", 5.87m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020503"), "Venue 4 Section 2 Row 5 Seat 3", 9.53m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020502"), "Venue 4 Section 2 Row 5 Seat 2", 7.60m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020501"), "Venue 4 Section 2 Row 5 Seat 1", 5.24m, new Guid("00000000-0000-0001-0000-000004020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000402040a"), "Venue 4 Section 2 Row 4 Seat 10", 2.56m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020409"), "Venue 4 Section 2 Row 4 Seat 9", 1.34m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020408"), "Venue 4 Section 2 Row 4 Seat 8", 5.80m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020407"), "Venue 4 Section 2 Row 4 Seat 7", 8.32m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020406"), "Venue 4 Section 2 Row 4 Seat 6", 5.15m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020405"), "Venue 4 Section 2 Row 4 Seat 5", 9.40m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020404"), "Venue 4 Section 2 Row 4 Seat 4", 6.27m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020403"), "Venue 4 Section 2 Row 4 Seat 3", 6.82m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020402"), "Venue 4 Section 2 Row 4 Seat 2", 0.85m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020401"), "Venue 4 Section 2 Row 4 Seat 1", 0.98m, new Guid("00000000-0000-0001-0000-000004020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000402030a"), "Venue 4 Section 2 Row 3 Seat 10", 3.09m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020309"), "Venue 4 Section 2 Row 3 Seat 9", 9.30m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020308"), "Venue 4 Section 2 Row 3 Seat 8", 8.35m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010105"), "Venue 5 Section 1 Row 1 Seat 5", 4.31m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010106"), "Venue 5 Section 1 Row 1 Seat 6", 3.55m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010107"), "Venue 5 Section 1 Row 1 Seat 7", 1.84m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010108"), "Venue 5 Section 1 Row 1 Seat 8", 6.92m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010406"), "Venue 5 Section 1 Row 4 Seat 6", 7.58m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010405"), "Venue 5 Section 1 Row 4 Seat 5", 9.29m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010404"), "Venue 5 Section 1 Row 4 Seat 4", 0.73m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010403"), "Venue 5 Section 1 Row 4 Seat 3", 6.85m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010402"), "Venue 5 Section 1 Row 4 Seat 2", 3.02m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010401"), "Venue 5 Section 1 Row 4 Seat 1", 3.58m, new Guid("00000000-0000-0001-0000-000005010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000501030a"), "Venue 5 Section 1 Row 3 Seat 10", 9.29m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010309"), "Venue 5 Section 1 Row 3 Seat 9", 4.13m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010308"), "Venue 5 Section 1 Row 3 Seat 8", 2.76m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010307"), "Venue 5 Section 1 Row 3 Seat 7", 2.81m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010306"), "Venue 5 Section 1 Row 3 Seat 6", 5.79m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010305"), "Venue 5 Section 1 Row 3 Seat 5", 9.51m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010304"), "Venue 5 Section 1 Row 3 Seat 4", 3.67m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000004020306"), "Venue 4 Section 2 Row 3 Seat 6", 4.78m, new Guid("00000000-0000-0001-0000-000004020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010303"), "Venue 5 Section 1 Row 3 Seat 3", 3.60m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010301"), "Venue 5 Section 1 Row 3 Seat 1", 0.77m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000501020a"), "Venue 5 Section 1 Row 2 Seat 10", 8.52m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010209"), "Venue 5 Section 1 Row 2 Seat 9", 0.02m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010208"), "Venue 5 Section 1 Row 2 Seat 8", 3.95m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010207"), "Venue 5 Section 1 Row 2 Seat 7", 4.60m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010206"), "Venue 5 Section 1 Row 2 Seat 6", 2.63m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010205"), "Venue 5 Section 1 Row 2 Seat 5", 7.26m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010204"), "Venue 5 Section 1 Row 2 Seat 4", 7.84m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010203"), "Venue 5 Section 1 Row 2 Seat 3", 9.69m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010202"), "Venue 5 Section 1 Row 2 Seat 2", 1.93m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010201"), "Venue 5 Section 1 Row 2 Seat 1", 9.10m, new Guid("00000000-0000-0001-0000-000005010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000501010a"), "Venue 5 Section 1 Row 1 Seat 10", 6.10m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010109"), "Venue 5 Section 1 Row 1 Seat 9", 0.76m, new Guid("00000000-0000-0001-0000-000005010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005010302"), "Venue 5 Section 1 Row 3 Seat 2", 9.60m, new Guid("00000000-0000-0001-0000-000005010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003020101"), "Venue 3 Section 2 Row 1 Seat 1", 8.63m, new Guid("00000000-0000-0001-0000-000003020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000301050a"), "Venue 3 Section 1 Row 5 Seat 10", 0.69m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010509"), "Venue 3 Section 1 Row 5 Seat 9", 2.85m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020501"), "Venue 1 Section 2 Row 5 Seat 1", 7.04m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000102040a"), "Venue 1 Section 2 Row 4 Seat 10", 6.83m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020409"), "Venue 1 Section 2 Row 4 Seat 9", 4.86m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020408"), "Venue 1 Section 2 Row 4 Seat 8", 7.25m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020407"), "Venue 1 Section 2 Row 4 Seat 7", 4.45m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020406"), "Venue 1 Section 2 Row 4 Seat 6", 8.75m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020405"), "Venue 1 Section 2 Row 4 Seat 5", 2.62m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020404"), "Venue 1 Section 2 Row 4 Seat 4", 2.08m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020403"), "Venue 1 Section 2 Row 4 Seat 3", 7.44m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020402"), "Venue 1 Section 2 Row 4 Seat 2", 4.17m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020401"), "Venue 1 Section 2 Row 4 Seat 1", 5.77m, new Guid("00000000-0000-0001-0000-000001020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000102030a"), "Venue 1 Section 2 Row 3 Seat 10", 2.04m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020309"), "Venue 1 Section 2 Row 3 Seat 9", 4.26m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020308"), "Venue 1 Section 2 Row 3 Seat 8", 5.31m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020307"), "Venue 1 Section 2 Row 3 Seat 7", 4.92m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020306"), "Venue 1 Section 2 Row 3 Seat 6", 6.68m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020305"), "Venue 1 Section 2 Row 3 Seat 5", 5.96m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020304"), "Venue 1 Section 2 Row 3 Seat 4", 6.66m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020303"), "Venue 1 Section 2 Row 3 Seat 3", 2.96m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020302"), "Venue 1 Section 2 Row 3 Seat 2", 7.55m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020301"), "Venue 1 Section 2 Row 3 Seat 1", 8.57m, new Guid("00000000-0000-0001-0000-000001020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000102020a"), "Venue 1 Section 2 Row 2 Seat 10", 5.35m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020209"), "Venue 1 Section 2 Row 2 Seat 9", 7.26m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020208"), "Venue 1 Section 2 Row 2 Seat 8", 4.87m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020207"), "Venue 1 Section 2 Row 2 Seat 7", 5.30m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020206"), "Venue 1 Section 2 Row 2 Seat 6", 8.14m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020205"), "Venue 1 Section 2 Row 2 Seat 5", 2.86m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020502"), "Venue 1 Section 2 Row 5 Seat 2", 0.18m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020204"), "Venue 1 Section 2 Row 2 Seat 4", 5.83m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020503"), "Venue 1 Section 2 Row 5 Seat 3", 7.69m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020505"), "Venue 1 Section 2 Row 5 Seat 5", 4.65m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010302"), "Venue 2 Section 1 Row 3 Seat 2", 5.31m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010301"), "Venue 2 Section 1 Row 3 Seat 1", 0.95m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000201020a"), "Venue 2 Section 1 Row 2 Seat 10", 1.37m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010209"), "Venue 2 Section 1 Row 2 Seat 9", 0.47m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010208"), "Venue 2 Section 1 Row 2 Seat 8", 4.57m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010207"), "Venue 2 Section 1 Row 2 Seat 7", 1.17m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010206"), "Venue 2 Section 1 Row 2 Seat 6", 8.42m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010205"), "Venue 2 Section 1 Row 2 Seat 5", 6.35m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010204"), "Venue 2 Section 1 Row 2 Seat 4", 0.50m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010203"), "Venue 2 Section 1 Row 2 Seat 3", 7.69m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010202"), "Venue 2 Section 1 Row 2 Seat 2", 6.96m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010201"), "Venue 2 Section 1 Row 2 Seat 1", 4.13m, new Guid("00000000-0000-0001-0000-000002010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000201010a"), "Venue 2 Section 1 Row 1 Seat 10", 1.82m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010109"), "Venue 2 Section 1 Row 1 Seat 9", 9.30m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010108"), "Venue 2 Section 1 Row 1 Seat 8", 1.63m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010107"), "Venue 2 Section 1 Row 1 Seat 7", 3.37m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010106"), "Venue 2 Section 1 Row 1 Seat 6", 8.71m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010105"), "Venue 2 Section 1 Row 1 Seat 5", 4.56m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010104"), "Venue 2 Section 1 Row 1 Seat 4", 6.30m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010103"), "Venue 2 Section 1 Row 1 Seat 3", 7.23m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010102"), "Venue 2 Section 1 Row 1 Seat 2", 6.64m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010101"), "Venue 2 Section 1 Row 1 Seat 1", 0.02m, new Guid("00000000-0000-0001-0000-000002010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000102050a"), "Venue 1 Section 2 Row 5 Seat 10", 4.80m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020509"), "Venue 1 Section 2 Row 5 Seat 9", 1.71m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020508"), "Venue 1 Section 2 Row 5 Seat 8", 6.71m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020507"), "Venue 1 Section 2 Row 5 Seat 7", 7.64m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020506"), "Venue 1 Section 2 Row 5 Seat 6", 4.44m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020504"), "Venue 1 Section 2 Row 5 Seat 4", 9.26m, new Guid("00000000-0000-0001-0000-000001020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020203"), "Venue 1 Section 2 Row 2 Seat 3", 9.39m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020202"), "Venue 1 Section 2 Row 2 Seat 2", 1.34m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020201"), "Venue 1 Section 2 Row 2 Seat 1", 5.32m, new Guid("00000000-0000-0001-0000-000001020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010308"), "Venue 1 Section 1 Row 3 Seat 8", 4.56m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010307"), "Venue 1 Section 1 Row 3 Seat 7", 4.13m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010306"), "Venue 1 Section 1 Row 3 Seat 6", 2.76m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010305"), "Venue 1 Section 1 Row 3 Seat 5", 2.84m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010304"), "Venue 1 Section 1 Row 3 Seat 4", 2.68m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010303"), "Venue 1 Section 1 Row 3 Seat 3", 5.36m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010302"), "Venue 1 Section 1 Row 3 Seat 2", 2.93m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010301"), "Venue 1 Section 1 Row 3 Seat 1", 9.19m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000101020a"), "Venue 1 Section 1 Row 2 Seat 10", 7.23m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010209"), "Venue 1 Section 1 Row 2 Seat 9", 2.11m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010208"), "Venue 1 Section 1 Row 2 Seat 8", 2.56m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010207"), "Venue 1 Section 1 Row 2 Seat 7", 6.00m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010206"), "Venue 1 Section 1 Row 2 Seat 6", 8.91m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010205"), "Venue 1 Section 1 Row 2 Seat 5", 2.88m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010204"), "Venue 1 Section 1 Row 2 Seat 4", 1.35m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010203"), "Venue 1 Section 1 Row 2 Seat 3", 6.45m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010202"), "Venue 1 Section 1 Row 2 Seat 2", 6.03m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010201"), "Venue 1 Section 1 Row 2 Seat 1", 9.09m, new Guid("00000000-0000-0001-0000-000001010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000101010a"), "Venue 1 Section 1 Row 1 Seat 10", 6.16m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010109"), "Venue 1 Section 1 Row 1 Seat 9", 2.92m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010108"), "Venue 1 Section 1 Row 1 Seat 8", 2.82m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010107"), "Venue 1 Section 1 Row 1 Seat 7", 8.65m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010106"), "Venue 1 Section 1 Row 1 Seat 6", 2.19m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010105"), "Venue 1 Section 1 Row 1 Seat 5", 0.36m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010104"), "Venue 1 Section 1 Row 1 Seat 4", 0.86m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010103"), "Venue 1 Section 1 Row 1 Seat 3", 0.10m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010102"), "Venue 1 Section 1 Row 1 Seat 2", 3.11m, new Guid("00000000-0000-0001-0000-000001010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010309"), "Venue 1 Section 1 Row 3 Seat 9", 0.69m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000101030a"), "Venue 1 Section 1 Row 3 Seat 10", 4.35m, new Guid("00000000-0000-0001-0000-000001010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010401"), "Venue 1 Section 1 Row 4 Seat 1", 0.56m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010402"), "Venue 1 Section 1 Row 4 Seat 2", 8.21m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000102010a"), "Venue 1 Section 2 Row 1 Seat 10", 4.86m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020109"), "Venue 1 Section 2 Row 1 Seat 9", 5.28m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020108"), "Venue 1 Section 2 Row 1 Seat 8", 4.69m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020107"), "Venue 1 Section 2 Row 1 Seat 7", 5.01m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020106"), "Venue 1 Section 2 Row 1 Seat 6", 1.79m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020105"), "Venue 1 Section 2 Row 1 Seat 5", 1.24m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020104"), "Venue 1 Section 2 Row 1 Seat 4", 8.00m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020103"), "Venue 1 Section 2 Row 1 Seat 3", 1.03m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020102"), "Venue 1 Section 2 Row 1 Seat 2", 9.07m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001020101"), "Venue 1 Section 2 Row 1 Seat 1", 9.00m, new Guid("00000000-0000-0001-0000-000001020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000101050a"), "Venue 1 Section 1 Row 5 Seat 10", 5.87m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010509"), "Venue 1 Section 1 Row 5 Seat 9", 4.39m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010508"), "Venue 1 Section 1 Row 5 Seat 8", 7.23m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010303"), "Venue 2 Section 1 Row 3 Seat 3", 7.28m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010507"), "Venue 1 Section 1 Row 5 Seat 7", 4.25m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010505"), "Venue 1 Section 1 Row 5 Seat 5", 5.68m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010504"), "Venue 1 Section 1 Row 5 Seat 4", 7.31m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010503"), "Venue 1 Section 1 Row 5 Seat 3", 5.27m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010502"), "Venue 1 Section 1 Row 5 Seat 2", 9.77m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010501"), "Venue 1 Section 1 Row 5 Seat 1", 8.53m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000101040a"), "Venue 1 Section 1 Row 4 Seat 10", 2.71m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010409"), "Venue 1 Section 1 Row 4 Seat 9", 6.86m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010408"), "Venue 1 Section 1 Row 4 Seat 8", 5.71m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010407"), "Venue 1 Section 1 Row 4 Seat 7", 7.61m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010406"), "Venue 1 Section 1 Row 4 Seat 6", 4.79m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010405"), "Venue 1 Section 1 Row 4 Seat 5", 1.35m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010404"), "Venue 1 Section 1 Row 4 Seat 4", 8.83m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010403"), "Venue 1 Section 1 Row 4 Seat 3", 7.99m, new Guid("00000000-0000-0001-0000-000001010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000001010506"), "Venue 1 Section 1 Row 5 Seat 6", 8.06m, new Guid("00000000-0000-0001-0000-000001010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010304"), "Venue 2 Section 1 Row 3 Seat 4", 7.69m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010305"), "Venue 2 Section 1 Row 3 Seat 5", 5.57m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010306"), "Venue 2 Section 1 Row 3 Seat 6", 5.65m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010206"), "Venue 3 Section 1 Row 2 Seat 6", 6.17m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010205"), "Venue 3 Section 1 Row 2 Seat 5", 0.28m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010204"), "Venue 3 Section 1 Row 2 Seat 4", 9.76m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010203"), "Venue 3 Section 1 Row 2 Seat 3", 9.06m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010202"), "Venue 3 Section 1 Row 2 Seat 2", 9.64m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010201"), "Venue 3 Section 1 Row 2 Seat 1", 1.87m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000301010a"), "Venue 3 Section 1 Row 1 Seat 10", 0.23m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010109"), "Venue 3 Section 1 Row 1 Seat 9", 8.87m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010108"), "Venue 3 Section 1 Row 1 Seat 8", 4.19m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010107"), "Venue 3 Section 1 Row 1 Seat 7", 0.54m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010106"), "Venue 3 Section 1 Row 1 Seat 6", 7.77m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010105"), "Venue 3 Section 1 Row 1 Seat 5", 9.27m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010104"), "Venue 3 Section 1 Row 1 Seat 4", 0.21m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010103"), "Venue 3 Section 1 Row 1 Seat 3", 3.23m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010102"), "Venue 3 Section 1 Row 1 Seat 2", 8.80m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010101"), "Venue 3 Section 1 Row 1 Seat 1", 1.25m, new Guid("00000000-0000-0001-0000-000003010100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000202050a"), "Venue 2 Section 2 Row 5 Seat 10", 1.30m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020509"), "Venue 2 Section 2 Row 5 Seat 9", 4.79m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020508"), "Venue 2 Section 2 Row 5 Seat 8", 4.69m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020507"), "Venue 2 Section 2 Row 5 Seat 7", 7.72m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020506"), "Venue 2 Section 2 Row 5 Seat 6", 0.23m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020505"), "Venue 2 Section 2 Row 5 Seat 5", 9.59m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020504"), "Venue 2 Section 2 Row 5 Seat 4", 5.87m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020503"), "Venue 2 Section 2 Row 5 Seat 3", 7.67m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020502"), "Venue 2 Section 2 Row 5 Seat 2", 4.66m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020501"), "Venue 2 Section 2 Row 5 Seat 1", 7.04m, new Guid("00000000-0000-0001-0000-000002020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000202040a"), "Venue 2 Section 2 Row 4 Seat 10", 4.57m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010207"), "Venue 3 Section 1 Row 2 Seat 7", 8.87m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010208"), "Venue 3 Section 1 Row 2 Seat 8", 3.83m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010209"), "Venue 3 Section 1 Row 2 Seat 9", 9.54m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000301020a"), "Venue 3 Section 1 Row 2 Seat 10", 6.80m, new Guid("00000000-0000-0001-0000-000003010200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010508"), "Venue 3 Section 1 Row 5 Seat 8", 5.17m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010507"), "Venue 3 Section 1 Row 5 Seat 7", 2.86m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010506"), "Venue 3 Section 1 Row 5 Seat 6", 4.66m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010505"), "Venue 3 Section 1 Row 5 Seat 5", 9.97m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010504"), "Venue 3 Section 1 Row 5 Seat 4", 9.91m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010503"), "Venue 3 Section 1 Row 5 Seat 3", 8.91m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010502"), "Venue 3 Section 1 Row 5 Seat 2", 2.30m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010501"), "Venue 3 Section 1 Row 5 Seat 1", 9.96m, new Guid("00000000-0000-0001-0000-000003010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000301040a"), "Venue 3 Section 1 Row 4 Seat 10", 5.00m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010409"), "Venue 3 Section 1 Row 4 Seat 9", 1.04m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010408"), "Venue 3 Section 1 Row 4 Seat 8", 5.12m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010407"), "Venue 3 Section 1 Row 4 Seat 7", 3.98m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010406"), "Venue 3 Section 1 Row 4 Seat 6", 1.62m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020409"), "Venue 2 Section 2 Row 4 Seat 9", 2.88m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010405"), "Venue 3 Section 1 Row 4 Seat 5", 1.50m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010403"), "Venue 3 Section 1 Row 4 Seat 3", 6.71m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010402"), "Venue 3 Section 1 Row 4 Seat 2", 9.94m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010401"), "Venue 3 Section 1 Row 4 Seat 1", 7.68m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000301030a"), "Venue 3 Section 1 Row 3 Seat 10", 3.02m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010309"), "Venue 3 Section 1 Row 3 Seat 9", 4.24m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010308"), "Venue 3 Section 1 Row 3 Seat 8", 8.45m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010307"), "Venue 3 Section 1 Row 3 Seat 7", 9.63m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010306"), "Venue 3 Section 1 Row 3 Seat 6", 4.09m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010305"), "Venue 3 Section 1 Row 3 Seat 5", 7.44m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010304"), "Venue 3 Section 1 Row 3 Seat 4", 1.17m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010303"), "Venue 3 Section 1 Row 3 Seat 3", 2.61m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010302"), "Venue 3 Section 1 Row 3 Seat 2", 0.10m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010301"), "Venue 3 Section 1 Row 3 Seat 1", 3.95m, new Guid("00000000-0000-0001-0000-000003010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000003010404"), "Venue 3 Section 1 Row 4 Seat 4", 0.96m, new Guid("00000000-0000-0001-0000-000003010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000005020509"), "Venue 5 Section 2 Row 5 Seat 9", 9.98m, new Guid("00000000-0000-0001-0000-000005020500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020408"), "Venue 2 Section 2 Row 4 Seat 8", 0.52m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020406"), "Venue 2 Section 2 Row 4 Seat 6", 3.24m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020103"), "Venue 2 Section 2 Row 1 Seat 3", 3.50m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020102"), "Venue 2 Section 2 Row 1 Seat 2", 0.33m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020101"), "Venue 2 Section 2 Row 1 Seat 1", 0.54m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000201050a"), "Venue 2 Section 1 Row 5 Seat 10", 3.49m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010509"), "Venue 2 Section 1 Row 5 Seat 9", 0.16m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010508"), "Venue 2 Section 1 Row 5 Seat 8", 4.45m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010507"), "Venue 2 Section 1 Row 5 Seat 7", 9.76m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010506"), "Venue 2 Section 1 Row 5 Seat 6", 7.35m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010505"), "Venue 2 Section 1 Row 5 Seat 5", 9.96m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010504"), "Venue 2 Section 1 Row 5 Seat 4", 0.30m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010503"), "Venue 2 Section 1 Row 5 Seat 3", 5.21m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010502"), "Venue 2 Section 1 Row 5 Seat 2", 0.08m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010501"), "Venue 2 Section 1 Row 5 Seat 1", 2.64m, new Guid("00000000-0000-0001-0000-000002010500") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000201040a"), "Venue 2 Section 1 Row 4 Seat 10", 1.17m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010409"), "Venue 2 Section 1 Row 4 Seat 9", 4.78m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010408"), "Venue 2 Section 1 Row 4 Seat 8", 8.40m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010407"), "Venue 2 Section 1 Row 4 Seat 7", 4.20m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010406"), "Venue 2 Section 1 Row 4 Seat 6", 6.40m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010405"), "Venue 2 Section 1 Row 4 Seat 5", 9.28m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010404"), "Venue 2 Section 1 Row 4 Seat 4", 6.72m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010403"), "Venue 2 Section 1 Row 4 Seat 3", 0.86m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010402"), "Venue 2 Section 1 Row 4 Seat 2", 5.47m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010401"), "Venue 2 Section 1 Row 4 Seat 1", 6.31m, new Guid("00000000-0000-0001-0000-000002010400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000201030a"), "Venue 2 Section 1 Row 3 Seat 10", 8.78m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010309"), "Venue 2 Section 1 Row 3 Seat 9", 9.28m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010308"), "Venue 2 Section 1 Row 3 Seat 8", 0.97m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002010307"), "Venue 2 Section 1 Row 3 Seat 7", 7.13m, new Guid("00000000-0000-0001-0000-000002010300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020104"), "Venue 2 Section 2 Row 1 Seat 4", 7.61m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020105"), "Venue 2 Section 2 Row 1 Seat 5", 1.11m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020106"), "Venue 2 Section 2 Row 1 Seat 6", 1.97m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020107"), "Venue 2 Section 2 Row 1 Seat 7", 6.62m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020405"), "Venue 2 Section 2 Row 4 Seat 5", 5.51m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020404"), "Venue 2 Section 2 Row 4 Seat 4", 3.05m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020403"), "Venue 2 Section 2 Row 4 Seat 3", 8.07m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020402"), "Venue 2 Section 2 Row 4 Seat 2", 9.94m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020401"), "Venue 2 Section 2 Row 4 Seat 1", 3.15m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000202030a"), "Venue 2 Section 2 Row 3 Seat 10", 5.49m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020309"), "Venue 2 Section 2 Row 3 Seat 9", 5.00m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020308"), "Venue 2 Section 2 Row 3 Seat 8", 4.24m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020307"), "Venue 2 Section 2 Row 3 Seat 7", 7.36m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020306"), "Venue 2 Section 2 Row 3 Seat 6", 8.14m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020305"), "Venue 2 Section 2 Row 3 Seat 5", 5.99m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020304"), "Venue 2 Section 2 Row 3 Seat 4", 6.56m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020303"), "Venue 2 Section 2 Row 3 Seat 3", 7.05m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020407"), "Venue 2 Section 2 Row 4 Seat 7", 9.24m, new Guid("00000000-0000-0001-0000-000002020400") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020302"), "Venue 2 Section 2 Row 3 Seat 2", 0.03m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000202020a"), "Venue 2 Section 2 Row 2 Seat 10", 7.22m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020209"), "Venue 2 Section 2 Row 2 Seat 9", 8.48m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020208"), "Venue 2 Section 2 Row 2 Seat 8", 8.22m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020207"), "Venue 2 Section 2 Row 2 Seat 7", 3.36m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020206"), "Venue 2 Section 2 Row 2 Seat 6", 5.92m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020205"), "Venue 2 Section 2 Row 2 Seat 5", 2.77m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020204"), "Venue 2 Section 2 Row 2 Seat 4", 7.78m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020203"), "Venue 2 Section 2 Row 2 Seat 3", 9.62m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020202"), "Venue 2 Section 2 Row 2 Seat 2", 9.67m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020201"), "Venue 2 Section 2 Row 2 Seat 1", 8.84m, new Guid("00000000-0000-0001-0000-000002020200") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000202010a"), "Venue 2 Section 2 Row 1 Seat 10", 6.17m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020109"), "Venue 2 Section 2 Row 1 Seat 9", 7.99m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020108"), "Venue 2 Section 2 Row 1 Seat 8", 6.80m, new Guid("00000000-0000-0001-0000-000002020100") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-000002020301"), "Venue 2 Section 2 Row 3 Seat 1", 1.48m, new Guid("00000000-0000-0001-0000-000002020300") });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Name", "Price", "RowId" },
                values: new object[] { new Guid("00000000-0000-0001-0000-00000502050a"), "Venue 5 Section 2 Row 5 Seat 10", 4.64m, new Guid("00000000-0000-0001-0000-000005020500") });

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