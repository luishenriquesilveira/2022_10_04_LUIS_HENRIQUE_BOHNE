using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Domain.Responses;

namespace RateMyAnimal.Domain.Interfaces
{
    public interface ICdnShibeOnlineService
    {
        Task<CommonResponse<Animal>> GetImageFromCdn(string id);
    }
}
