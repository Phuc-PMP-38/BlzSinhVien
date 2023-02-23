using BlzSinhVien.Server.Service.NganhHocService;
using BlzSinhVien.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlzSinhVien.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NganhHocController : ControllerBase
    {
        private readonly INganhHocService _service;

        public NganhHocController(INganhHocService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<BLNganhHoc>>> Get()
        {
            return Ok(await _service.Get());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<List<BLNganhHoc>>> GetId(int Id)
        {
            var result = await _service.GetId(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<BLNganhHoc>>> Create(BLNganhHoc nganhhoc)
        {
            var result = await _service.CreateNH(nganhhoc);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<BLNganhHoc>>> Update(int Id,BLNganhHoc nganhhoc)
        {
            var result = await _service.UpdateNH(Id,nganhhoc);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<BLNganhHoc>>> Delete(int Id)
        {
            var result = await _service.DeleteNH(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
