using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.Model
{
    public class LogModel
    {
        public string Type { get; set; } = "WebService";
        public string Message { get; set; }
        public string LogLevel { get; set; }
        public string DateTime { get; set; }
    }
}
