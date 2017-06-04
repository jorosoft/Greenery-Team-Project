using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Models
{
    [Serializable()]
    public class Plane : IPlane
    {
        public int Id { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        public int ModelId { get; set; }

        [Required]
        public int AirlineId { get; set; }

        [XmlElement("manufacturer")]
        public virtual Manufacturer Manufacturers { get; set; }

        [XmlElement("model")]
        public virtual Model Models { get; set; }

        [XmlElement("airline")]
        public virtual Airline Airlines { get; set; }

        [XmlElement("planePassport")]
        public virtual PlanePassport PlanePassport { get; set; }

        public virtual HashSet<Flight> Flights { get; set; }
    }
}
