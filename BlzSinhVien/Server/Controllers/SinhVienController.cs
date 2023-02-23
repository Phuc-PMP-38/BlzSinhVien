using BlzSinhVien.Server.Service.SinhVienService;
using BlzSinhVien.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlzSinhVien.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SinhVienController : ControllerBase
    {
        private readonly ISinhVienService _service;

        public SinhVienController(ISinhVienService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<List<BLSinhVien>>>  GetSinhVien()
        {
            return Ok(await _service.GetSinhVien());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<BLSinhVien>> GetSVId(int Id)
        {
            var result = await _service.GetId(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost("{Id}")]
        public async Task<ActionResult<List<BLSinhVien>>> Create(BLSinhVien sinhvien, int Id)
        {
            var result = await _service.Create(sinhvien, Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<BLSinhVien>>> Update(int Id,BLSinhVien sinhvien)
        {
            var result = await _service.Update(Id, sinhvien);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<BLSinhVien>>> Delete(int Id)
        {
            var result = await _service.Delete(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
