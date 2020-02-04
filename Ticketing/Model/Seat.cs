using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Model
{
    public class Seat
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}