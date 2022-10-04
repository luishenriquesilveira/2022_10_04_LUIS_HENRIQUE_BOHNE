using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Domain.Responses;

namespace RateMyAnimal.Domain.Interfaces
{
    public interface IAnimalService
    {
        Task<CommonResponse<Animal>> GetById(int id);
        Task<CommonResponse<IEnumerable<Animal>>> GetAll(int? recordsNumber);
        Task<CommonResponse<IEnumerable<Animal>>> GetAllByIdCategory(int id);
        Task<CommonResponse<Animal>> Add(Animal animal);
        Task<CommonResponse<Animal>> Update(Animal animal);
        Task<CommonResponse<Animal>> Delete(int id);
        Task<CommonResponse<Animal>> GetRandomAnimalImage();
    }
}
