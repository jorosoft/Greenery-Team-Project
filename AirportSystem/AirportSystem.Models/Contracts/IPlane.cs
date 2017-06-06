﻿namespace AirportSystem.Models.Contracts
{
    interface IPlane
    {
        int Id { get; set; }

        int ManufacturerId { get; set; }
        
        int AirlineId { get; set; }
    }
}
