using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace RapidPay.Controllers
{
    [ApiController] 
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HandlerExceptionController : ControllerBase
    {

        private readonly ILogger<HandlerExceptionController> _logger;
        public HandlerExceptionController(ILogger<HandlerExceptionController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Route("/prod-handler-exception")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            LogError(context);

            return Problem();
        }

        [Route("/dev-handler-exception")]
        public IActionResult ErrorLocalDevelopment([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            LogError(context);

            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);
        }

        private void LogError(IExceptionHandlerFeature context)
        {
            _logger.LogInformation($"Error Message is {context.Error.Message}. {(context.Error.InnerException != null ? $"Inner message is { context.Error.InnerException.Message }." : string.Empty)}");

            _logger.LogInformation($"Error stack trace is {context.Error.StackTrace}");
        }
    }
}
