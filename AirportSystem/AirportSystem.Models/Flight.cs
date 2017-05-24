﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Models
{
    public class Flight : IFlight
    {
        public int Id { get; set; }

        [Required]        
        public int SourceAirportId { get; set; }

        [Required]
        public int DestinationAirportId { get; set; }  

        public virtual Airport SourceAirport { get; set; }

        public virtual Airport DestinationAirport { get; set; }
    }
}
