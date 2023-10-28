using Auth_Servise.Dto;
using Auth_Servise.Model;

namespace Auth_Servise.IntefaceRepository
{
    public interface IAuthRepository
    {
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="user">пользователь</param>
        /// <returns></returns>
        public Task<Token> Regestry(UserRegestryDto user);

        /// <summary>
        /// Получить новый токен для сущ. пользователя
        /// </summary>
        /// <param name="email">электронная почта</param>
        /// <param name="password">пароль</param>
        /// <returns>Новый токен</returns>
        public Task<Token> CreateToken(string email,string password);

    }
}
