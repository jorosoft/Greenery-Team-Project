namespace AirportSystem.Contracts.Models
{
    interface IPlane
    {
        int Id { get; set; }

        int ManufacturerId { get; set; }
        
        int AirlineId { get; set; }
    }
}
