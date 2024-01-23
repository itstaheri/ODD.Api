using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha.Service.Generator.Dtos
{
    public struct CaptchaValueDto
    {
        public CaptchaValueDto(string image, string code, Guid id)
        {
            Image = image;
            Code = code;
            Id = id;
        }

        public string Image { get; set; }
        public string Code { get; set; }
        public Guid Id { get; set; }
    }
}
