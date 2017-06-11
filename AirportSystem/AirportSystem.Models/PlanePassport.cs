using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportSystem.Contracts.Models;

namespace AirportSystem.Models
{
    public class PlanePassport : IPlanePassport
    {
        [Key, ForeignKey("Plane")]
        public int PlaneId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [Index(IsUnique = true)]
        public string RegistrationNumber { get; set; }

        [Required]
        public int YearOfRegistration { get; set; }
        
        public string State { get; set; }

        public virtual Plane Plane { get; set; }
    }
}
