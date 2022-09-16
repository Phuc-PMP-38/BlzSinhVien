﻿using BlzSinhVien.Shared.Model;
using BlzSinhVien.Shared.Model.User;

namespace BlzSinhVien.Server.Service.UserService
{
    public interface IUserService
    {
        Task<BLUser> GetUserID(int Id);
        Task<UserSession> Login(BLUserLogin user);
        Task<List<BLUser>> GetListUser();
        Task<List<BLUser>> CreateUser(UserRegisterRequest user);
        Task<BLUser> UpdatePass(BLUserPasswordRequest user);
        Task<List<BLUser>> UpdateUser(int Id,BLUser user);
        Task<List<BLUser>> DeleteUser(int Id);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        string CreateRandomToken();
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}
