using Dapper;
using ODD.Api.Application.AbstractFactory;
using ODD.Api.Application.Contract.Dtos;
using ODD.Api.Application.Contract.Dtos.User;
using ODD.Api.Application.Contract.Dtos.User.TBS.WebAPI.Core.Business.Dtos;
using ODD.Api.Application.Contract.Services.User;
using ODD.Api.Application.Interfaces.Cryptography;
using ODD.Api.Application.Interfaces.WebServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODD.Api.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using ODD.Api.Domain.Entities.User;

namespace ODD.Api.Application.Services.User
{

    public class UserService : IUserService
    {
        private readonly IApplicationSSMSEfCoreContext _applicationSSMSEfCore;
        private readonly ICryptography _cryptography;
        public UserService(IApplicationSSMSEfCoreContext applicationSSMSEfCore, ICryptography cryptography)
        {
            _applicationSSMSEfCore = applicationSSMSEfCore;
            _cryptography = cryptography;
        }

        public ResultDto<UserInfoDto> Login(LoginDto login)
        {
            UserInfoDto userInfo = new UserInfoDto();
            try
            {
                var user = _applicationSSMSEfCore.Tbl_User.SingleOrDefault(x => x.Username == login.Username);

                if (user is null) //check user exist by username
                    return new ResultDto<UserInfoDto>(new UserInfoDto(), "User not exist!", false);
                if (!user.Password.Equals(_cryptography.sha512_hash(login.Password))) //check user password is match
                    return new ResultDto<UserInfoDto>(new UserInfoDto(), "Username or password is wrong!", false);

                userInfo = new UserInfoDto
                {
                    Id = user.Id.Value,
                    Email = user.Email.Value,
                    Username = user.Username,
                    UserStatus = user.Status

                };

                return new ResultDto<UserInfoDto>(userInfo, "login success.", true);


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<ResultDto<long>> SignUp(SignUpDto signUp)
        {

            try
            {
                var userExist = _applicationSSMSEfCore.Tbl_User.Any(x => x.Username == signUp.Username || x.Email.Value == signUp.Email);
                if (userExist is false)
                {
                    var userModel = new UserModel(signUp.Username, new Domain.Value_Objects.Common.Email(signUp.Email), _cryptography.sha512_hash(signUp.Password));

                    try
                    {
                        var userEntity = _applicationSSMSEfCore.Tbl_User.Add(userModel);
                        _applicationSSMSEfCore.SaveChanges();

                        return new ResultDto<long>(userEntity.Entity.Id.Value, "Signup success.", true);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception($"error on insert user to database with error message : {ex.Message} | innerException : {ex.InnerException}");
                    }


                }
                else
                {
                    return new ResultDto<long>(new long(), "user is exist with this username or email!", false);

                }



            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }

        }

        public async Task<ResultDto> ActiveUserBy(long userId)
        {
            try
            {
                var user = _applicationSSMSEfCore.Tbl_User.SingleOrDefault(x => x.Id.Value == userId);

                if (user is not null)
                {
                    user.ActiveUser();
                    await _applicationSSMSEfCore.SaveChangesAsync();
                    return new ResultDto("user is actived",true);
                }
                else
                {
                    return new ResultDto("user not exist!", false);

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);

            }
        }
        public async Task<ResultDto> DeActiveUserBy(long userId)
        {
            try
            {
                var user = _applicationSSMSEfCore.Tbl_User.SingleOrDefault(x => x.Id.Value == userId);

                if (user is not null)
                {
                    user.DeActiveUser();
                    await _applicationSSMSEfCore.SaveChangesAsync();
                    return new ResultDto("user is Deactived", true);
                }
                else
                {
                    return new ResultDto("user not exist!", false);

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);

            }
        }
    }
}
