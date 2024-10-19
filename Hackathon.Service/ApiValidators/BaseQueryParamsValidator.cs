using FluentValidation;
using Hackathon.Service.ApiQueryParams;
using Hackathon.Service.Models.Constants;

namespace Hackathon.Service.ApiValidators;
public class BaseQueryParamsValidator : AbstractValidator<BaseQueryParams>
{
    public BaseQueryParamsValidator()
    {
        RuleFor(x => x.Page).GreaterThanOrEqualTo(0).WithMessage("Page must not be 0 or negative.").LessThanOrEqualTo(ApiConstants.Pagination.MaxPageSize)
            .WithMessage($"Page must not be greater than {ApiConstants.Pagination.MaxPageSize}.");

        RuleFor(x => x.Take).GreaterThanOrEqualTo(0).WithMessage($"Take must not be 0 or negative");

    }
}
