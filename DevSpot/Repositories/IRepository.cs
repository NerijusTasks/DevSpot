namespace DevSpot.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsinc(int id);
        Task AddAsync(T entity);
        Task Updateasync(T entity);
        Task DeleteAsync(int id);   
    }
}
