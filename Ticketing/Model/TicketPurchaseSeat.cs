using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Model
{
    public class TicketPurchaseSeat
    {
        public Guid Id { get; set; }
        [Required]
        public virtual EventSeat EventSeat { get; set; }
        public Guid EventSeatId { get; set; }
        [Column(TypeName = "money")]
        public decimal Subtotal { get; set; }
    }
}