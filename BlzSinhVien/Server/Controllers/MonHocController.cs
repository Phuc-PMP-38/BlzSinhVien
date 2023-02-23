using BlzSinhVien.Server.Service.MonHocService;
using BlzSinhVien.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlzSinhVien.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocController : ControllerBase
    {
        private readonly IMonHocService _service;

        public MonHocController(IMonHocService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<BLMonHoc>>> Get()
        {
            return Ok(await _service.Get());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<List<BLMonHoc>>> GetId(int Id)
        {
            var result = await _service.GetId(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<BLMonHoc>>> Create(BLMonHoc monhoc)
        {
            var result = await _service.CreatMH(monhoc);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<BLMonHoc>>> Update(int Id,BLMonHoc monhoc)
        {
            var result = await _service.UpdateMH(Id,monhoc);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<BLMonHoc>>> Delete(int Id)
        {
            var result = await _service.DeleteMh(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
