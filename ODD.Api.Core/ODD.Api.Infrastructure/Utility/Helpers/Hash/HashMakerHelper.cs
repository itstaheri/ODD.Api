using ODD.Api.Application.Interfaces.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Infrastructure.Utility.Helpers.Hash
{
    public class HashMakerHelper : ICryptography
    {
        public string sha512_hash(string value)
        {
            string salt = "@#TZ1";
            return ShaWithSalt(value, salt);
        }

        private static string ShaWithSalt(string value, string salt)
        {
            System.Security.Cryptography.SHA512Managed HashTool = new System.Security.Cryptography.SHA512Managed();
            Byte[] PasswordAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(value, salt));
            Byte[] EncryptedBytes = HashTool.ComputeHash(PasswordAsByte);
            HashTool.Clear();
            return Convert.ToBase64String(EncryptedBytes);
        }

    }

        
}

