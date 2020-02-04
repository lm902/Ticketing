using Microsoft.EntityFrameworkCore;

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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
