namespace Hackathon.Service.Common.Exceptions;

public class NotFoundAxHttpException: BaseAxHttpException
{
    public NotFoundAxHttpException(string errorCode, Exception? outerException = null, string? errorMessage = ApiErrorCodes.CONTENT_RESOURCE_NOT_FOUND, string? moreInfo = null)

        : base(errorCode, 404, outerException, errorMessage, moreInfo) { }
}
