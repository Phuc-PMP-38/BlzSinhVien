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
            return Ok(await _service.GetId(Id));
        }
        [HttpPost]
        public async Task<ActionResult<List<BLSinhVien>>> Create(BLSinhVien sinhvien)
        {
            return await _service.Create(sinhvien);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<BLSinhVien>>> Update(int Id,BLSinhVien sinhvien)
        {
            return await _service.Update(Id,sinhvien);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<BLSinhVien>>> Delete(int Id)
        {
            return await _service.Delete(Id);
        }
    }
}
