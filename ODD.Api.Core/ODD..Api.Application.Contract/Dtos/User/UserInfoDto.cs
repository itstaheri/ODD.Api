using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Application.Contract.Dtos.User
{
    public class UserInfoDto
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool UserStatus { get; set; }
    }
}
