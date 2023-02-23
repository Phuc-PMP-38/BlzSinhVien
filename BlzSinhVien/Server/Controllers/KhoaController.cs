using BlzSinhVien.Server.Service.KhoaService;
using BlzSinhVien.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlzSinhVien.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoaController : ControllerBase
    {
        private readonly IKhoaService _service;

        public KhoaController (IKhoaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<BLKhoa>>> Get()
        {
            return Ok(await _service.Get());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<List<BLKhoa>>> GetId(int Id)
        {
            var result = await _service.GetId(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<BLKhoa>>> Create(BLKhoa khoa)
        {
            var result = await _service.CreateKhoa(khoa);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<BLKhoa>>> Update(int Id, BLKhoa khoa)
        {
            var result = await _service.UpdateKhoa(Id, khoa);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<BLKhoa>>> Delete(int Id)
        {
            var result = await _service.DeleteKhoa(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
