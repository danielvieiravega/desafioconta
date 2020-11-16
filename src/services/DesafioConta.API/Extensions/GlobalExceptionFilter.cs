using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DesafioConta.API.Extensions
{
    public class GlobalExceptionFilter : IExceptionFilter, IActionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;
        private object model;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            try { model = context.ActionArguments.Values.FirstOrDefault(); } catch { }
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception.Message != null)
            {
                context.ModelState.AddModelError("Errors", context.Exception.Message);
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
            else
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            try { LogError(context); } catch { _logger.LogError("Error while logging error.", context.Exception); }
        }

        private void LogError(ExceptionContext context)
        {
            if (model != null)
            {
                _logger.LogWarning("model", model);
            }
            _logger.LogWarning(context.Exception, "Exception");
            if (context.Exception?.InnerException != null)
            {
                _logger.LogWarning(context.Exception?.InnerException, "InnerException");
            }

            _logger.LogWarning($"An error has occurred on DesafioConta.API");
        }
    }
}
