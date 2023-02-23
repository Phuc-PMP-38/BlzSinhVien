using BlzSinhVien.Server.Service.HocKyService;
using BlzSinhVien.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlzSinhVien.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocKyController : ControllerBase
    {
        private readonly IHocKyService _context;

        public HocKyController(IHocKyService context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<BLHocKy>>> Get()
        {
            var request = await _context.Get();
            return Ok(request);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<BLHocKy>> GetId(int Id)
        {
            var request = await _context.GetId(Id);
            if (request == null)
                return NotFound("Lỗi Id");
            return Ok(request);
        }
        [HttpPost]
        public async Task<ActionResult<List<BLHocKy>>> Create(BLHocKy hocky)
        {
            var request = await _context.CreateHK(hocky);
            if (request == null)
                return NotFound("Lỗi create");
            return Ok(request);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<BLHocKy>>> Update(int Id,BLHocKy hocky)
        {
            var request = await _context.UpdateHK(Id,hocky);
            if (request == null)
                return NotFound("Lỗi update");
            return Ok(request);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<BLHocKy>>> Delete(int Id)
        {
            var request = await _context.DeleteHK(Id);
            if (request == null)
                return NotFound("Lỗi delete");
            return Ok(request);
        }
    }
}
