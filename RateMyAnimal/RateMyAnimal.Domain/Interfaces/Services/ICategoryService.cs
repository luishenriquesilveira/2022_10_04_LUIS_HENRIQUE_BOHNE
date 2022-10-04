using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Domain.Responses;

namespace RateMyAnimal.Domain.Interfaces
{
    public interface ICategoryService
    {
        Task<CommonResponse<Category>> GetById(int id);
        Task<CommonResponse<IEnumerable<Category>>> GetAll();
        Task<CommonResponse<IEnumerable<Category>>> GetAllInclude(int? recordsNumber);
        Task<CommonResponse<Category>> Add(Category category);
        Task<CommonResponse<Category>> Update(Category category);
        Task<CommonResponse<Category>> Delete(int id);
    }
}
