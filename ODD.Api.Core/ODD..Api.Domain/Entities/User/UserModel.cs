using ODD.Api.Domain.Value_Objects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Domain.Entities.User
{
    public class UserModel
    {
        public UserModel()
        {
        }

        public UserModel(string username, Email email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
            RegisterDate = DateTimeOffset.Now;
            Status = true;
        }

        public Id Id { get;private set; }
        public string Username { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public DateTimeOffset RegisterDate { get; private set; }
        public bool Status { get; private set; }
        public UserProfileModel UserProfile { get; private set; } = new();

        //set user status active
        public void ActiveUser() => Status = true;
        //set user status deactive
        public void DeActiveUser() => Status = false;

        public ResetPasswordResult ResetPassword(string newPassword)
        {
            if (Password.Equals(newPassword))
                return new ResetPasswordResult { Message = "The new password must not be the same as the current password!",Success = false };

            //reset password
            Password = newPassword;
            return new ResetPasswordResult { Message = "The password has been successfully updated.", Success = true };


        }

    }
    public record ResetPasswordResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
