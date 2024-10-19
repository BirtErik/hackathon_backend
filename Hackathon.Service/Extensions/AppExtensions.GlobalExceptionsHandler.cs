using Hackathon.Service.ApiResults;
using Hackathon.Service.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Hackathon.Service.Extensions;

public static partial class AppExtensions
{
    public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                IExceptionHandlerFeature? contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    if (contextFeature.Error is BaseAxHttpException axException)
                    {
                        await WriteToResponse(context, axException);
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.Response.WriteAsync(new ErrorDetailsResult
                        {
                            StatusCode = (int)HttpStatusCode.InternalServerError,
                            ErrorMessage = "Internal Server Error.",
                            MoreInfo = "Something went wrong. Please try again later or contact our support team."
                        }.ToString());

                        throw contextFeature.Error;
                    }
                }
            });
        });
    }

    private static async Task WriteToResponse(HttpContext context, BaseAxHttpException axException)
    {
        context.Response.StatusCode = axException.StatusCode;
        await context.Response.WriteAsync(new ErrorDetailsResult
        {
            ErrorCode = axException.ErrorCode,
            StatusCode = axException.StatusCode,
            ErrorMessage = axException.ErrorMessage!,
            MoreInfo = axException.MoreInfo,
        }.ToString());
    }
}