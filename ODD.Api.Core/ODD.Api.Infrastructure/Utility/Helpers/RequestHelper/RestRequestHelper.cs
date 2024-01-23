using Microsoft.Extensions.Logging;
using RestSharp;
using ODD.Api.Application.Contract.Dtos;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace ODD.Api.Infrastructure.Utility.Helpers.RequestHelper
{
    public  class RestRequestHelper : RequestHelper
    {
        private RestClient client;
        string BaseUrl = string.Empty;
        public RestRequestHelper(string baseUrl)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            BaseUrl = baseUrl;
            client = new RestClient(BaseUrl);

        }
        /// <summary>
        /// Send request to api target by GET method and return value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>  
        /// <param name="method"></param>
        /// <returns>return object and request result</returns>
        public override ResponseDto GETRequest(string url)
        {

            try
            {
                var request = new RestRequest(url, Method.Get);

                RestResponse response = client.Execute(request);

                return new ResponseDto
                {
                    StatusCode =  response.StatusCode,
                    ResponseJson = response.Content,
                    Message = response.ErrorMessage
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }

        }
        /// <summary>
        /// Send value by POST method to target api
        /// </summary>
        /// <param name="url"></param>
        /// <param name="Model"></param>
        /// <param name="method"></param>
        /// <param name="parameterType"></param>
        /// <returns>return request result</returns>
        public override ResponseDto POSTRequest(string url, object Model, ParameterType parameterType)
        {

            var restResponse = new RestResponse();
            var request = new RestRequest(url, Method.Post);
            try
            {

                request.AddHeader("Content-Type", "application/json");
                var serializeObject = JsonSerializer.Serialize(Model);

                request.AddParameter("application/json", serializeObject, parameterType);
                var response = client.Execute(request);

                return new ResponseDto
                {
                    StatusCode =  response.StatusCode,
                    ResponseJson = response.Content,
                    Message = response.ErrorMessage
                };
            }
            catch (Exception ex)
            {
                //use polly for retry request when we have problem in serverside
                //  restResponse = RestResponseWithPolicy(new RestClient(url), request);
                throw new Exception(ex.Message, ex.InnerException);
            }


        }
        /// <summary>
        /// Send async request to api target by GET method and return value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <returns>return object and request result</returns>
        public async override Task<ResponseDto> GETRequestAsync(string url,string token = null)
        {

            var request = new RestRequest(url);
            var restResponse = new RestResponse();
            try
            {
                request.AddHeader("Content-Type", "application/json");
                if (!string.IsNullOrEmpty(token))
                    request.AddHeader("Authorization", token);

                var response = await client.ExecuteAsync(request);
                // if (response.StatusCode != HttpStatusCode.OK) throw new StatusCodeIsNotOk( response.StatusCode);
              
                return new ResponseDto
                {
                    StatusCode =  response.StatusCode,
                    ResponseJson = response.Content,
                    Message = response.ErrorMessage

                };
            }
            catch (Exception ex)
            {
                //use polly for retry request when we have problem in serverside
                //  restResponse = RestResponseWithPolicy(new RestClient(url), request);
                throw new Exception(ex.Message, ex.InnerException);
            }

        }
        /// <summary>
        /// Send value by POST method to target api by async request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="Model"></param>
        /// <param name="method"></param>
        /// <param name="parameterType"></param>
        /// <returns>return request result</returns>
        public async override Task<ResponseDto> POSTRequestAsync(string url, object Model, ParameterType parameterType)
        {
            var restResponse = new RestResponse();
            var request = new RestRequest(url, Method.Post);
            try
            {

                request.AddHeader("Content-Type", "application/json");
                var serializeObject = JsonSerializer.Serialize(Model);
                request.AddParameter("application/json", serializeObject, parameterType);
                var response = await client.ExecuteAsync(request);

                return new ResponseDto
                {
                    StatusCode =  response.StatusCode,
                    ResponseJson = response.Content,
                    Message = response.ErrorMessage

                };
            }

            catch (Exception ex)
            {
                //use polly for retry request when we have problem in serverside
                //  restResponse = RestResponseWithPolicy(new RestClient(url), request);
                throw new Exception(ex.Message, ex.InnerException);
            }


        }
        public async override Task<ResponseDto> POSTRequestWithCancellationTokenAsync(string url, object Model, ParameterType parameterType, CancellationToken cancellation)
        {

            var restResponse = new RestResponse();
            var request = new RestRequest(url, Method.Post);
            try
            {


                request.AddHeader("Content-Type", "application/json");
                var serializeObject = JsonSerializer.Serialize(Model);
                request.AddParameter("application/json", serializeObject, parameterType);
                var response = await client.ExecuteAsync(request, cancellation);

                return new ResponseDto
                {
                    StatusCode =  response.StatusCode,
                    ResponseJson = response.Content,
                    Message = response.ErrorMessage

                };
            }

            catch (Exception ex)
            {
                //use polly for retry request when we have problem in serverside
                //  restResponse = RestResponseWithPolicy(new RestClient(url), request);
                throw new Exception(ex.Message, ex.InnerException);
            }


        }

        public async override Task<ResponseDto> GetRequestWithCancellationTokenAsync(string url, CancellationToken cancellation)
        {

            var request = new RestRequest(url, method: Method.Post);
            var restResponse = new RestResponse();

            try
            {
                //  request.AddHeader("Content-Type", "application/json");
                var response = await client.ExecuteAsync(request, cancellation);
                // if (response.StatusCode != HttpStatusCode.OK) throw new StatusCodeIsNotOk( response.StatusCode);

                return new ResponseDto
                {
                    StatusCode =  response.StatusCode,
                    ResponseJson = response.Content,
                    Message = response.ErrorMessage

                };
            }
            catch (Exception ex)
            {
                //use polly for retry request when we have problem in serverside
                //  restResponse = RestResponseWithPolicy(new RestClient(url), request);
                throw new Exception(ex.Message, ex.InnerException);
            }


        }

        //Use polly for retry circuitBreaker requests
        //Use polly for retry circuitBreaker requests
        //private RestResponse RestResponseWithPolicy(RestClient restClient, RestRequest restRequest)
        //{
        //    var retryPolicy = Policy
        //        .HandleResult<RestResponse>(x => !x.IsSuccessful)
        //        .WaitAndRetry(5, x => TimeSpan.FromSeconds(10), (iRestResponse, timeSpan, retryCount, context) =>
        //       {
        //           Console.WriteLine($"The request failed. HttpStatusCode={iRestResponse.Result.StatusCode}. Waiting {timeSpan} seconds before retry. Number attempt {retryCount}. Uri={iRestResponse.Result.ResponseUri}; RequestResponse={iRestResponse.Result.Content}");

        //       });

        //    var circuitBreakerPolicy = Policy
        //        .HandleResult<RestResponse>(x => x.StatusCode == HttpStatusCode.ServiceUnavailable)
        //        .CircuitBreaker(1, TimeSpan.FromSeconds(60), onBreak: (iRestResponse, timespan, context) =>
        //       {
        //           Console.WriteLine($"Circuit went into a fault state. Reason: {iRestResponse.Result.Content}");

        //       },
        //        onReset: (context) =>
        //       {
        //           Console.WriteLine($"Circuit left the fault state.");
        //       });

        //    return retryPolicy.Wrap(circuitBreakerPolicy).Execute(() => restClient.Execute(restRequest));
        //}



    }

}
