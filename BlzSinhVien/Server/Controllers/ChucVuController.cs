using BlzSinhVien.Server.Service.ChucVuService;
using BlzSinhVien.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlzSinhVien.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private readonly IChucVuService _service;

        public ChucVuController(IChucVuService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<BLChucVu>>> GetLopHoc()
        {
            return Ok(await _service.Get());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<List<BLChucVu>>> GetCVId(int Id)
        {
            var result = await _service.GetId(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet("Role/{MaRole}")]
        public async Task<ActionResult<List<BLChucVu>>> GetCVMarole(string MaRole)
        {
            var result = await _service.GetMaRole(MaRole);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<BLChucVu>>> CreateCV(BLChucVu chucvu)
        {
            var result = await _service.CreateCV(chucvu);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<BLChucVu>>> UpdateCV(int Id, BLChucVu chucvu)
        {
            var result = await _service.UpdateCV(Id, chucvu);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<BLChucVu>>> DeleteCV(int Id)
        {
            var result = await _service.DeleteCV(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
