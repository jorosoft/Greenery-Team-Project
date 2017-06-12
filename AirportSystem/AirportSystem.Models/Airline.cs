using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportSystem.Contracts.Models;

namespace AirportSystem.Models
{
    public class Airline : IAirline, IBaseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required field!")]
        [MinLength(3)]
        [MaxLength(25)]
        [Index(IsUnique = true)]        
        public string Name { get; set; }

        public virtual ICollection<Plane> Planes { get; set; }

        public virtual ICollection<Terminal> Terminals { get; set; }
    }
}
