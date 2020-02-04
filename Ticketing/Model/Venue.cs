using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ticketing.Model
{
    public class Venue
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Capacity { get; set; }
        public virtual IEnumerable<Section> Sections { get; set; }
    }
}
