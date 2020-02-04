using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Model
{
    public class TicketPurchaseSeat
    {
        public Guid Id { get; set; }
        [Required]
        public EventSeat EventSeat { get; set; }
        [Column(TypeName = "money")]
        public decimal Subtotal { get; set; }
    }
}