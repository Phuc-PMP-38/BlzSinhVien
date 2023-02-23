using BlzSinhVien.Shared.Model;
using System.Net.Http.Json;

namespace BlzSinhVien.Client.Service.ImageService
{
    public class ImageService : IImageService
    {
        private readonly HttpClient _http;

        public ImageService(HttpClient http)
        {
            _http = http;
        }

        public List<BLImage> ListImage { get; set; } = new List<BLImage>();

        public async Task Update(MultipartFormDataContent context)
        {
            var response = await _http.PostAsync($"/api/Image", context);
            var newUploadResults = await response.Content.ReadFromJsonAsync<List<BLImage>>();
            if(newUploadResults!= null)
            {
                ListImage = newUploadResults;
            }
        }
    }
}
