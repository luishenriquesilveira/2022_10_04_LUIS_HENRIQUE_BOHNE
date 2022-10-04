using RateMyAnimal.Domain.Interfaces;
using RateMyAnimal.Domain.Responses;
using RateMyAnimal.Domain.Entities;
using Newtonsoft.Json;

namespace RateMyAnimal.Infrastructure.ExternalServices
{
    public class ShibeOnlineService : IRandomAnimalService
    {
        private readonly HttpClient _httpClient;
        private readonly ICdnShibeOnlineService _cdnShibeOnlineService;
        public ShibeOnlineService(HttpClient httpClient, ICdnShibeOnlineService cdnShibeOnlineService)
        {
            _cdnShibeOnlineService = cdnShibeOnlineService;

            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://shibe.online/");
        }

        public async Task<CommonResponse<Animal>> GetRandomAnimal()
        {
            var response = await _httpClient.GetAsync("api/shibes?urls=false");

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<string[]>(content);

                return await _cdnShibeOnlineService.GetImageFromCdn(result.First());
            }
            return CommonResponse<Animal>.Fail("Image not found.");
        }
    }
}
