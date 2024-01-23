using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Infrastructure.Utility.CustomExceptions
{
    public class StatusCodeIsNotOk  : Exception
    {
        public StatusCodeIsNotOk(int statusCode) : base($"Error! StatusCode : {statusCode}")
        {
            
        }
    }
}
