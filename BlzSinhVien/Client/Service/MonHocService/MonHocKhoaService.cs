using BlzSinhVien.Shared.Model;
using System.Net.Http.Json;

namespace BlzSinhVien.Client.Service.MonHocService
{
    public class MonHocKhoaService : IMonHocKhoaService
    {
        private readonly HttpClient _http;

        public MonHocKhoaService(HttpClient http)
        {
            _http = http;
        }
        public List<BLMonHocKhoa> MonHocKhoa { get; set; } = new List<BLMonHocKhoa>();
        public string Messerror { get; set; } = string.Empty;
        public bool CheckError { get ; set ; }

        public async Task Create(BLMonHocKhoa monhockhoa)
        {
            try
            {
                bool IsCheck = MonHocKhoa.Any(e => e.NamHoc == monhockhoa.NamHoc && e.MonHocID == monhockhoa.MonHocID && e.KhoaId == monhockhoa.KhoaId);
                if (monhockhoa != null && IsCheck == false)
                {
                    var request = await _http.PostAsJsonAsync("api/MonHocKhoa", monhockhoa);
                    var context = await request.Content.ReadFromJsonAsync<List<BLMonHocKhoa>>();
                    if (context != null)
                    {
                        MonHocKhoa = context;
                        CheckError = false;
                    }
                }
                else
                {
                    Messerror = "Đã tồn tại môn học của khoa ";
                    CheckError = true;
                }

            }
            catch (Exception e)
            {
                Messerror = e.Message;
                CheckError = true;
            }
        }

        public async Task Delete(int id)
        {
            var request = await _http.DeleteAsync($"api/MonHocKhoa/{id}");
            var context = await request.Content.ReadFromJsonAsync<List<BLMonHocKhoa>>();
            if(context != null)
            {
                MonHocKhoa = context;
            }
        }

        public async Task<BLMonHocKhoa?> GetId(int id)
        {
            var request = await _http.GetFromJsonAsync<BLMonHocKhoa>($"api/MonHocKhoa/{id}");
            if(request != null)
            {
                return  request;
            }
            return null;

        }
        public async Task GetMonHocKhoa()
        {
            var request = await _http.GetFromJsonAsync<List<BLMonHocKhoa>>($"api/MonHocKhoa");
            if (request != null)
            {
                MonHocKhoa = request;
            }
        }

        public async Task Update(BLMonHocKhoa monhockhoa)
        {
            try
            {
                bool IsCheck = MonHocKhoa.Any(e=>e.NamHoc == monhockhoa.NamHoc && e.MonHocID == monhockhoa.MonHocID && e.KhoaId == monhockhoa.KhoaId);
                if(IsCheck == false)
                {
                    var request = await _http.PutAsJsonAsync($"api/MonHocKhoa/{monhockhoa.Id}", monhockhoa);
                    var context = await request.Content.ReadFromJsonAsync<List<BLMonHocKhoa>>();
                    if(context != null)
                    {
                        MonHocKhoa = context;
                        CheckError = false;
                    }
                }
                else
                {
                    CheckError = true;
                    Messerror = "Thông tin chưa được cập nhật";
                }
            }
            catch(Exception e)
            {
                Messerror = e.Message;
            }
        }
    }
}
