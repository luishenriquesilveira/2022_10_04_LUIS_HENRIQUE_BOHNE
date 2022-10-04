using RateMyAnimal.Domain.Interfaces;
using RateMyAnimal.Domain.Responses;
using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Infrastructure.Utils;

namespace RateMyAnimal.Infrastructure.ExternalServices
{
    public class CatAsService : IRandomAnimalService
    {
        private readonly HttpClient _httpClient;
        public CatAsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://cataas.com/");
        }

        public async Task<CommonResponse<Animal>> GetRandomAnimal()
        {
            var response = await _httpClient.GetAsync("cat");

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStreamAsync().Result;

                byte[] imgBytes = ImageUtils.StreamToByteArray(content);

                return CommonResponse<Animal>.Success(new Animal(imgBytes));
            }
            else
            {
                return CommonResponse<Animal>.Fail("Image not found.");
            }
        }
    }
}
