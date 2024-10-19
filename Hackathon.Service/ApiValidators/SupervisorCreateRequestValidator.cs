using FluentValidation;
using Hackathon.Service.ApiRequests;

namespace Hackathon.Service.ApiValidators;

public class SupervisorCreateRequestValidator : AbstractValidator<SupervisorCreateRequest>
{
    public SupervisorCreateRequestValidator()
    {
        // TODO: Add email validator
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
        // TODO: Add password validator
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
        // TODO: Add tenant ID validator
        RuleFor(x => x.TenantId).NotEmpty().WithMessage("Tenant ID is required");
    }
}