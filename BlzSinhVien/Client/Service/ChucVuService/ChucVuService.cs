using BlzSinhVien.Shared.Model;
using System.Net.Http.Json;
namespace BlzSinhVien.Client.Service.ChucVuService
{
    public class ChucVuService : IChucVuService
    {
        private readonly HttpClient _http;

        public ChucVuService(HttpClient http)
        {
            _http = http;
        }

        public List<BLChucVu> ChucVu { get; set; } = new List<BLChucVu>();

        public async Task Create(BLChucVu chucvu)
        {
            var result = await _http.PostAsJsonAsync<BLChucVu>("api/ChucVu", chucvu);
            var request = await result.Content.ReadFromJsonAsync<List<BLChucVu>>();
            if(request != null)
            {
                ChucVu = request;
            }
        }

        public async Task Delete(int id)
        {
            var result = await _http.DeleteAsync($"api/ChucVu/{id}");
            var request = await result.Content.ReadFromJsonAsync<List<BLChucVu>>();
            if (request != null)
                ChucVu = request;
        }

        public async Task GetChucVu()
        {
            var result = await _http.GetFromJsonAsync<List<BLChucVu>>("api/ChucVu");
            if (result != null)
            {
                ChucVu = result;
            }
        }

        public async Task<BLChucVu> GetId(int id)
        {
            var result = await _http.GetFromJsonAsync<BLChucVu>($"api/ChucVu/{id}");
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task Update(BLChucVu chucvu)
        {
            var result = await _http.PutAsJsonAsync<BLChucVu>($"api/ChucVu/{chucvu.Id}",chucvu);
            var request = await result.Content.ReadFromJsonAsync<List<BLChucVu>>();
            if (request != null)
            {
                ChucVu = request;
            }
        }
    }
}
