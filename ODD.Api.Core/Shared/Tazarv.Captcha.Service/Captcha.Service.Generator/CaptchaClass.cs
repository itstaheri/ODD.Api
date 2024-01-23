using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Captcha.Service.Generator.Dtos;

namespace Captcha.Service.Generator
{
    public class CaptchaTools
    {
        public CaptchaValueDto GenerateCaptcha()
        {
            var codeToImage = new GenerateImage();
            string randomCode = RandomCodeGenerator.Generate5CharecterCode();
            CaptchaValueDto captchaValueDto = new CaptchaValueDto();
            try
            {
                var image  = codeToImage.CodeToCaptchaImage(randomCode);
                return new CaptchaValueDto(image, randomCode,Guid.NewGuid());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
      
    }
}
