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
        [HttpGet]
        public async Task<ActionResult<List<BLUser>>> GetListUser()
        {
            return await _user.GetListUser();
        }
        [HttpGet("{Email}")]
        public async Task<ActionResult<BLUser>> GetUserEmail(string Email)
        {
            var result = await _user.GetUserEmail(Email);
            if (result == null)
                return NotFound("Không tìm thấy đối tượng");
            return Ok(result);
        }
        [HttpGet("Users/{Id}")]
        public async Task<ActionResult<BLUser>> GetIdUser(int Id)
        {
            var result = await _user.GetUserID(Id);
            if (result is null)
                return NotFound("Không tìm thấy đổi tượng 1");
            return Ok(result);
        }
        [HttpPost("CreateSV")]
        public async Task<ActionResult<List<BLSinhVien>>> CreateSV(UserRegisterRequest user)
        {
            var result = await _user.CreateUser(user);
            if (result is null)
                return NotFound("Lỗi");
            return Ok(result);
        }
        [HttpPost("CreateGV")]
        public async Task<ActionResult<List<BLGiaoVien>>> CreateGV(UserRegisterRequestGV user)
        {
            var result = await _user.CreateUserGiaoVien(user);
            if (result is null)
                return NotFound("Lỗi");
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<ActionResult<BLUser>> Update(BLUserPasswordRequest user)
        {
            var result = await _user.UpdatePass(user);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPut("UpdateUser")]
        public async Task<ActionResult<List<BLUser>>> UpdateUser(int Id,BLUser user)
        {
            var result = await _user.UpdateUser(Id, user);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<List<BLUser>>> Delete(int Id)
        {
            var result = await _user.DeleteUser(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
