using Auth_Servise.IntefaceRepository;
using Auth_Servise.Model;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;

namespace Auth_Servise.Repository
{
    public class TokenGenerate : ITokenGenerate
    {
        public string GenerateToken(User user)
        {
            byte[] byteToHash = Encoding.UTF8.GetBytes(user.Name +"_" + user.Id);

            byte[] saltBytes = Encoding.UTF8.GetBytes(user.Salt);

            var byteResult = new Rfc2898DeriveBytes(byteToHash, saltBytes, 10000);

            return Convert.ToBase64String(byteResult.GetBytes(24)) + Guid.NewGuid().ToString();

        }
    }
}
