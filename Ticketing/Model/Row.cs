using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ticketing.Model
{
    public class Row
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Seat> Seats { get; set; }
        [Required]
        public Guid SectionId { get; set; }
    }
}