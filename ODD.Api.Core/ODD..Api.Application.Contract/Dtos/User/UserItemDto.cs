using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Application.Contract.Dtos.User
{
    namespace TBS.WebAPI.Core.Business.Dtos
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class DomainControllerUser
        {
            public int ID { get; set; }
            public string DomainControllerUserName { get; set; }
            public int UserID { get; set; }
            public int DomainControllerId { get; set; }
            public bool IsNew { get; set; }
            public bool IsDirty { get; set; }
            public bool IsSelected { get; set; }
            public bool IsDeleted { get; set; }
            public string ObjectId { get; set; }
            public bool PropagatePropertyNotifications { get; set; }
            public bool PropertyEventsSuspended { get; set; }
        }

        public class MemberShip
        {
            public int ID { get; set; }
            public int UserId { get; set; }
            public string Password { get; set; }
            public string OriginalPassword_ { get; set; }
            public string CellPhone { get; set; }
            public string RepeatedPassword { get; set; }
            public int PasswordFormat { get; set; }
            public string PasswordSalt { get; set; }
            public string Email { get; set; }
            public string PasswordQuestion { get; set; }
            public string PasswordAnswer { get; set; }
            public bool IsLoged { get; set; }
            public DateTime CreateDate { get; set; }
            public string CreateDatePersian { get; set; }
            public DateTime LastLoginDate { get; set; }
            public string LastLoginDatePersian { get; set; }
            public DateTime LastLogoutDate { get; set; }
            public string LastLogoutPersian { get; set; }
            public DateTime LastPasswordChangedDate { get; set; }
            public string LastPasswordChangedPersian { get; set; }
            public bool IsLockedOut { get; set; }
            public int FailedPasswordAttemptCount { get; set; }
            public int FailedPasswordAnswerAttemptCount { get; set; }
            public string Comment { get; set; }
            public bool IsSHA { get; set; }
            public int SessionCount { get; set; }
            public bool IsValid { get; set; }
            public bool IsNew { get; set; }
            public bool IsDirty { get; set; }
            public bool IsSelected { get; set; }
            public bool IsDeleted { get; set; }
            public string ObjectId { get; set; }
            public bool PropagatePropertyNotifications { get; set; }
            public bool PropertyEventsSuspended { get; set; }
        }

        public class Profile
        {
            public int ID { get; set; }
            public int UserId { get; set; }
            public string FullName { get; set; }
            public string Pictuer { get; set; }
            public string PictuerValue { get; set; }
            public string PersonnelCode { get; set; }
            public bool Enabled { get; set; }
            public object UnitName { get; set; }
            public bool IsValid { get; set; }
            public bool IsNew { get; set; }
            public bool IsDirty { get; set; }
            public bool IsSelected { get; set; }
            public bool IsDeleted { get; set; }
            public string ObjectId { get; set; }
            public bool PropagatePropertyNotifications { get; set; }
            public bool PropertyEventsSuspended { get; set; }
        }

        public class UserItemDto
        {
            public string TokenID { get; set; }
            public string UniqueIdentifier { get; set; }
            public int ID { get; set; }
            public string UserName { get; set; }
            public string UserNameFullName { get; set; }
            public string DomainControllerUserName { get; set; }
            public string FullName { get; set; }
            public int DomainControllerId { get; set; }
            public UserCallcenter UserCallcenter { get; set; }
            public Profile Profile { get; set; }
            public string PersonnelCode { get; set; }
            public string ProfileFullName { get; set; }
            public MemberShip MemberShip { get; set; }
            public DomainControllerUser DomainControllerUser { get; set; }
            public List<int> RoleItems { get; set; }
            public List<int> GroupItems { get; set; }
            public bool IsValid { get; set; }
            public string Name { get; set; }
            public List<string> Roles { get; set; }
            public bool IsNew { get; set; }
            public bool IsDirty { get; set; }
            public bool IsSelected { get; set; }
            public bool IsDeleted { get; set; }
            public string ObjectId { get; set; }
            public bool PropagatePropertyNotifications { get; set; }
            public bool PropertyEventsSuspended { get; set; }
        }

        public class UserCallcenter
        {
            public string UniqueIdentifier { get; set; }
            public int ID { get; set; }
            public int UserId { get; set; }
            public string AgentId { get; set; }
            public string Password { get; set; }
            public string CurrentGroupId { get; set; }
            public string CurrentCallcenterId { get; set; }
            public bool Isautologin { get; set; }
            public string WorkstationId { get; set; }
            public int LoginMode { get; set; }
            public bool IsNew { get; set; }
            public bool IsDirty { get; set; }
            public bool IsSelected { get; set; }
            public bool IsDeleted { get; set; }
            public string ObjectId { get; set; }
            public bool PropagatePropertyNotifications { get; set; }
            public bool PropertyEventsSuspended { get; set; }
        }


    }

}
