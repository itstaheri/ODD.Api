using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ODD.Api.Application.Contract.Dtos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ODD.Api.Application.Contract.Dtos.User;
using ODD.Api.Application.Contract.Interfaces.Authentication;

namespace ODD.Api.Infrastructure.Utility.Interfaces.Authentication
{
    public class JwtAuthentication : IJwtAuthentication
    {
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _contextAccessor;

        public JwtAuthentication(IConfiguration config, IHttpContextAccessor contextAccessor)
        {
            _config = config;
            _contextAccessor = contextAccessor;
        }

        public TokenResultDto GenerateToken(UserInfoDto userInfo)
        {
            string jwtToken = "";
            Guid refreshToken;

            //create cliams for store useritem data
            var claims = new List<Claim>
            {
                new Claim("ID",userInfo.Id.ToString()),
            };

            string key = _config["JwtConfig:key"];
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenExpire = DateTime.Now.AddDays(1);

            var token = new JwtSecurityToken(
                issuer: _config["JwtConfig:issuer"],
                audience: _config["JwtConfig:audience"],
                notBefore: DateTime.Now,
                expires: tokenExpire,
                claims: claims,
                signingCredentials: credential
                );

            try
            {
                //Generate token and refreshToken
                jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                refreshToken = Guid.NewGuid();
                return new TokenResultDto
                {
                    RefreshToken = refreshToken.ToString(),
                    ExpireDate = tokenExpire,
                    TokenID = jwtToken
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);

            }

        }

        public long GetCurrentUserId()
        {
            return long.Parse(_contextAccessor.HttpContext.User.FindFirst("Id").Value);
        }
    }
}
