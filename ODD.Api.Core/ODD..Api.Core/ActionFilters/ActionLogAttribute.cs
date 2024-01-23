using LoggerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http;
using System.Text;

namespace ODD.Api.ActionFilters
{
    public class ActionLogAttribute : ActionFilterAttribute
    {
        private readonly ILoggerService _loggerService;

        public ActionLogAttribute(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string controllerName = context.RouteData.Values["controller"].ToString(); //get current controller name
            string actionName = context.RouteData.Values["action"].ToString(); //get current action name
            string ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString(); //get caller ip
            string requestBody = string.Empty;
           
            //log
            _loggerService.Log(LoggerService.Model.LogServiceLevel.Information, $"Starting call method Post data on controller : {controllerName} | action : {actionName} | CallerAddress : {ipAddress} | Date : {DateTime.Now}");
            _loggerService.Log(LoggerService.Model.LogServiceLevel.Information, $"requestBody : {requestBody}");

        }       

    }
}
