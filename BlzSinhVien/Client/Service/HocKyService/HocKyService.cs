using BlzSinhVien.Shared.Model;
using System.Net.Http.Json;

namespace BlzSinhVien.Client.Service.HocKyService
{
    public class HocKyService : IHocKyService
    {
        private readonly HttpClient _http;

        public HocKyService(HttpClient http)
        {
            _http = http;
        }
        public List<BLHocKy> HocKy { get; set; } = new List<BLHocKy>();
        public string Messerror { get; set; } = string.Empty;
        public bool CheckError { get; set; } = true;

        public async Task Create(BLHocKy hocky)
        {
            try
            {
                var request = await _http.PostAsJsonAsync("api/HocKy",hocky);
                var context = await request.Content.ReadFromJsonAsync<List<BLHocKy>>();
                if(context != null)
                {
                    HocKy = context;
                    CheckError = false;
                }
            }
            catch(Exception e)
            {
                Messerror = e.Message;
                CheckError = true;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var request = await _http.DeleteAsync($"api/HocKy/{id}");
                var context = await request.Content.ReadFromJsonAsync<List<BLHocKy>>();
                if (context != null)
                {
                    HocKy = context;
                    CheckError = false;
                }
            }catch(Exception e)
            {
                Messerror = e.Message;
                CheckError = true;
            }
        }

        public async Task GetHocKy()
        {
            var request = await _http.GetFromJsonAsync<List<BLHocKy>>("api/HocKy");
            if (request != null)
            {
                HocKy = request;
            }
        }

        public async Task<BLHocKy?> GetId(int id)
        {
            var request = await _http.GetFromJsonAsync<BLHocKy>($"api/HocKy/{id}");
            if (request != null)
            {
                return request;
            }
            return null;
        }

        public async Task Update(BLHocKy hocky)
        {
            try
            {
                var request = await _http.PutAsJsonAsync($"api/HocKy/{hocky.Id}", hocky);
                var context = await request.Content.ReadFromJsonAsync<List<BLHocKy>>();
                if (context != null)
                {
                    HocKy = context;
                }
            }
            catch(Exception e)
            {
                Messerror = e.Message;
                CheckError = true;
            }
        }
    }
}
