namespace Hackathon.Service.ApiRequests;

public class ReservationRequestCreateRequest
{
    public Guid VenueId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string City { get; set; }

    public string StreetAddress { get; set; }

    public string Oib { get; set; }

    public string Phone { get; set; }

    public string BankName { get; set; }

    public string Iban { get; set; }

    public string Purpose { get; set; }

    public DateTimeOffset StartDate { get; set; }

    public DateTimeOffset EndDate { get; set; }

    public string Email { get; set; }
}
