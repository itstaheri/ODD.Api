using ODD.Api.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Domain.Value_Objects.Common
{
    public class Id : ValueObject
    {

        public long Value { get; set; }
        public Id(long id)
        {
            if (id <= 0)
                throw new IdIsLessThanZeroException();
            Value = id;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
