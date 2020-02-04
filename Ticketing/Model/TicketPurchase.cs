using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Model
{
    public class TicketPurchase
    {
        public Guid Id { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Column(TypeName = "money")]
        public decimal PaymentAmount { get; set; }
        public string ConfirmationCode { get; set; }
        public virtual List<TicketPurchaseSeat> TicketPurchaseSeats { get; set; }
    }
}
