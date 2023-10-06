namespace Auth_Servise.Interface
{
    public interface ICreator<T> where T : IDbModel
    {
        public Task<T> CreateAsync(T entity);

        
    }
}
