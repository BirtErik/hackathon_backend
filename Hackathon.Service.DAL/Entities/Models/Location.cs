namespace Hackathon.Service.DAL.Entities.Models;

public class Location
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public required string FullAddress { get; set; }
}