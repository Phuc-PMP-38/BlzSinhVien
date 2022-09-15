using BlzSinhVien.Shared.Model;
using System.Net.Http.Json;

namespace BlzSinhVien.Client.Service.LopHocService
{
    public class LopHocService :ILopHocService
    {
        private readonly HttpClient _http;

        public LopHocService(HttpClient http)
        {
            _http = http;
        }
        public List<BLLopHoc> Lophoc { get; set; } = new List<BLLopHoc>();

        public async Task Create(BLLopHoc lophoc)
        {
            var result = await _http.PostAsJsonAsync("api/LopHoc", lophoc);
            var request = await result.Content.ReadFromJsonAsync<List<BLLopHoc>>();
            if (request != null)
            {
                Lophoc = request;
            }
        }

        public async Task Delete(int id)
        {
            var result = await _http.DeleteAsync($"api/LopHoc/{id}");
            var conresult = await result.Content.ReadFromJsonAsync<List<BLLopHoc>>();
            if(conresult != null)
                Lophoc = conresult;
        }

        public async Task<BLLopHoc> GetId(int id)
        {
            var result = await _http.GetFromJsonAsync<BLLopHoc>($"api/LopHoc/{id}");
            if (result != null)
                return result;
            return null;
        }

        public async Task GetLopHoc()
        {
            var result = await _http.GetFromJsonAsync<List<BLLopHoc>>("api/LopHoc");
            if(result!=null)
                Lophoc = result;
        }

        public async Task Update(BLLopHoc lophoc)
        {
            var result = await _http.PutAsJsonAsync($"api/LopHoc/{lophoc.Id}",lophoc);
            var request = await result.Content.ReadFromJsonAsync<List<BLLopHoc>>();
            if (request != null)
            {
                Lophoc = request;
            }
        }
    }
}
