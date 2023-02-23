using BlzSinhVien.Shared.Model;
using System.Net.Http.Json;

namespace BlzSinhVien.Client.Service.MonHocService
{
    public class MonHocService : IMonHocService
    {
        private readonly HttpClient _http;

        public MonHocService(HttpClient http)
        {
            _http = http;
        }

        public List<BLMonHoc> MonHoc { get; set; } = new List<BLMonHoc>();
        public string Messerror { get; set; } = string.Empty;
        public bool CheckError { get ; set ; }

        public async Task Create(BLMonHoc monhoc)
        {
            try
            {
                if (MonHoc?.Any() != true)
                {
                    var request = await _http.PostAsJsonAsync("api/MonHoc", monhoc);
                    var context = await request.Content.ReadFromJsonAsync<List<BLMonHoc>>();
                    if (context != null)
                    {
                        MonHoc = context;
                        CheckError = false;
                    }
                }
                else
                {
                    bool IsCheck = MonHoc.Any(e => e.TenMonHoc == monhoc.TenMonHoc && e.MaMonHoc == monhoc.MaMonHoc);
                    if (monhoc != null && IsCheck == false)
                    {
                        var request = await _http.PostAsJsonAsync("api/MonHoc", monhoc);
                        var context = await request.Content.ReadFromJsonAsync<List<BLMonHoc>>();
                        if (context != null)
                        {
                            MonHoc = context;
                            CheckError = false;
                        }
                    }
                    else
                    {
                        Messerror = "Đã tồn tại môn học hoặc mã môn học ";
                        CheckError = true;
                    }
                }  
            }
            catch (Exception e)
            {
                Messerror = e.Message;
            }
            
        }

        public async Task Delete(int id)
        {
            var request = await _http.DeleteAsync($"api/MonHoc/{id}");
            var context = await request.Content.ReadFromJsonAsync<List<BLMonHoc>>();
            if (context != null)
            {
                MonHoc = context;
            }
        }

        public async Task<BLMonHoc?> GetId(int id)
        {
            var request = await _http.GetFromJsonAsync<BLMonHoc>($"api/MonHoc/{id}");
            if (request != null)
            {
                return request;
            }
            return null;
        }

        public async Task GetMonHoc()
        {
            var request = await _http.GetFromJsonAsync<List<BLMonHoc>>($"api/MonHoc");
            if (request != null)
            {
                MonHoc = request;
            }
        }

        public async Task Update(BLMonHoc monhoc)
        {
            try
            {
                bool IsCheck = MonHoc.Any(e => e.TenMonHoc == monhoc.TenMonHoc && e.MaMonHoc == monhoc.MaMonHoc 
                && e.SoTietLyThuyet == monhoc.SoTietLyThuyet && e.SoTietThucHanh == monhoc.SoTietThucHanh && e.SoTinChi == monhoc.SoTinChi);
                if(IsCheck == false)
                {
                    var request = await _http.PutAsJsonAsync($"api/MonHoc/{monhoc.Id}", monhoc);
                    var context = await request.Content.ReadFromJsonAsync<List<BLMonHoc>>();
                    if (context != null)
                    {
                        MonHoc = context;
                        CheckError = false;
                    }
                }
                else
                {
                    Messerror = "Đã tồn tại môn học hoặc mã môn học";
                    CheckError = true;
                }
            }
            catch(Exception e)
            {
                Messerror = e.Message;
            }
        }
    }
}
