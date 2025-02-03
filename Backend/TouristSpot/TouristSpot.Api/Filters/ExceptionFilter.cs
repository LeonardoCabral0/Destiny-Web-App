using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using TouristSpot.Contracts;
using TouristSpot.Domain.Exception;

namespace TouristSpot.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BaseException)
            {
                HandleException(context);
            }
            else
            {
                HandleUnknowException(context);
            }
        }

        private void HandleException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException)
            {
                var exception = context.Exception as ErrorOnValidationException;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseError(exception.ErrorsMessages));
            }
        }

        private void HandleUnknowException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new ObjectResult(new ResponseError(ResourceMessageException.UNKNOW_ERROR));
            }
        }
    }
}
