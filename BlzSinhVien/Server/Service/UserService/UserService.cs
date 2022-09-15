using BlzSinhVien.Server.Authentication;
using BlzSinhVien.Server.Data;
using BlzSinhVien.Shared.Model;
using BlzSinhVien.Shared.Model.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BlzSinhVien.Server.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BLUser>> CreateUser(UserRegisterRequest user)
        {
            if (_context.BLUsers.Any(u => u.EmailAddress == user.EmailAddress))
            {
                return null;
            }
            CreatePasswordHash(user.Password,
                 out byte[] passwordHash,
                 out byte[] passwordSalt);

            var user1 = new BLUser
            {
                EmailAddress = user.EmailAddress,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = user.Role
            };

            _context.BLUsers.Add(user1);
            await _context.SaveChangesAsync();

            return await _context.BLUsers.ToListAsync();
        }

        public async Task<List<BLUser>> DeleteUser(int Id)
        {
            var result = await _context.BLUsers.FindAsync(Id);
            if (result == null)
                return null;
            _context.BLUsers.Remove(result);
            await _context.SaveChangesAsync();
            return await _context.BLUsers.ToListAsync();
        }

        public async Task<List<BLUser>> GetListUser()
        {
            return await _context.BLUsers.ToListAsync();
        }

        public async Task<BLUser> GetUserID(int Id)
        {
            var result = await _context.BLUsers.FindAsync(Id);
            if (result == null)
                return null;
            return result;
        }

        public async Task<UserSession> Login(BLUserLogin user)
        {
            try { 
                var userSession = new UserSession();
                var request = await _context.BLUsers.FirstOrDefaultAsync(u => u.EmailAddress == user.EmailAddress);
                if (request != null)
                {
                    if (!VerifyPasswordHash(user.Password, request.PasswordHash, request.PasswordSalt))
                    {
                        return null;
                    }
                    else
                    {
                        var jwtAuthenticationManager = new JwtAuthenticationManager(request);
                        userSession = jwtAuthenticationManager.GenerateJwtToken(user.EmailAddress, user.Password, request);
                        if (userSession == null)
                        {
                            return null;
                        }
                    }
                }
                return userSession;
            }
            catch
            {
                return null;
            }
        }
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }   
        }

        public string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
        public async Task<BLUser> UpdateUser(BLUserPasswordRequest user)
        {
            try
            {
                var request = await _context.BLUsers.FirstOrDefaultAsync(u => u.EmailAddress == user.Email);
                var requestPass = VerifyPasswordHash(user.Password, request.PasswordHash, request.PasswordSalt);
                if (request == null || requestPass == false)
                {
                    return new BLUser();
                }
                else
                {
                    CreatePasswordHash(user.ConfirmPassword,
                                   out byte[] passwordHash,
                                   out byte[] passwordSalt);
                    request.PasswordSalt = passwordSalt;
                    request.PasswordHash = passwordHash;
                    await _context.SaveChangesAsync();
                }
                return request;
            }
            catch
            {
                return new BLUser();
            }
        }
    }
}
