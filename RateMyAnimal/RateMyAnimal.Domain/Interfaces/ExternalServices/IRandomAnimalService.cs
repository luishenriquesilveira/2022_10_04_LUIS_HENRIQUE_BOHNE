using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Domain.Responses;

namespace RateMyAnimal.Domain.Interfaces
{
    public interface IRandomAnimalService
    {
        Task<CommonResponse<Animal>> GetRandomAnimal();
    }
}
