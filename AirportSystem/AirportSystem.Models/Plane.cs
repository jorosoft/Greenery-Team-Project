using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportSystem.Contracts.Models;

namespace AirportSystem.Models
{
    public class Plane : IPlane, IBaseModel
    {
        public int Id { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        public int AirlineId { get; set; }

        [NotMapped]
        public IPlanePassport PlanePass { get; set; }

        public virtual Manufacturer Manufacturers { get; set; }        
              
        public virtual Airline Airlines { get; set; }
        
        public virtual PlanePassport PlanePassport { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
