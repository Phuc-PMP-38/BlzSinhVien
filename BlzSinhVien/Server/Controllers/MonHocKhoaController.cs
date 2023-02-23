using BlzSinhVien.Server.Service.MonHocKhoaService;
using BlzSinhVien.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlzSinhVien.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocKhoaController : ControllerBase
    {
        private readonly IMonHocKhoaService _service;

        public MonHocKhoaController(IMonHocKhoaService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<BLMonHocKhoa>>> Get()
        {
            return Ok(await _service.Get());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<List<BLMonHocKhoa>>> GetId(int Id)
        {
            var result = await _service.GetId(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<BLMonHocKhoa>>> Create(BLMonHocKhoa monhoc)
        {
            var result = await _service.CreateGD(monhoc);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<BLMonHocKhoa>>> Update(int Id, BLMonHocKhoa monhoc)
        {
            var result = await _service.UpdateGD(Id, monhoc);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<BLMonHocKhoa>>> Delete(int Id)
        {
            var result = await _service.DeleteGD(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
