using BlzSinhVien.Shared.Model;
using System.Net.Http.Json;

namespace BlzSinhVien.Client.Service.MonHocService
{
    public class MonHocNganhService : IMonHocNganhService
    {
        private readonly HttpClient _http;

        public MonHocNganhService(HttpClient http)
        {
            _http = http;
        }
        public List<BLMonHocChuyenNganh> MonHocNganh { get; set; } = new List<BLMonHocChuyenNganh>();
        public string Messerror { get; set; } = string.Empty;
        public bool CheckError { get; set ; }

        public async Task Create(BLMonHocChuyenNganh monhoc)
        {
            try
            {
                bool IsCheck = MonHocNganh.Any(e => e.NganhHocId == monhoc.NganhHocId && e.MonHocKhoaId == monhoc.MonHocKhoaId && e.NamHoc == monhoc.NamHoc);
                if (IsCheck == false)
                {
                    var request = await _http.PostAsJsonAsync("api/MonHocChuyenNganh", monhoc);
                    var context = await request.Content.ReadFromJsonAsync<List<BLMonHocChuyenNganh>>();
                    if (context != null)
                    {
                        MonHocNganh = context;
                        CheckError = false;
                    }
                }
                else
                {
                    CheckError = true;
                    Messerror = "Đã tồn tại dữ liệu ";

                }
            }
            catch(Exception e)
            {
                Messerror = e.Message;
            }
        }

        public async Task Delete(int id)
        {
            var request = await _http.DeleteAsync($"api/MonHocChuyenNganh/{id}");
            var context = await request.Content.ReadFromJsonAsync<List<BLMonHocChuyenNganh>>();
            if(context != null)
            {
                MonHocNganh = context;
            }
        }

        public async Task<BLMonHocChuyenNganh?> GetId(int id)
        {
            var request = await _http.GetFromJsonAsync<BLMonHocChuyenNganh>($"api/MonHocChuyenNganh/{id}");
            if(request != null)
            {
                return request;
            }
            return null;
        }

        public async Task GetMonHocNganh()
        {
            var request = await _http.GetFromJsonAsync<List<BLMonHocChuyenNganh>>($"api/MonHocChuyenNganh");
            if (request != null)
            {
                MonHocNganh = request;
            }
        }

        public async Task Update(BLMonHocChuyenNganh monhoc)
        {
            try
            {
                bool IsCheck = MonHocNganh.Any(e => e.NganhHocId == monhoc.NganhHocId && e.MonHocKhoaId == monhoc.MonHocKhoaId && e.NamHoc == monhoc.NamHoc);
                if (IsCheck == false)
                {
                    var request = await _http.PutAsJsonAsync($"api/MonHocChuyenNganh/{monhoc.Id}", monhoc);
                    var context = await request.Content.ReadFromJsonAsync<List<BLMonHocChuyenNganh>>();
                    if (context != null)
                    {
                        MonHocNganh = context;
                        CheckError = false;
                    }
                }
                else
                {
                    CheckError = true;
                    Messerror = "Thông tin chưa được cập nhật hoặc tồn tại";
                }
            }
            catch(Exception e)
            {
                Messerror = e.Message;
            }
        }
       
    }
}
