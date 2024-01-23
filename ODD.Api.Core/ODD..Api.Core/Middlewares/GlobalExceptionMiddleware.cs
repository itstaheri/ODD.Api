using ODD.Api.Application.Contract.Dtos;
using ODD.Api.EndPointDto;
using LoggerService.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Newtonsoft.Json;
using System.Net;

namespace ODD.Api.Core.Middlewares
{
    public class GlobalExceptionMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public GlobalExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(ex, httpContext);
            }
        }

        private async Task HandleException(Exception ex, HttpContext httpContext)
        {


            _loggerService.Log(LoggerService.Model.LogServiceLevel.Error, $"error message : {ex.Message} | inner exception : {ex.InnerException}");

                httpContext.Response.StatusCode = 500;
            await httpContext.Response.WriteAsJsonAsync(new ResponseDto
            {
                Message = BaseResultMessage.Internal_Server_Error,
                StatusCode = HttpStatusCode.InternalServerError,
                ResponseJson = null
            }) ;
            
           


        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandleMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }

    }
}
