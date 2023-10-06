using Auth_Servise.Interface;

namespace Auth_Servise.IntefaceRepository
{
    public interface ITokeRepository<T>: ICreator<T>, IRecoil<T> where T : IDbModel
    {
        /// <summary>
        /// Проверка действителен ли токен
        /// </summary>
        /// <param name="token">токен</param>
        /// <returns>True если активен, False если не активен</returns>
        public Task<bool> IsActived(string token);

        /// <summary>
        /// Деактивация токена
        /// </summary>
        /// <param name="token">токен</param>
        /// <returns>Объект с токеном</returns>
        public Task<T> DeactivationAsync(string token);
    }
}
