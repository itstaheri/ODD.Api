using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Infrastructure.Utility.Helpers.RequestHelper
{
    public class CallServiceResponse
    {
        public CallServiceResponse(string content, HttpStatusCode statusCode,string message)
        {
            Content = content;
            StatusCode = statusCode;
            Message = message;
        }
        public CallServiceResponse()
        {

        }
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
