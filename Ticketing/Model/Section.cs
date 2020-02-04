using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ticketing.Model
{
    public class Section
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Row> Rows { get; set; }
    }
}
