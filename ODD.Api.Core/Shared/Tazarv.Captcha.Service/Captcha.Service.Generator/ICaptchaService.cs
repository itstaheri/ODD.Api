using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Captcha.Service.Generator.Dtos;

namespace Captcha.Service.Generator
{
    public interface ICaptchaService
    {
        CaptchaResponseDto GetCaptcha();
        CaptchaValidResponseDto CheckCaptchaValid(CheckCaptchaRequestDto captcha);
    }
    public class CaptchaService : ICaptchaService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;
        private int _limit;
        private string _limitTime;
        public CaptchaService(IMemoryCache memoryCache, IConfiguration configuration)
        {
            _memoryCache = memoryCache;
            _configuration = configuration;
            _limit = Convert.ToInt32(_configuration.GetSection("CaptchaConfig").GetSection("limit").Value);
            _limitTime = _configuration.GetSection("CaptchaConfig").GetSection("limitTime").Value;
        }

        public CaptchaValidResponseDto CheckCaptchaValid(CheckCaptchaRequestDto captcha)
        {
            DateTime limitDateTime = _memoryCache.Set("limitDateTime", DateTime.Now);

            var sessionCode = _memoryCache.Get("Code").ToString();
            var sessionId = _memoryCache.Get("Id").ToString();
            if (sessionId == captcha.id.ToString())
            {


                if (sessionCode == captcha.code.ToString())
                {
                    return new CaptchaValidResponseDto { isValid = true, message = "captcha is valid." };


                }
                else
                {
                    return new CaptchaValidResponseDto { isValid = false, message = "captcha code is invalid!" };

                }

            }
            else
            {
                return new CaptchaValidResponseDto { isValid = false, message = "sessionId is invalid!" };
            }
        }

        public CaptchaResponseDto GetCaptcha()
        {
            CaptchaTools captcha = new CaptchaTools();
            var result = captcha.GenerateCaptcha();
            _memoryCache.Set("Image", result.Image);
            _memoryCache.Set("Code", result.Code);
            _memoryCache.Set("Id", result.Id);
            _memoryCache.Set("rate", 0);
            return new CaptchaResponseDto
            {
                Image = result.Image,
                Id = result.Id.ToString()
            };
        }
    }
}
