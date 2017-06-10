using AirportSystem.Contracts.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportSystem.Models
{
    public class Manufacturer : IManufacturer
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Plane> Planes { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
