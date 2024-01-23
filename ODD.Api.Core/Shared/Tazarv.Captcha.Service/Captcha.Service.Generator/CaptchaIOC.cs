using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha.Service.Generator
{
    public static class CaptchaIOC
    {
        public static void AddCaptcha(this IServiceCollection services)
        {
            services.AddTransient<ICaptchaService, CaptchaService>();
            services.AddSingleton<CaptchaAttribute>();

        }
    }
}
