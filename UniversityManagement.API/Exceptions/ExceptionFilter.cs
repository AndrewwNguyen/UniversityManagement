using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UniversityManagement.API.Exceptions
{
    public class CustomExceptionAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public override void OnException(ExceptionContext ex)
        {
            var controllerActionDescriptor = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)ex.ActionDescriptor);

            _logger.LogError("API: " + controllerActionDescriptor.AttributeRouteInfo.Template + "\r\n"
                    + ex.Exception.Message + "\r\n"
                    + ex.Exception.ToString());

            //assigning custom response
            ex.Result = JsonResultDto();

            ex.HttpContext.Response.StatusCode = 400;
        }


        // override the OnException async Method 
        public override async Task OnExceptionAsync(ExceptionContext ex)
        {
            var controllerActionDescriptor = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)ex.ActionDescriptor);

            _logger.LogError("API: " + controllerActionDescriptor.AttributeRouteInfo.Template + "\r\n"
                    + ex.Exception.Message + "\r\n"
                    + ex.Exception.ToString());

            await Task.FromResult(0);

            //assigning custom response
            ex.Result = JsonResultDto();

            ex.HttpContext.Response.StatusCode = 400;
        }

        // returning custom Json response
        private JsonResult JsonResultDto()
        {
            return new JsonResult(
                new
                {
                    ErrorMessage = "Internal error occurred.",
                    HasError = true,
                    ResponseCode = 400
                });

        }
    }
}
