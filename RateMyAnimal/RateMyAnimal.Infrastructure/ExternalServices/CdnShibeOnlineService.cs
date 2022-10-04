using RateMyAnimal.Domain.Entities;
using RateMyAnimal.Domain.Interfaces;
using RateMyAnimal.Domain.Responses;
using RateMyAnimal.Infrastructure.Utils;
using System.Drawing;
using System.Drawing.Imaging;

namespace RateMyAnimal.Infrastructure.ExternalServices
{
    public class CdnShibeOnlineService : ICdnShibeOnlineService
    {
        private readonly HttpClient _httpClient;
        public CdnShibeOnlineService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://cdn.shibe.online/");
        }

        public async Task<CommonResponse<Animal>> GetImageFromCdn(string id)
        {
            var response = await _httpClient.GetAsync($"shibes/{id}.jpg");

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
