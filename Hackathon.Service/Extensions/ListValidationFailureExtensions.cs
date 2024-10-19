using FluentValidation.Results;

namespace Hackathon.Service.Extensions;

public static class ListValidationFailureExtensions
{
    public static string ToSimpleMessageString(this List<ValidationFailure> failureItems)
    {
        List<string> failureDescription = new List<string>();
        foreach (ValidationFailure failure in failureItems)
        {
            failureDescription.Add(new string($"{failure.PropertyName} - {failure.ErrorMessage}".Trim()));
        }

        return string.Join(", ", failureDescription);
    }
}