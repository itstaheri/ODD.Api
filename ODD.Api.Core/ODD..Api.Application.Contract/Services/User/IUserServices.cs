using ODD.Api.Application.Contract.Dtos.User;
using ODD.Api.Application.Contract.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Application.Contract.Services.User
{
    public interface IUserService
    {
        /// <summary>
        /// for create new user
        /// </summary>
        /// <param name="signUp"></param>
        /// <returns></returns>
        Task<ResultDto<long>> SignUp(SignUpDto signUp);
        /// <summary>
        /// for login users
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        ResultDto<UserInfoDto> Login(LoginDto login);

        /// <summary>
        /// for active a user with userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
         Task<ResultDto> ActiveUserBy(long userId);
        /// <summary>
        /// for deactive a user with userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ResultDto> DeActiveUserBy(long userId);
    }
}
