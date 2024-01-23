using ODD.Api.Application.Contract.Dtos;
using ODD.Api.Application.Contract.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Application.Contract.Interfaces.Authentication
{
    public interface IJwtAuthentication
    {
        TokenResultDto GenerateToken(UserInfoDto userInfo);
        long GetCurrentUserId();
    }
}
