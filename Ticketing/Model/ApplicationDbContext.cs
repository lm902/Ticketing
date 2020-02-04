using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Ticketing.Model
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventSeat> EventSeats { get; set; }
        public DbSet<TicketPurchase> TicketPurchases { get; set; }
        public DbSet<TicketPurchaseSeat> TicketPurchaseSeats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TicketPurchaseSeat>().HasIndex(x => x.EventSeatId).IsUnique();
            var events = new List<Event>();
            var venues = new List<Venue>();
            for (var e = 1; e <= 5; e++)
            {
                var sections = new List<Section>();
                for (var s = 1; s <= 2; s++)
                {
                    var rows = new List<Row>();
                    for (var r = 1; r <= 5; r++)
                    {
                        var seats = new List<Seat>();
                        var eventSeats = new List<EventSeat>();
                        for (var t = 1; t <= 10; t++)
                        {
                            seats.Add(new Seat
                            {
                                Id = new Guid(0, 0, 1, 0, 0, 0, 0, (byte)e, (byte)s, (byte)r, (byte)t),
                                Name = $"Venue {e} Section {s} Row {r} Seat {t}",
                                Price = Math.Round((decimal)new Random().NextDouble() * 10, 2),
                                RowId = new Guid(0, 0, 1, 0, 0, 0, 0, (byte)e, (byte)s, (byte)r, 0)
                            });
                            eventSeats.Add(new EventSeat
                            {
                                Id = new Guid(0, 0, 2, 0, 0, 0, 0, (byte)e, (byte)s, (byte)r, (byte)t),
                                SeatId = new Guid(0, 0, 1, 0, 0, 0, 0, (byte)e, (byte)s, (byte)r, (byte)t),
                                EventId = new Guid(0, 0, 1, 0, 0, 0, (byte)e, 0, 0, 0, 0),
                                Price = Math.Round((decimal)new Random().NextDouble() * 10, 2)
                            });
                        }
                        builder.Entity<Seat>().HasData(seats);
                        builder.Entity<EventSeat>().HasData(eventSeats);
                        rows.Add(new Row
                        {
                            Id = new Guid(0, 0, 1, 0, 0, 0, 0, (byte)e, (byte)s, (byte)r, 0),
                            Name = $"Venue {e} Section {s} Row {r}",
                            SectionId = new Guid(0, 0, 1, 0, 0, 0, 0, (byte)e, (byte)s, 0, 0)
                        });
                    }
                    builder.Entity<Row>().HasData(rows);
                    sections.Add(new Section
                    {
                        Id = new Guid(0, 0, 1, 0, 0, 0, 0, (byte)e, (byte)s, 0, 0),
                        Name = $"Venue {e} Section {s}",
                        VenueId = new Guid(0, 0, 1, 0, 0, 0, 0, (byte)e, 0, 0, 0)
                    });
                }
                builder.Entity<Section>().HasData(sections);
                var venue = new Venue
                {
                    Id = new Guid(0, 0, 1, 0, 0, 0, 0, (byte)e, 0, 0, 0),
                    Capacity = 100,
                    Name = $"Venue {e}"
                };
                venues.Add(venue);
                events.Add(new Event
                {
                    Id = new Guid(0, 0, 1, 0, 0, 0, (byte)e, 0, 0, 0, 0),
                    Name = $"Event {e}",
                    VenueId = venue.Id
                });
                var ticketPurchaseSeats = new List<TicketPurchaseSeat>();
                var ticketPurchases = new List<TicketPurchase>();
                for (var t = 1; t <= 10; t++)
                {
                    var price = Math.Round((decimal)new Random().NextDouble() * 10, 2);
                    ticketPurchaseSeats.Add(new TicketPurchaseSeat
                    {
                        Id = new Guid(0, 0, 3, 0, 0, 0, 0, (byte)e, 1, 1, (byte)t),
                        EventSeatId = new Guid(0, 0, 2, 0, 0, 0, 0, (byte)e, 1, 1, (byte)t),
                        TicketPurchaseId = new Guid(0, 0, 4, 0, 0, 0, 0, (byte)e, 1, 1, (byte)t),
                        Subtotal = price
                    });
                    ticketPurchases.Add(new TicketPurchase
                    {
                        Id = new Guid(0, 0, 4, 0, 0, 0, 0, (byte)e, 1, 1, (byte)t),
                        PaymentMethod = "Cash",
                        PaymentAmount = price
                    });
                }
                var price2 = Math.Round((decimal)new Random().NextDouble() * 10, 2);
                ticketPurchaseSeats.Add(new TicketPurchaseSeat
                {
                    Id = new Guid(0, 0, 3, 0, 0, 0, 0, (byte)e, 1, 2, 1),
                    EventSeatId = new Guid(0, 0, 2, 0, 0, 0, 0, (byte)e, 1, 2, 1),
                    TicketPurchaseId = new Guid(0, 0, 4, 0, 0, 0, 0, (byte)e, 1, 2, 1),
                    Subtotal = price2
                });
                ticketPurchases.Add(new TicketPurchase
                {
                    Id = new Guid(0, 0, 4, 0, 0, 0, 0, (byte)e, 1, 2, 1),
                    PaymentMethod = "Cash",
                    PaymentAmount = price2
                });
                ticketPurchaseSeats.Add(new TicketPurchaseSeat
                {
                    Id = new Guid(0, 0, 3, 0, 0, 0, 0, (byte)e, 1, 2, 2),
                    EventSeatId = new Guid(0, 0, 2, 0, 0, 0, 0, (byte)e, 1, 2, 2),
                    TicketPurchaseId = new Guid(0, 0, 4, 0, 0, 0, 0, (byte)e, 1, 2, 2),
                    Subtotal = price2
                });
                ticketPurchases.Add(new TicketPurchase
                {
                    Id = new Guid(0, 0, 4, 0, 0, 0, 0, (byte)e, 1, 2, 2),
                    PaymentMethod = "Cash",
                    PaymentAmount = price2
                });
                builder.Entity<TicketPurchaseSeat>().HasData(ticketPurchaseSeats);
                builder.Entity<TicketPurchase>().HasData(ticketPurchases);
            }
            builder.Entity<Venue>().HasData(venues);
            builder.Entity<Event>().HasData(events);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
