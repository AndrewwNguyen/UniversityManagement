using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UniversityManagement.API.Exceptions
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            context.Result = new OkObjectResult(new { err = true, errdDesc = ex.Message });
        }

    }
}
