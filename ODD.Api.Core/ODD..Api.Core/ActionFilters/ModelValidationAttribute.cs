using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ODD.Api.ActionFilters
{
    public class ModelValidationAttribute : ActionFilterAttribute
    {
        private readonly ILogger<ActionLogAttribute> _logger;

        public ModelValidationAttribute(ILogger<ActionLogAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                _logger.LogInformation($"class :{nameof(ModelValidationAttribute)} | Datetime : {DateTime.Now} | Message : model {context.ModelState} is invalid!");
                context.Result = new BadRequestObjectResult(context.ModelState);


            }
        }
    }
}
