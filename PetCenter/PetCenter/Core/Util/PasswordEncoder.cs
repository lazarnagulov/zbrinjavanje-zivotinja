using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Core.Util
{
    public static class PasswordEncoder
    {
        public static string Encode(string password)
        {
            var sha = SHA256.Create();
            var asBytes = Encoding.UTF8.GetBytes(password);
            var hashed = sha.ComputeHash(asBytes);

            return Convert.ToBase64String(hashed);
        }

    }
}
