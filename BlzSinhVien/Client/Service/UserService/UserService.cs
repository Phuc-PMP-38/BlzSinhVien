using BlzSinhVien.Shared.Model.User;
using System.Net.Http.Json;
using Blazored.SessionStorage;
using BlzSinhVien.Client.Extensions;

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
        public UserSession usersession { get; set; } = new UserSession();

        public Task<BLUser> GetIdUser(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<BLUser> Getuser(BLUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePass(BLUserPasswordRequest userPass,UserSession usersession)
        {
            var result = await _http.PutAsJsonAsync("api/User/Update", userPass);
            var conresult = await result.Content.ReadFromJsonAsync<BLUser>();
            if (conresult.Id == 0)  return false;
            return true;
        }
    }
}
