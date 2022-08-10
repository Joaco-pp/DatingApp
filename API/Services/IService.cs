namespace API.Services
{
    public interface IService<T> where T: class
    {
        Task<T> GetAsync(int id);

        IEnumerable<T> GetAll(bool getDeleted = false);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity, int id);

        Task DeleteAsync(int id);
    }
}