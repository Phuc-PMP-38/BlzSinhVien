using BlzSinhVien.Server.Service.GiangDuongService;
using BlzSinhVien.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlzSinhVien.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangDuongController : ControllerBase
    {
        private readonly IGiangDuongService _service;

        public GiangDuongController(IGiangDuongService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<BLGiangDuong>>> Get()
        {
            return Ok(await _service.Get());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<List<BLGiangDuong>>> GetId(int Id)
        {
            var result = await _service.GetId(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<BLGiangDuong>>> Create(BLGiangDuong giangduong)
        {
            var result = await _service.CreateGD(giangduong);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<BLGiangDuong>>> Update(int Id, BLGiangDuong giangduong)
        {
            var result = await _service.UpdateGD(Id, giangduong);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<BLGiangDuong>>> Delete(int Id)
        {
            var result = await _service.DeleteGD(Id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
