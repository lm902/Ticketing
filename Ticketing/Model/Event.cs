﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketing.Model
{
    public class Event
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Venue Venue { get; set; }
    }
}