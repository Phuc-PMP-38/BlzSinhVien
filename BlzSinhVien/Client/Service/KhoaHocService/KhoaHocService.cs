using BlzSinhVien.Shared.Model;
using System.Net.Http.Json;

namespace BlzSinhVien.Client.Service.KhoaHocService
{
    public class KhoaHocService : IKhoaHocService
    {
        private readonly HttpClient _http;

        public KhoaHocService(HttpClient http)
        {
            _http = http;
        }

        public List<BLKhoa> ListKhoa { get; set; } = new List<BLKhoa>();
        public string Messerror { get; set; } = string.Empty;
        public bool CheckError { get; set; } = true;

        public async Task Create(BLKhoa khoa)
        {
            try
            {
                bool checkname = ListKhoa.Any(e => (e.TenKhoa.ToLower() == khoa.TenKhoa.ToLower()));
                
                if (checkname == true)
                {
                    CheckError = true;
                    Messerror = $"Dữ liệu đã tồn tại không thể mời bạn Cập nhật thông tin";
                }
                else
                {
                    var result = await _http.PostAsJsonAsync<BLKhoa>("api/Khoa", khoa);
                    var request = await result.Content.ReadFromJsonAsync<List<BLKhoa>>();
                    if (request != null)
                    {
                        ListKhoa = request;
                        CheckError = false;
                    }
                }
            }
            catch
            {
                CheckError = true;
                Messerror = "Lỗi Không Thêm khoa được";
            }
           
        }

        public async Task Delete(int id)
        {
            var result = await _http.DeleteAsync($"api/Khoa/{id}");
            var request = await result.Content.ReadFromJsonAsync<List<BLKhoa>>();
            if (request != null)
                ListKhoa = request;
        }

        public async Task GetKhoa()
        {
            var result = await _http.GetFromJsonAsync<List<BLKhoa>>("api/Khoa");
            if (result != null)
            {
                ListKhoa = result;
            }
        }

        public async Task<BLKhoa?> GetId(int id)
        {
            var result = await _http.GetFromJsonAsync<BLKhoa>($"api/Khoa/{id}");
            if (result != null)
            {
                return result;
            }
            return null;
        }
        public async Task Update(BLKhoa khoa)
        {
            try
            {
                var resultkhoa = await _http.GetFromJsonAsync<BLKhoa>($"api/Khoa/{khoa.Id}");
                if (resultkhoa != null)
                {
                    bool checkname = ListKhoa.Any(e => e.TenKhoa.ToLower() == khoa.TenKhoa.ToUpper());
                    if (checkname == true)
                    {
                        CheckError = true;
                        Messerror = $"Dữ liệu đã tồn tại không thể mời bạn Cập nhật thông tin";
                    }
                    else 
                    {
                        var result = await _http.PutAsJsonAsync<BLKhoa>($"api/Khoa/{khoa.Id}", khoa);
                        var request = await result.Content.ReadFromJsonAsync<List<BLKhoa>>();
                        if (request != null)
                        {
                            ListKhoa = request;
                            CheckError = false;
                        }
                    } 
                }
            }
            catch
            {
                CheckError = true;
                Messerror = "Lỗi Không Update được";
            }
           
        }
    }
}
