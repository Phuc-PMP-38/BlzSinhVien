using BlzSinhVien.Shared.Model.User;
using System.Net.Http.Json;
using Blazored.SessionStorage;
using BlzSinhVien.Client.Extensions;
using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Client.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;
        public UserService(HttpClient http)
        {
            _http = http;
        }

        public List<BLUser> Listuser { get; set; } = new List<BLUser>();
        public BLGiaoVien Giaovien { get; set; } = new BLGiaoVien();
        public BLSinhVien SinhVien { get; set; } = new BLSinhVien();
        public bool CheckUser { get; set; } = true;

        public async Task Delete(int Id)
        {
            var result = await _http.DeleteAsync($"api/User/Delete/{Id}");
            if (result != null)
            {
                var request =await result.Content.ReadFromJsonAsync<List<BLUser>>();
                if(request != null)
                {
                    Listuser = request;
                }
            }
        }

        public async Task<BLUser?> GetIdUser(int Id)
        {
            var result = await _http.GetFromJsonAsync<BLUser>($"api/User/Users/{Id}");
            if (result != null)
                return result;
            return null;
        }

        public async Task GetUser()
        {
            var result = await _http.GetFromJsonAsync<List<BLUser>>("api/User");
            if (result != null)
                Listuser = result;
        }

        public async Task Update(BLUser user,int Id)
        {
            var result = await _http.PutAsJsonAsync($"api/User/UpdateUser/{Id}", user);
        }
        public async Task Create(UserRegisterRequest user)
        {
            var result = await _http.PostAsJsonAsync($"api/User/Create", user);
        }
        public async Task<bool> UpdatePass(BLUserPasswordRequest userPass,UserSession usersession)
        {
            var result = await _http.PutAsJsonAsync("api/User/Update", userPass);
            var conresult = await result.Content.ReadFromJsonAsync<BLUser>();
            if (conresult == null)
            {
                return false;   
            }
            else
            {
                if (conresult.Id == 0)
                {
                    return false;
                }   
            }
            return true;
        }

        public async Task GetUserEmail(string email)
        {
            var result = await _http.GetFromJsonAsync<BLUser>($"api/User/{email}");
            if(result != null && result.ChucVu!=null)
            {
                if(result.ChucVu.MaRole == "GiaoVien")
                {
                    CheckUser = true;
                    Giaovien = result.GiaoVien;
                }
                else if (result.ChucVu.MaRole == "SinhVien")
                {
                    CheckUser = false;
                    SinhVien = result.SinhVien;
                }
            }
        }
        
    }
}
