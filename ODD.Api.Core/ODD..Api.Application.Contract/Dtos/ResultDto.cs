using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Application.Contract.Dtos
{
    public record ResultDto<T>
    {
        public ResultDto()
        {

        }
        public ResultDto(T value,string message, bool isSuccess)
        {
            Message = message;
            IsSuccess = isSuccess;
            Value = value;
        }

        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
    }
    public record ResultDto
    {
        public ResultDto(string message, bool isSuccess)
        {
            Message = message;
            IsSuccess = isSuccess;
        }

        public string Message { get;  }
        public bool IsSuccess { get; }
    }
}
