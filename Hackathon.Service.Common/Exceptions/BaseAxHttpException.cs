namespace Hackathon.Service.Common.Exceptions;

public class BaseAxHttpException : Exception
{
    public string? ErrorMessage { get; }
    public string? MoreInfo { get; }
    public string? OuterErrorMessage { get; }
    public int StatusCode { get; }
    public string ErrorCode { get; set; } = null!;


    public BaseAxHttpException(string errorCode, int statusCode, Exception? outerException = null, string? errorMessage = null, string? moreInfo = null) 
        : base(errorMessage, outerException)
    {
        ErrorMessage = errorMessage;
        OuterErrorMessage = outerException?.Message;
        MoreInfo = moreInfo;
        StatusCode = statusCode;
        ErrorCode = string.IsNullOrEmpty(errorCode) ? null : errorCode;
    }
}
