namespace AirportSystem.Models.Contracts
{
    public interface IFlight
    {
        int Id { get; set; }

        int SourceAirportId { get; set; }

        int DestinationAirportId { get; set; }
    }
}
