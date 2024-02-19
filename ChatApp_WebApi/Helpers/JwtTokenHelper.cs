using System.Security.Cryptography;
using System.Text;

namespace Helpers
{
    public class JwtTokenHelper
    {
        public static byte[] GetEncryptedKey(string privateKey)
        {
            var encryptedKey = new HMACSHA256(
                key: Encoding.UTF8.GetBytes(privateKey)).Key;

            return encryptedKey;
        }
    }
}
