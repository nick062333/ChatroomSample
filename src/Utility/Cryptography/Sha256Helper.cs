using System.Security.Cryptography;
using System.Text;

namespace Utility.Cryptography
{
    public static class Sha256Helper
    {
        public static string Encrypt(string source)
        {
            using SHA256 mySHA256 = SHA256.Create();
            byte[] hashValue = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(source));
            return BitConverter.ToString(hashValue).Replace("-", "").ToLower();
        }
    }
}
