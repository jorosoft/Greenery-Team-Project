using System.Collections.Generic;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Models
{
    public class Airline : IAirline
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Aircraft> Aircrafts { get; set; }
    }
}
