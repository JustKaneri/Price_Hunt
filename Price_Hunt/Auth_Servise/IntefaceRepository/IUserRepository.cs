using Auth_Servise.Interface;
using Auth_Servise.Model;

namespace Auth_Servise.IntefaceRepository
{
    public interface IUserRepository<T>: ICreator<T>, IRecoil<T> where T : IDbModel
    {
        /// <summary>
        /// Проверка существует ли пользователь
        /// <param name="email">электронная почта</param>
        /// <returns>Пользователь с данной почтой, Null в случае отсутствия пользователя</returns>
        public Task<T> IsExist(string email);
    }
}
