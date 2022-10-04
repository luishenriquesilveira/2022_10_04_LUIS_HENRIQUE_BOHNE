namespace RateMyAnimal.Domain.Interfaces
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
