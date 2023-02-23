using BlzSinhVien.Server.Service.MonHocChuyenNganhService;
using BlzSinhVien.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlzSinhVien.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocChuyenNganhController : ControllerBase
    {
        private readonly IMonHocChuyenNganhService _service;

        public MonHocChuyenNganhController(IMonHocChuyenNganhService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<BLMonHocChuyenNganh>>> Get()
        {
            return Ok(await _service.Get());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<List<BLMonHocChuyenNganh>>> GetId(int Id)
        {
            var result = await _service.GetId(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<BLMonHocChuyenNganh>>> Create(BLMonHocChuyenNganh monhoc)
        {
            var result = await _service.CreateMHCN(monhoc);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<BLMonHocChuyenNganh>>> Update(int Id, BLMonHocChuyenNganh monhoc)
        {
            var result = await _service.UpdateMHCN(Id, monhoc);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<BLMonHocChuyenNganh>>> Delete(int Id)
        {
            var result = await _service.DeleteMHCN(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
