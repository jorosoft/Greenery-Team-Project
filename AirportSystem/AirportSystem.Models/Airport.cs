using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Models
{
    [Serializable()]
    public class Airport : IAirport
    {    
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(5)]
        [Index(IsUnique = true)]
        [XmlElement("code")]
        public string Code { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(35)]
        [Index(IsUnique = true)]
        [XmlElement("name")]
        public string Name { get; set; }

        public virtual HashSet<Flight> Flights { get; set; }
    }
}
