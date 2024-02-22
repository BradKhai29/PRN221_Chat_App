using System.Security.Cryptography;
using System.Text;

namespace Helpers
{
    public class JwtTokenHelper
    {
        public static byte[] Encrypt(string key)
        {
            var encryptedKey = new HMACSHA256(
                key: Encoding.UTF8.GetBytes(key)).Key;

            return encryptedKey;
        }
    }
}
