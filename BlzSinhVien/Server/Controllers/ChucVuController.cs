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
        [HttpPost]
        public async Task<ActionResult<List<BLChucVu>>> CreateCV(BLChucVu chucvu)
        {
            return Ok(await _service.CreateCV(chucvu));
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<BLChucVu>>> UpdateCV(int Id, BLChucVu chucvu)
        {
            return Ok(await _service.UpdateCV(Id, chucvu));
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<BLChucVu>>> DeleteCV(int Id)
        {
            return Ok(await _service.DeleteCV(Id));
        }
    }
}
