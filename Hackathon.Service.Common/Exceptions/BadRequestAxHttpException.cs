namespace Hackathon.Service.Common.Exceptions;

public class BadRequestAxHttpException : BaseAxHttpException
{
    public BadRequestAxHttpException(Exception? outerException = null, string? errorMessage = "Failed request validation", string? moreInfo = null) 
        : base(ApiErrorCodes.FAILED_REQUEST_VALIDATION, 400, outerException, errorMessage, moreInfo)
    {

    }
}
