using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportSystem.Contracts.Models;

namespace AirportSystem.Models
{
    public class Manufacturer : IManufacturer, IBaseModel
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
