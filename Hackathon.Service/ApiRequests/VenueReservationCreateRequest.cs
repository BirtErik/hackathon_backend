namespace Hackathon.Service.ApiRequests
{
    public class VenueReservationCreateRequest
    {
        public Guid VenueId { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public DateTimeOffset StartDate { get; set; }
        
        public DateTimeOffset EndDate { get; set; }
        
        public string Description { get; set; }

        public string Email { get; set; }

    }
}
