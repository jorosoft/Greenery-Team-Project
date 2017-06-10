namespace AirportSystem.Contracts.Models
{
    public interface IAirport
    {
        int Id { get; set; }

        string Code { get; set; }

        string Name { get; set; }
    }
}
