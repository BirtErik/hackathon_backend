namespace Hackathon.Service.Common.Exceptions;

public class BadRequestAxHttpException
{
    public BadRequestAxHttpException(Exception? outerException = null, string? errorMessage = "Failed request validation", string? moreInfo = null)
    {

    }
}
