using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Models
{
    [Serializable()]
    public class Manufacturer : IManufacturer
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [Index(IsUnique = true)]
        [XmlElement("name")]
        public string Name { get; set; }

        public virtual HashSet<Plane> Planes { get; set; }
    }
}
