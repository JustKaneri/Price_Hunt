using Auth_Servise.Interface;

namespace Auth_Servise.IntefaceRepository
{
    public interface ITokeRepository<T>: ICreator<T>, IRecoil<T> where T : IDbModel
    {
        public Task<bool> IsActived(string token);
        public Task<string> DeactivationAsync(T entity);
    }
}
