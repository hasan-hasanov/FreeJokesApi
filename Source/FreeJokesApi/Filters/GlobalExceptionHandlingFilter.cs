using Microsoft.AspNetCore.Mvc.Filters;

namespace FreeJokesApi.Filters
{
    public class GlobalExceptionHandlingFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
        }
    }
}
