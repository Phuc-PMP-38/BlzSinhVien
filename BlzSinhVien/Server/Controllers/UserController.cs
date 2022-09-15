using BlzSinhVien.Server.Service.UserService;
using BlzSinhVien.Shared.Model;
using BlzSinhVien.Shared.Model.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlzSinhVien.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;

        public UserController(IUserService user)
        {
            _user = user;
        }
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserSession>> Login(BLUserLogin user)
        {
            var login = await _user.Login(user);
            if (login is null)
                return Unauthorized();
            else
                return login;
        }
        [HttpPost("Create")]
        public async Task<ActionResult<List<BLUser>>> Create(UserRegisterRequest user)
        {
            return await _user.CreateUser(user);
        }
        [HttpPut("Update")]
        public async Task<ActionResult<BLUser>> Update(BLUserPasswordRequest user)
        {
            return await _user.UpdateUser(user);
        }
    }
}
