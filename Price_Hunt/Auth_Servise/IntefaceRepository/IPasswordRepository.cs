namespace Auth_Servise.IntefaceRepository
{
    public interface IPasswordRepository
    {
        /// <summary>
        /// Хэширование паролья
        /// </summary>
        /// <param name="password">пароль</param>
        /// <param name="salt">ключ</param>
        /// <returns>Хэш</returns>
        public string ComputeHash(string password, string salt);

        /// <summary>
        /// Сравнение паролей
        /// </summary>
        /// <param name="hash">хэш пароля</param>
        /// <param name="password">пароль</param>
        /// <param name="salt">ключ для хэширования</param>
        /// <returns>True если совпали, False если не совпали</returns>
        public bool Verifications(string hash, string password, string salt);
    }
}
