using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Domain.Exceptions
{
    public class IdIsLessThanZeroException : Exception
    {
        public IdIsLessThanZeroException() : base("ID is less than 0!")
        {

        }
    }
}
