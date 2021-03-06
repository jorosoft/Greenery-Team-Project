﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportSystem.Contracts.Models;

namespace AirportSystem.Models
{
    public class Airport : IAirport, IBaseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required field!")]
        [MinLength(3)]
        [MaxLength(5)]
        [Index(IsUnique = true)]        
        public string Code { get; set; }

        [Required(ErrorMessage = "Required field!")]
        [MinLength(3)]
        [MaxLength(35)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
