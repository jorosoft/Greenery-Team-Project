using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Models
{
    public class Model : IModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        
        public int Seats { get; set; }

        public virtual ICollection<Aircraft> Aircrafts { get; set; }
    }
}
