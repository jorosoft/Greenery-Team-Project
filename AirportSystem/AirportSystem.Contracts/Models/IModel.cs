namespace AirportSystem.Contracts.Models
{
    public interface IModel
    {
        int Id { get; set; }

        string Name { get; set; }

        int Seats { get; set; }
    }
}
