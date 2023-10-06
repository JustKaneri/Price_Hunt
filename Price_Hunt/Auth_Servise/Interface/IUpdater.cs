namespace Auth_Servise.Interface
{
    public interface IUpdater <T> where T : IDbModel
    {
        public Task<T> UpdateAsync (T entity);
    }
}
