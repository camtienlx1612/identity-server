using System.Security.Cryptography;

namespace Identity.Helper
{
    public class Tokens
    {
        public static string GenerateToken()
        {
            byte[] tokenBytes = RandomNumberGenerator.GetBytes(32);
            return Convert.ToBase64String(tokenBytes)
                          .Replace("+", "-")
                          .Replace("/", "_")
                          .TrimEnd('=');
                           
        }

        public static string HashToken(string rawtoken)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            byte[] tokenBytes = System.Text.Encoding.UTF8.GetBytes(rawtoken);
            byte[] hashBytes = sha256.ComputeHash(tokenBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
