using BlzSinhVien.Shared.Model;
using BlzSinhVien.Shared.Model.User;
using System.Net.Http.Json;
namespace BlzSinhVien.Client.Service.GiaoVienService
{
    public class GiaoVienService : IGiaoVienService
    {
        private readonly HttpClient _http;

        public GiaoVienService(HttpClient http)
        {
            _http = http;
        }

        public List<BLGiaoVien> GiaoVien { get; set; } = new List<BLGiaoVien>();

        public async Task Create(UserRegisterRequestGV giaovien)
        {
            var result = await _http.PostAsJsonAsync($"api/User/CreateGV",giaovien);
            var request = await result.Content.ReadFromJsonAsync<List<BLGiaoVien>>();
            if (request != null)
                GiaoVien = request;
        }

        public async Task Delete(int id)
        {
            var result = await _http.DeleteAsync($"api/GiaoVien/{id}");
            var request = await result.Content.ReadFromJsonAsync<List<BLGiaoVien>>();
            if (request != null)
                GiaoVien = request;
        }

        public async Task GetGiaoVien()
        {
            var result = await _http.GetFromJsonAsync<List<BLGiaoVien>>($"api/GiaoVien");
            if (result != null)
                GiaoVien = result;
        }

        public async Task<BLGiaoVien?> GetId(int id)
        {
            var result = await _http.GetFromJsonAsync<BLGiaoVien>($"api/GiaoVien/{id}");
            return result;
        }

        public async Task Update(BLGiaoVien giaovien)
        {

            var result = await _http.PutAsJsonAsync($"api/GiaoVien/{giaovien.Id}", giaovien);
            var request = await result.Content.ReadFromJsonAsync<List<BLGiaoVien>>();
            if (request != null)
            {
                GiaoVien = request;
            }
        }
    }
}
