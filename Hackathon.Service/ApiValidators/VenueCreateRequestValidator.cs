using FluentValidation;
using Hackathon.Service.ApiRequests;

namespace Hackathon.Service.ApiValidators;

public class VenueCreateRequestValidator : AbstractValidator<VenueCreateRequest>
{
    public VenueCreateRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        // TODO: Implement Venue Location Validator for each property
        RuleFor(x => x.Location).NotNull().WithMessage("Location is required");

        // TODO: Implement Venue Room Validator
        //RuleForEach(x => x.Rooms).SetValidator(new VenueRoomValidator());
    }
}