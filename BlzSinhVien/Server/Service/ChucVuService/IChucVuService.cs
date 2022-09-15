using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Server.Service.ChucVuService
{
    public interface IChucVuService
    {
        Task<List<BLChucVu>> Get();
        Task<BLChucVu> GetId(int Id);
        Task<List<BLChucVu>> CreateCV(BLChucVu chucvu);
        Task<List<BLChucVu>> UpdateCV(int Id, BLChucVu chucvu);
        Task<List<BLChucVu>> DeleteCV(int Id);
    }
}
