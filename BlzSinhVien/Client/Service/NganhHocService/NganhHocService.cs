using BlzSinhVien.Shared.Model;
using System.Net.Http.Json;

namespace BlzSinhVien.Client.Service.NganhHocService
{
    public class NganhHocService : INganhHocService
    {
        private readonly HttpClient _http;

        public NganhHocService(HttpClient http)
        {
            _http = http;
        }
        public List<BLNganhHoc> ListNganhHoc { get; set; } = new List<BLNganhHoc>();
        public string Messerror { get; set; } = string.Empty;
        public bool CheckError { get; set; } = true;

        public async Task Create(BLNganhHoc nganhhoc)
        {
            try
            {
                bool checkname = ListNganhHoc.Any(e => e.TenNganh.ToLower() == nganhhoc.TenNganh.ToLower());
                if (checkname == true)
                {
                    CheckError = true;
                    Messerror = $"Dữ liệu đã tồn tại không thể mời bạn Cập nhật thông tin";
                }
                else
                {
                    var result = await _http.PostAsJsonAsync("api/NganhHoc", nganhhoc);
                    var request = await result.Content.ReadFromJsonAsync<List<BLNganhHoc>>();
                    if (request != null)
                    {
                        ListNganhHoc = request;
                        CheckError = false;
                    }
                }
            }
            catch
            {
                CheckError = true;
                Messerror = "Lỗi Không Thêm được";
            }
        }

        public async Task Delete(int id)
        {
            var result = await _http.DeleteAsync($"api/NganhHoc/{id}");
            var request = await result.Content.ReadFromJsonAsync<List<BLNganhHoc>>();
            if (request != null)
                ListNganhHoc = request;
        }

        public async Task<BLNganhHoc?> GetId(int id)
        {
            var result = await _http.GetFromJsonAsync<BLNganhHoc>($"api/NganhHoc/{id}");
            return result;
        }

        public async Task GetNganhHoc()
        {
            var result = await _http.GetFromJsonAsync<List<BLNganhHoc>>("api/NganhHoc");
            if (result != null)
                ListNganhHoc = result;
        }

        public async Task Update(BLNganhHoc nganhhoc)
        {

            try
            {
                var resultNH = await _http.GetFromJsonAsync<BLNganhHoc>($"api/NganhHoc/{nganhhoc.Id}");
                if (resultNH != null)
                {
                    bool checkNH = resultNH.TenNganh != nganhhoc.TenNganh;
                    bool checkname = ListNganhHoc.Any(e => e.TenNganh.ToLower()==nganhhoc.TenNganh.ToLower());

                    if (checkNH == true)
                    {
                        var result = await _http.PutAsJsonAsync($"api/NganhHoc/{nganhhoc.Id}", nganhhoc);
                        var request = await result.Content.ReadFromJsonAsync<List<BLNganhHoc>>();
                        if (request != null)
                        {
                            ListNganhHoc = request;
                            CheckError = false;
                        }
                    }
                    else if (checkname == true)
                    {
                        CheckError = true;
                        Messerror = $"Dữ liệu đã tồn tại không thể mời bạn Cập nhật thông tin";
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
