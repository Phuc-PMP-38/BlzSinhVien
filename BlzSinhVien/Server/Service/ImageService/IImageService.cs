using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Server.Service.ImageService
{
    public interface IImageService
    {
        Task<List<BLImage>> UploadFile(List<IFormFile> files);
    }
}
