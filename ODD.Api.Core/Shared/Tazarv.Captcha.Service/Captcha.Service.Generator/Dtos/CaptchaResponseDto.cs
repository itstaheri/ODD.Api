using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha.Service.Generator.Dtos
{
    public class CaptchaResponseDto
    {
        public string Image { get; set; }
        public string Id { get; set; }
    }
}
