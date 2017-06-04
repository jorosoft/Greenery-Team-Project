using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Models
{
    [Serializable()]
    public class PlanePassport :IPlanePassport
    {
        [Key, ForeignKey("Plane")]
        public int PlaneId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [Index(IsUnique = true)]
        [XmlElement("registrationNumber")]
        public string RegistrationNumber { get; set; }

        [Required]
        [XmlElement("yearOfRegistration")]
        public int YearOfRegistration { get; set; }

        [XmlElement("state")]
        public string State { get; set; }

        public virtual Plane Plane { get; set; }
    }
}
