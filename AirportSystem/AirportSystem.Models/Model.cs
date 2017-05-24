using System.Collections.Generic;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Models
{
    public class Model : IModel
    {
        public int Id { get; set; }        

        public string Name { get; set; }

        public int Seats { get; set; }

        public virtual ICollection<Aircraft> Aircrafts { get; set; }
    }
}
