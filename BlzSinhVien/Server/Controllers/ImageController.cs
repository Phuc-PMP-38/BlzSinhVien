using BlzSinhVien.Server.Service.ImageService;
using BlzSinhVien.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlzSinhVien.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _service;

        public ImageController(IImageService service)
        {
            _service = service;
        }
        [HttpPost("{Id}")]
        public async Task<ActionResult<List<BLImage>>> UploadFile(List<IFormFile> files)
        {
            try
            {
                return Ok(await _service.UploadFile(files));
            }catch(Exception e)
            {
                return NotFound(e.Message);
            }
            
        }
    }
}
