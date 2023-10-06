using Auth_Servise.IntefaceRepository;
using System.Security.Cryptography;
using System.Text;

namespace Auth_Servise.Repository
{
    public class PasswordRepository : IPasswordRepository
    {
        public string ComputeHash(string password, string salt)
        {
            byte[] bytesToHash = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

            var byteResult = new Rfc2898DeriveBytes(bytesToHash, saltBytes, 10000);

            return Convert.ToBase64String(byteResult.GetBytes(24));
        }

        public bool Verifications(string hash, string password, string salt)
        {
            string confirmPassword = ComputeHash(password, salt);

            return confirmPassword == hash;
        }
    }
}
