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
        public Seat Seat { get; set; }
        [Required]
        public Event Event { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
