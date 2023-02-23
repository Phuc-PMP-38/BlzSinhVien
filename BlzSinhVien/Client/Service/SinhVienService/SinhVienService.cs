using BlzSinhVien.Shared.Model;
using BlzSinhVien.Shared.Model.User;
using System.Net.Http.Json;

namespace BlzSinhVien.Client.Service.SinhVienService
{
    public class SinhVienService : ISinhVienService
    {
        private readonly HttpClient _http;

        public SinhVienService(HttpClient http)
        {
            _http = http;
        }
        public List<BLSinhVien> SinhVien { get; set; } = new List<BLSinhVien>();
        public List<BLLopHoc> Lophoc { get; set; } = new List<BLLopHoc>();

        public async Task GetSinhVien()
        {
            var result = await _http.GetFromJsonAsync<List<BLSinhVien>>("api/SinhVien");
            if (result != null)
            {
                SinhVien = result;
            }
        }
        public async Task GetLopHoc()
        {
            var result = await _http.GetFromJsonAsync<List<BLLopHoc>>("api/LopHoc");
            if (result != null)
            {
                var lop = new BLLopHoc { Id = 0, MaLopHoc = default, TenLopHoc = "Chưa có lớp" };
                result.Add(lop);
                Lophoc = result;
            }
        }

        public async Task Create(UserRegisterRequest sinhvien)
        {
            var result = await _http.PostAsJsonAsync("api/User/CreateSV", sinhvien);
            var request = await result.Content.ReadFromJsonAsync<List<BLSinhVien>>();
            if (request != null)
                SinhVien = request;
        }

        public async Task<BLSinhVien> GetId(int id)
        {
            var result = await _http.GetFromJsonAsync<BLSinhVien>($"api/SinhVien/{id}");
            if(result == null)
            {
                return new BLSinhVien();
            }
            return result;
        }
        public async Task Update(BLSinhVien sinhvien)
        {
            var result = await _http.PutAsJsonAsync($"api/SinhVien/{sinhvien.Id}",sinhvien);
            var request = await result.Content.ReadFromJsonAsync<List<BLSinhVien>>();
            if (request != null)
                SinhVien = request;
        }
        public async Task Delete(int id)
        {
            var result = await _http.DeleteAsync($"api/SinhVien/{id}");
            var conresult = await result.Content.ReadFromJsonAsync<List<BLSinhVien>>();
            if (conresult != null) 
                SinhVien = conresult;
        }
    }
}
