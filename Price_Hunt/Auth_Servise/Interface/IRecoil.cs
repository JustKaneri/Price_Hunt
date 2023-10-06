namespace Auth_Servise.Interface
{
    public interface IRecoil<T> where T : IDbModel
    {
        public Task<T> RecoilAsync(T entity);
    }
}
