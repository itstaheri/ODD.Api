using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Domain.Exceptions
{
    public class EmailIsInIncorrectFormatException : Exception
    {
        public EmailIsInIncorrectFormatException() : base("Email is in incorrect format!")
        {

        }
    }
}
