using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha.Service.Generator.Dtos
{
    public class CheckCaptchaRequestDto
    {
        public string id { get; set; }
        public string code { get; set; }
    }
}
