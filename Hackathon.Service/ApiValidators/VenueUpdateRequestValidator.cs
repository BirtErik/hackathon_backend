using FluentValidation;
using Hackathon.Service.ApiRequests;

namespace Hackathon.Service.ApiValidators;

public class VenueUpdateRequestValidator : AbstractValidator<VenueUpdateRequest>
{
    public VenueUpdateRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.Rooms).NotEmpty().WithMessage("At least one room is required");

        // TODO: Implement Venue Room Validator
        //RuleForEach(x => x.Rooms).SetValidator(new VenueRoomValidator());
    }
}
