using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Nobat.Backend.API.Middleware
{
    public class ValidationExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not ValidationException validationException)
            {
                return false;
            }

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "خطای اعتبارسنجی",
                Detail = "درخواست شما شامل خطاهای زیر است.",
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1"
            };

            problemDetails.Extensions.Add("errors", validationException.Errors);

            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
