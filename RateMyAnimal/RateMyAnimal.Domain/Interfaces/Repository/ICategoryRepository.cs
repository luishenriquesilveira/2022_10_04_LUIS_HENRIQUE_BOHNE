using RateMyAnimal.Domain.Entities;

namespace RateMyAnimal.Domain.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category> GetByIdInclude(int id);
        Task<IEnumerable<Category>> GetAllInclude(int? recordsNumber);
    }
}
