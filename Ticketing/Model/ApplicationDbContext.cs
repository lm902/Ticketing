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
            var events = new List<Event>();
            for (var e = 0; e < 5; e++)
            {
                var sections = new List<Section>();
                for (var s = 0; s < 2; s++)
                {
                    var rows = new List<Row>();
                    for (var r = 0; r < 5; r++)
                    {
                        var seats = new List<Seat>();
                        for (var t = 0; t < 10; t++)
                        {
                            seats.Add(new Seat
                            {
                                Name = $"Seat {t}",
                                Price = Math.Round((decimal)new Random().NextDouble() * 10, 2)
                            });
                        }
                        rows.Add(new Row
                        {
                            Name = $"Row {r}",
                            Seats = seats
                        });
                    }
                    sections.Add(new Section
                    {
                        Name = $"Section {s}",
                        Rows = rows
                    });
                }
                events.Add(new Event
                {
                    Name = $"Event {e}",
                    Venue = new Venue
                    {
                        Capacity = 100,
                        Name = $"Venue {e}",
                        Sections = sections
                    }
                });
            }
            builder.Entity<Event>().HasData(events);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
