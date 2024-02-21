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

        public static string GetRefreshTokenValue(int length)
        {
            const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz_!@#$%^&*()_-+=";

            Random random = new();

            return new(
                value: Enumerable
                    .Repeat(element: Chars, count: length)
                    .Select(selector: s => s[random.Next(maxValue: s.Length)])
                    .ToArray());
        }
    }
}
