using FluentValidation;
using Hackathon.Service.ApiRequests;

namespace Hackathon.Service.ApiValidators;

public class TenantCreateRequestValidator : AbstractValidator<TenantCreateRequest>
{
    public TenantCreateRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
    }
}