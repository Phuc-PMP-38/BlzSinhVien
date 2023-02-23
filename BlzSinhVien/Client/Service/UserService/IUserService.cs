using BlzSinhVien.Shared.Model;
using BlzSinhVien.Shared.Model.User;

namespace BlzSinhVien.Client.Service.UserService
{
    public interface IUserService
    {
        BLGiaoVien Giaovien { get; set; }
        BLSinhVien SinhVien { get; set; }
        bool CheckUser { get; set; }
        List<BLUser> Listuser { get; set; }
        Task GetUser();
        Task Delete(int Id);
        Task Update(BLUser user,int Id);
        Task Create(UserRegisterRequest user);
        Task<BLUser?> GetIdUser(int Id);
        Task<bool> UpdatePass(BLUserPasswordRequest userPass, UserSession sessionStorage);
        Task GetUserEmail(string email);

    }
}



