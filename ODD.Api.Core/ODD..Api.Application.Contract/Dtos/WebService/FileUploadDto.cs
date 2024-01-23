using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Application.Contract.Dtos.WebService

{
    public record FileUploadDto
    {
        public string fileType { get; set; }
        public string FileName { get; set; }
        public string Base64fileContent { get; set; }
    }
}
