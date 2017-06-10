using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportSystem.Contracts.Models;

namespace AirportSystem.Models
{
    public class Model : IModel, IBaseModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public int Seats { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
