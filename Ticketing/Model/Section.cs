﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ticketing.Model
{
    public class Section
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual IEnumerable<Row> Rows { get; set; }
        [Required]
        public Guid VenueId { get; set; }
    }
}
