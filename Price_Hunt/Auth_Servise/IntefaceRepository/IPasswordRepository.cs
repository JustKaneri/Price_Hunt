namespace Auth_Servise.IntefaceRepository
{
    public interface IPasswordRepository
    {
        public string ComputeHash(string password, string salt);

        public bool Verifications(string hash, string password, string salt);
    }
}
