namespace AirportSystem.Models.Contracts
{
    interface IAircraft
    {
        int Id { get; set; }

        int ManufacturerId { get; set; }

        int ModelId { get; set; }

        int OwnerAirlineId { get; set; }
    }
}
