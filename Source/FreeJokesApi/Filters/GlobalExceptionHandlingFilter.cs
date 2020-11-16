using Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace FreeJokesApi.Filters
{
    public class GlobalExceptionHandlingFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is BadRequestException)
            {
                JsonResult result = new JsonResult(new { Errors = context.Exception.Message });

                context.Result = result;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                JsonResult result = new JsonResult(new { Errors = "Something went wrong!" });

                context.Result = result;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            base.OnException(context);
        }
    }
}
