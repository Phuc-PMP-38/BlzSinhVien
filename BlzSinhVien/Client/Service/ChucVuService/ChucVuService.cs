using BlzSinhVien.Shared.Model;
using System.Net.Http.Json;
namespace BlzSinhVien.Client.Service.ChucVuService
{
    public class ChucVuService : IChucVuService
    {
        private readonly HttpClient _http;

        public ChucVuService(HttpClient http)
        {
            _http = http;
        }

        public List<BLChucVu> ChucVu { get; set; } = new List<BLChucVu>();
        public string Messerror { get; set; } = string.Empty;
        public bool CheckError { get; set; } = true;
        public async Task Create(BLChucVu chucvu)
        {
            try
            {
                var result = await _http.PostAsJsonAsync<BLChucVu>("api/ChucVu", chucvu);
                var request = await result.Content.ReadFromJsonAsync<List<BLChucVu>>();
                if (request != null)
                {
                    ChucVu = request;
                    CheckError = false;
                }
            }
            catch
            {
                Messerror = "Không thêm được chức vụ ";
                CheckError = true;
            }
            
        }

        public async Task Delete(int id)
        {
            var result = await _http.DeleteAsync($"api/ChucVu/{id}");
            var request = await result.Content.ReadFromJsonAsync<List<BLChucVu>>();
            if (request != null)
                ChucVu = request;
        }

        public async Task GetChucVu()
        {
            var result = await _http.GetFromJsonAsync<List<BLChucVu>>("api/ChucVu");
            if (result != null)
            {
                ChucVu = result;
            }
        }

        public async Task<BLChucVu?> GetId(int id)
        {
            var result = await _http.GetFromJsonAsync<BLChucVu>($"api/ChucVu/{id}");
            if (result != null)
            {
                return result;
            }
            return null;
        }
        public async Task GetMaRole(string Marole)
        {
            var result = await _http.GetFromJsonAsync<List<BLChucVu>>($"api/ChucVu/Role/{Marole}");
            if (result != null)
            {
                ChucVu = result;
            }
        }

        public async Task Update(BLChucVu chucvu)
        {
            try
            {
                var resultCV = await _http.GetFromJsonAsync<BLChucVu>($"api/ChucVu/{chucvu.Id}");
                if (resultCV != null)
                {
                    bool checkCV =  resultCV.RoleDesc != chucvu.RoleDesc || resultCV.TenChucVu != chucvu.TenChucVu;
                    bool checkname = ChucVu.Any(e => e.RoleDesc == chucvu.RoleDesc || e.TenChucVu == chucvu.TenChucVu);
                   
                     if(checkCV == true)
                    {
                        var result = await _http.PutAsJsonAsync<BLChucVu>($"api/ChucVu/{chucvu.Id}", chucvu);
                        var request = await result.Content.ReadFromJsonAsync<List<BLChucVu>>();
                        if (request != null)
                        {
                            ChucVu = request;
                            CheckError = false;
                        }
                    }
                    else if(checkname == true)
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
