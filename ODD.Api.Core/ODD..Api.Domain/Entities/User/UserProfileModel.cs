using ODD.Api.Domain.Value_Objects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Domain.Entities.User
{
    public class UserProfileModel
    {
        public UserProfileModel()
        {
        }

        public UserProfileModel(string firstname, string lastname, string biography, Id userId)
        {
            Firstname = firstname;
            Lastname = lastname;
            Biography = biography;
            UserId = userId;
        }

        public Id Id { get;private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Biography { get; private set; }
        public Id UserId { get; private set; }
        public UserModel User { get; private set; } = new();


    }
}
