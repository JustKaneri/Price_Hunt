using Auth_Servise.Model;

namespace Auth_Servise.IntefaceRepository
{
    public interface ITokenGenerate
    {
        public string GenerateToken(User user);
    }
}
