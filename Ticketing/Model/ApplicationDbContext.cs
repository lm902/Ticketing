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
            var events = new List<object>();
            var venues = new List<Venue>();
            for (var e = 1; e <= 5; e++)
            {
                var sections = new List<object>();
                for (var s = 1; s <= 2; s++)
                {
                    var rows = new List<object>();
                    for (var r = 1; r <= 5; r++)
                    {
                        var seats = new List<object>();
                        for (var t = 1; t <= 10; t++)
                        {
                            seats.Add(new
                            {
                                Id = new Guid(0, 0, 1, 0, 0, 0, 0, (byte)e, (byte)s, (byte)r, (byte)t),
                                Name = $"Venue {e} Section {s} Row {r} Seat {t}",
                                Price = Math.Round((decimal)new Random().NextDouble() * 10, 2),
                                RowId = new Guid(0, 0, 1, 0, 0, 0, 0, (byte)e, (byte)s, (byte)r, 0)
                            });
                        }
                        builder.Entity<Seat>().HasData(seats);
                        rows.Add(new
                        {
                            Id = new Guid(0, 0, 1, 0, 0, 0, 0, (byte)e, (byte)s, (byte)r, 0),
                            Name = $"Venue {e} Section {s} Row {r}",
                            SectionId = new Guid(0, 0, 1, 0, 0, 0, 0, (byte)e, (byte)s, 0, 0)
                        });
                    }
                    builder.Entity<Row>().HasData(rows);
                    sections.Add(new
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
                events.Add(new
                {
                    Id = new Guid(0, 0, 1, 0, 0, 0, (byte)e, 0, 0, 0, 0),
                    Name = $"Event {e}",
                    VenueId = venue.Id
                });
            }
            builder.Entity<Venue>().HasData(venues);
            builder.Entity<Event>().HasData(events);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
