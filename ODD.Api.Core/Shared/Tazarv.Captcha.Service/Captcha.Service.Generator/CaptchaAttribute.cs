using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Nancy;
using Nancy.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Captcha.Service.Generator.Dtos;

namespace Captcha.Service.Generator
{
    public class CaptchaAttribute : ActionFilterAttribute
    {
        private readonly IMemoryCache _memoryCache;

        private readonly ICaptchaService _captchaService;
        public CaptchaAttribute(IMemoryCache memoryCache,ICaptchaService captchaService)
        {
            _captchaService = captchaService;
            _memoryCache= memoryCache;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var captchaHeaderJson = context.HttpContext.Request.Headers["Captcha"];
            var code =_memoryCache.Get("Id");
           
            if (captchaHeaderJson.Count==0 || captchaHeaderJson[0] is null)
            {
                context.Result = new BadRequestObjectResult(new { ResponseJson = "", Message = "Captcha is requierd!", StatusCode = 400 });

            }
            else
            {
                var captcha = JsonConvert.DeserializeObject<CheckCaptchaRequestDto>(captchaHeaderJson);

                try
                {
                    if (code is not null)
                    {
                        var result = _captchaService.CheckCaptchaValid(captcha);
                        if (result.isValid) { }
                        else
                        {

                            context.Result = new OkObjectResult(new { ResponseJson = new { result.isValid }, Message = result.message, StatusCode = 400 });

                        }

                    }
                    else
                    {

                        context.Result = new BadRequestObjectResult(new { ResponseJson = "", Message = "Please request captcha first", StatusCode = 400 });

                    }


                }
                catch (Exception ex)
                {
                    context.HttpContext.Response.StatusCode = 500;
                    context.Result = new BadRequestObjectResult(new { ResponseJson = "", Message = "Problem!", StatusCode = 400 });



                }
            }
        }

       
    }
}
