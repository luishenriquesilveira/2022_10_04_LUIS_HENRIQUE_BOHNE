using RateMyAnimal.Domain.Interfaces;
using RateMyAnimal.Domain.Responses;
using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Infrastructure.Utils;

namespace RateMyAnimal.Infrastructure.ExternalServices
{
    public class PlaceDogService : IRandomAnimalService
    {
        private readonly HttpClient _httpClient;
        public PlaceDogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://place.dog/");
        }

        public async Task<CommonResponse<Animal>> GetRandomAnimal()
        {
            var response = await _httpClient.GetAsync("300/200");

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
