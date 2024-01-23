using ODD.Api.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ODD.Api.Domain.Value_Objects.Common
{
    public class Email : ValueObject
    {
        string forbiddenPattern = @"[!@#$%^&*()-+=/';,]";
        public string Value { get; set; }

        public Email(string email)
        {
            if (!email.Contains("@"))
                throw new EmailIsInIncorrectFormatException();
            if (email.Length > 60)
                throw new Exception("email lenght is bigger then 60 charecter!");

            int index = email.IndexOf("@");
            string emailAddressPostfix = email.Substring(0, index);

            if (Regex.IsMatch(emailAddressPostfix, forbiddenPattern))
                throw new EmailIsInIncorrectFormatException();


        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
