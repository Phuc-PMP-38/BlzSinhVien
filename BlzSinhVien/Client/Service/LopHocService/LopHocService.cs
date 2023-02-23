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
        public string Messerror { get; set; } = string.Empty;
        public bool CheckError { get; set; } = true;
        public async Task Create(BLLopHoc lophoc)
        {
            try
            {
                bool checkname = Lophoc.Any(e => e.TenLopHoc.ToLower() == lophoc.TenLopHoc.ToLower());
                if (checkname == true)
                {
                    CheckError = true;
                    Messerror = $"Dữ liệu đã tồn tại không thể mời bạn Cập nhật thông tin";
                }
                else
                {
                    var result = await _http.PostAsJsonAsync("api/LopHoc", lophoc);
                    var request = await result.Content.ReadFromJsonAsync<List<BLLopHoc>>();
                    if (request != null)
                    {
                        Lophoc = request;
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
            var result = await _http.DeleteAsync($"api/LopHoc/{id}");
            var conresult = await result.Content.ReadFromJsonAsync<List<BLLopHoc>>();
            if(conresult != null)
                Lophoc = conresult;
        }

        public async Task<BLLopHoc?> GetId(int id)
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
            try
            {
                var resultLH = await _http.GetFromJsonAsync<BLLopHoc>($"api/LopHoc/{lophoc.Id}");
                if (resultLH != null)
                {
                    bool checkLH = resultLH.TenLopHoc != lophoc.TenLopHoc || resultLH.MaLopHoc != lophoc.MaLopHoc || resultLH.NganhHocId!= lophoc.NganhHocId;
                    bool checkname = Lophoc.Any(e => e.TenLopHoc == lophoc.TenLopHoc  || e.MaLopHoc == lophoc.MaLopHoc || e.NganhHocId==lophoc.NganhHocId);

                    if (checkLH == true)
                    {
                        var result = await _http.PutAsJsonAsync($"api/LopHoc/{lophoc.Id}", lophoc);
                        var request = await result.Content.ReadFromJsonAsync<List<BLLopHoc>>();
                        if (request != null)
                        {
                            Lophoc = request;
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
