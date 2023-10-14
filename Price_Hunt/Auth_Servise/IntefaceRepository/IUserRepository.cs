using Auth_Servise.Interface;
using Auth_Servise.Model;

namespace Auth_Servise.IntefaceRepository
{
    public interface IUserRepository<T>: ICreator<T>, IRecoil<T> where T : IDbModel
    {
        /// <summary>
        /// Проверка существует ли пользователь с указаной почтой
        /// <param name="email">электронная почта</param>
        /// <returns>Пользователь с данной почтой, Null в случае отсутствия пользователя</returns>
        public Task<T> IsExist(string email);

        /// <summary>
        /// Идентификация пользователя
        /// </summary>
        /// <param name="email">электронная почта</param>
        /// <param name="password">пароль</param>
        /// <returns>Пользователь</returns>
        public Task<T> IdentificationUser(string email,string password);
    }
}
