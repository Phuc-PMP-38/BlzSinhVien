using BlzSinhVien.Shared.Model.User;

namespace BlzSinhVien.Client.Service.UserService
{
    public interface IUserService
    {
        List<BLUser> Listuser { get; set; }
        UserSession usersession { get; set; }
        Task<BLUser> Getuser(BLUser user);
        Task<BLUser> GetIdUser(int Id);
        Task<bool> UpdatePass(BLUserPasswordRequest userPass, UserSession sessionStorage);
    }
}
