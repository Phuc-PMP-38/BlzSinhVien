using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Client.Service.ImageService
{
    public interface IImageService
    {
        List<BLImage> ListImage { get; set; }
        Task Update(MultipartFormDataContent context);
    }
}
