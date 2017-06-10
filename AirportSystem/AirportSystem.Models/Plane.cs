using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirportSystem.Models
{
    public class Plane : IPlane
    {
        public int Id { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        public int AirlineId { get; set; }
        
        public virtual Manufacturer Manufacturers { get; set; }        
              
        public virtual Airline Airlines { get; set; }
        
        public virtual PlanePassport PlanePassport { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
