using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Model
{
    public class EventSeat
    {
        public Guid Id { get; set; }
        [Required]
        public virtual Seat Seat { get; set; }
        public Guid SeatId { get; set; }
        [Required]
        public virtual Event Event { get; set; }
        public Guid EventId { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
