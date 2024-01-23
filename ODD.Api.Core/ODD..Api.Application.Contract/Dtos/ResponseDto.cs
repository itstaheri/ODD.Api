using System.Net;

namespace ODD.Api.Application.Contract.Dtos
{
    public class ResponseDto
    {
        public object ResponseJson { get; set; } = string.Empty;
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
    public class ResponseDto<T>
    {
        public T ResponseJson { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
