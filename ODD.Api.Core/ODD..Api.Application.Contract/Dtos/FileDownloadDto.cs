using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Application.Contract.Dtos
{
    public class FileDownloadDto
    {
        public int ID { get; set; }
        public string FileContentType { get; set; }
        public int FileSize { get; set; }
        public string FileMD5 { get; set; }
        public string FileCreationDate { get; set; }
        public string FileCreationDatePersian { get; set; }
        public string DatePersian { get; set; }
        public string FileOriginalName { get; set; }
        public string FileContent { get; set; }
    }
}
