using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha.Service.Generator.Dtos
{
    public class CaptchaValidResponseDto
    {
        public string message { get; set; }
        public bool isValid { get; set; }
    }
}
