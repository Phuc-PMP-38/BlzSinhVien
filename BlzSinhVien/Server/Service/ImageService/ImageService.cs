using BlzSinhVien.Server.Data;
using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Server.Service.ImageService
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _env;
        private readonly DataContext _context;

        public ImageService(IWebHostEnvironment env,DataContext context)
        {
            _env = env;
            _context = context;
        }

        public async Task<List<BLImage>> UploadFile(List<IFormFile> files)
        {
            List<BLImage> uploadResults = new List<BLImage>();

            foreach (var file in files)
            {
                var uploadResult = new BLImage();
                string trustedFileNameForFileStorage;
                var untrustedFileName = file.FileName;
                uploadResult.FileName = untrustedFileName;
                //var trustedFileNameForDisplay = WebUtility.HtmlEncode(untrustedFileName);

                trustedFileNameForFileStorage = Path.GetRandomFileName();
                var path = Path.Combine(_env.ContentRootPath, "uploads", trustedFileNameForFileStorage);

                await using FileStream fs = new(path, FileMode.Create);
                await file.CopyToAsync(fs);

                uploadResult.StoredFileName = trustedFileNameForFileStorage;
                uploadResult.ContentType = file.ContentType;
                uploadResults.Add(uploadResult);

                _context.Images.Add(uploadResult);
            }

            await _context.SaveChangesAsync();


            return uploadResults;
        }
    }
}
