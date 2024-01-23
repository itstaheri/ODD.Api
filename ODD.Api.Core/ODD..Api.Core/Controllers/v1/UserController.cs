using ODD.Api.ActionFilters;
using ODD.Api.Application.Contract.Dtos;
using ODD.Api.Application.Contract.Dtos.User;
using ODD.Api.Application.Contract.Dtos.User.TBS.WebAPI.Core.Business.Dtos;
using ODD.Api.Application.Contract.Interfaces.Authentication;
using ODD.Api.Application.Contract.Services.User;
using ODD.Api.EndPointDto;
using LoggerService.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration.UserSecrets;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using Captcha.Service.Generator;

namespace ODD.Api.Core.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(ActionLogAttribute))]
    [ServiceFilter(typeof(ModelValidationAttribute))]
    [EnableCors("APICORS")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILoggerService _loggerService;
        private readonly IMemoryCache _memoryCache;
        private readonly IJwtAuthentication _jwt;
        public UserController(IUserService userService, ILoggerService loggerService, IMemoryCache memoryCache, IJwtAuthentication jwt)
        {
            _userService = userService;
            _loggerService = loggerService;
            _memoryCache = memoryCache;
            _jwt = jwt;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUp)
        {
            try
            {
                var result = await _userService.SignUp(signUp);
                return Ok(new ResponseDto { Message = result.Message, ResponseJson = result.Value, StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                _loggerService.Log(LoggerService.Model.LogServiceLevel.Error, ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseDto
                {
                    Message = BaseResultMessage.Internal_Server_Error,
                    ResponseJson = "",
                    StatusCode = HttpStatusCode.InternalServerError
                });

            }
        }

        [ServiceFilter(typeof(CaptchaAttribute))]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            ResultDto<UserInfoDto> result = new ResultDto<UserInfoDto>();
            UserInfoDto userInfo = new UserInfoDto();
            var response = new ResponseDto();
            try
            {
                userInfo = _memoryCache.Get<UserInfoDto>("Login");
                if (userInfo == null)
                {
                    try
                    {
                        result = _userService.Login(login);
                        if (!result.IsSuccess)
                        {
                            response = new ResponseDto
                            {
                                Message = response.Message,
                                ResponseJson = null,
                                StatusCode = HttpStatusCode.InternalServerError
                            };
                            return StatusCode((int)HttpStatusCode.InternalServerError, response);
                        }
                        else
                        {
                            userInfo = result.Value;
                            _memoryCache.Set("Login", userInfo, TimeSpan.FromHours(12));

                        }

                    }
                    catch (Exception ex)
                    {
                        return new JsonResult(new ResponseDto
                        {
                            Message = BaseResultMessage.Internal_Server_Error,
                            ResponseJson = "",
                            StatusCode = HttpStatusCode.InternalServerError,
                        });
                    }
                    var Token = _jwt.GenerateToken(userInfo); //generate jwt token

                    response = new ResponseDto { Message = result.Message, ResponseJson = Token, StatusCode = HttpStatusCode.OK };


                    return Ok(response);


                }
                else
                {
                    var Token = _jwt.GenerateToken(userInfo); //generate jwt token

                    response = new ResponseDto { Message = result.Message, ResponseJson = Token, StatusCode = HttpStatusCode.OK };
                    return Ok(response);
                }


            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseDto
                {
                    Message = BaseResultMessage.Internal_Server_Error,
                    ResponseJson = "",
                    StatusCode = HttpStatusCode.InternalServerError,
                });
            }

        }
    }
}
