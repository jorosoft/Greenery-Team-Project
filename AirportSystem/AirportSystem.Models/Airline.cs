using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Models
{    
    public class Airline : IAirline
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        [Index(IsUnique = true)]        
        public string Name { get; set; }

        public virtual ICollection<Plane> Planes { get; set; }

        public virtual ICollection<Terminal> Terminals { get; set; }
    }
}
