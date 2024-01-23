using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Infrastructure.Utility.Helpers.JsonReader.Exceptions
{
    public class JsonIsEmptyException : Exception
    {
        public JsonIsEmptyException() : base("json is empty!")
        {

        }
    }
}
