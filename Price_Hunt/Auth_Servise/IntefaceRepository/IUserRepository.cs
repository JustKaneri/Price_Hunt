using Auth_Servise.Interface;
using Auth_Servise.Model;

namespace Auth_Servise.IntefaceRepository
{
    public interface IUserRepository<T>: ICreator<T>, IRecoil<T> where T : IDbModel
    {
        public Task<T> IsExist(T enity);
    }
}
