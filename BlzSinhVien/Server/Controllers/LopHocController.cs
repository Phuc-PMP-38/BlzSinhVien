using BlzSinhVien.Server.Service.LopHocService;
using BlzSinhVien.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlzSinhVien.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopHocController : ControllerBase
    {
        private readonly ILopHocService _service;

        public LopHocController(ILopHocService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<BLLopHoc>>> GetLopHoc()
        {
            return Ok(await _service.Get());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<List<BLLopHoc>>> GetLopHocId(int Id)
        {
            var result = await _service.GetId(Id);
            if (result == null)
               return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<BLLopHoc>>> CreateLop(BLLopHoc lophoc)
        {
            return Ok(await _service.CreateLH(lophoc));
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<BLLopHoc>>> UpdateLop(int Id,BLLopHoc lophoc)
        {
            return Ok(await _service.UpdateLH(Id,lophoc));
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<BLLopHoc>>> Delete(int Id)
        {
            return Ok(await _service.DeleteLH(Id));
        }
    }
}
