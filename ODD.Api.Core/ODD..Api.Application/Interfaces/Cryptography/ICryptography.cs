using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Application.Interfaces.Cryptography
{
    public interface ICryptography
    {
        string sha512_hash(string value);
    }
}
