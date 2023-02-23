using BlzSinhVien.Server.Service.GiaoVienService;
using BlzSinhVien.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlzSinhVien.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiaoVienController : ControllerBase
    {
        private readonly IGiaoVienService _service;

        public GiaoVienController(IGiaoVienService service)
        {
            _service = service;
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<BLGiaoVien>> GetId (int Id)
        {
            var result = await _service.GetId(Id);
            if(result== null)
            {
                return NotFound();
            }
            return result;
        }
        [HttpGet("{fistname}/{lastname}")]
        public async Task<ActionResult<BLGiaoVien>> GetId(string fistname,string lastname)
        {
            var result = await _service.GetNameGV(fistname,lastname);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        [HttpGet]
        public async Task<ActionResult<List<BLGiaoVien>>> GetList()
        {
            var result = await _service.GetList();
            return result;
        }
        [HttpPost("{Id}/{IdAdmin}")]
        public async Task<ActionResult<List<BLGiaoVien>>> Create(BLGiaoVien giaovien, int Id, int IdAdmin)
        {
            var result = await _service.Create(giaovien, Id, IdAdmin);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<List<BLGiaoVien>>> Update(int Id,BLGiaoVien giaovien)
        {
            var result = await _service.Update(Id,giaovien);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<BLGiaoVien>>> Delete(int Id)
        {
            var result = await _service.Delete(Id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
    }
}
