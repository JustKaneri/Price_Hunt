using Auth_Servise.Dto;
using Auth_Servise.Model;

namespace Auth_Servise.IntefaceRepository
{
    public interface IRegestryRepository
    {
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="user">пользователь</param>
        /// <returns></returns>
        public Task<Token> Regestry(UserRegestryDto user);

    }
}
