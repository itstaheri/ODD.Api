using RestSharp;
using ODD.Api.Application.Contract.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Infrastructure.Utility.Helpers.RequestHelper
{
    public abstract class RequestHelper
    {
        public abstract ResponseDto GETRequest(string url);
        public abstract Task<ResponseDto> GETRequestAsync(string url,string token = null);
        public abstract ResponseDto POSTRequest(string url, object Model, ParameterType parameterType);
        public abstract Task<ResponseDto> POSTRequestAsync(string url, object Model, ParameterType parameterType);
        public abstract Task<ResponseDto> POSTRequestWithCancellationTokenAsync(string url, object Model, ParameterType parameterType, CancellationToken cancellation);
        public abstract Task<ResponseDto> GetRequestWithCancellationTokenAsync(string url, CancellationToken cancellation);
    }
}
