using FluentValidation;
using Hackathon.Service.ApiRequests;

namespace Hackathon.Service.ApiValidators;

public class CustodianCreateRequestValidator : AbstractValidator<CustodianCreateRequest>
{
    public CustodianCreateRequestValidator()
    {
        // TODO: Add email validator
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
        // TODO: Add password validator
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
        // TODO: Add venue ID validator
        RuleFor(x => x.VenueId).NotEmpty().WithMessage("Venue ID is required");
    }
}