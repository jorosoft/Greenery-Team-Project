using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Models
{
    [Serializable()]
    public class Model : IModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [Index(IsUnique = true)]
        [XmlElement("name")]
        public string Name { get; set; }
        
        [XmlElement("seats")]
        public int Seats { get; set; }

        public virtual HashSet<Plane> Planes { get; set; }
    }
}
