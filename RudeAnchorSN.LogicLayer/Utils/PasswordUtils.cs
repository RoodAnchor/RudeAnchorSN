using System.Text;
using System.Security.Cryptography;

namespace RudeAnchorSN.LogicLayer.Utils
{
    public class PasswordUtils
    {
        public static string GetPasswordHash(string? password)
        {
            if (string.IsNullOrEmpty(password)) 
                throw new ArgumentNullException("password");

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                string hashString = string.Empty;

                foreach (Byte b in hash)
                {
                    hashString += string.Format("{0:x2}", b);
                }

                return hashString;
            }
        }
    }
}
