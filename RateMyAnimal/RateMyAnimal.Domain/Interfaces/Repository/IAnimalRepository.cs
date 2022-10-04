using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Domain.Interfaces;

namespace RateMyAnimal.Domain.Interfaces
{
    public interface IAnimalRepository : IBaseRepository<Animal>
    {
        Task<Animal> GetByIdInclude(int id);
        Task<IEnumerable<Animal>> GetAllInclude(int? recordsNumber);
        Task<IEnumerable<Animal>> GetAllByIdCategory(int id);
    }
}
