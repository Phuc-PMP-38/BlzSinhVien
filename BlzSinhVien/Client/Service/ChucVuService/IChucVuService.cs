using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Client.Service.ChucVuService
{
    public interface IChucVuService
    {
        List<BLChucVu> ChucVu { get; set; }
        Task GetChucVu();
        Task Create(BLChucVu chucvu);
        Task<BLChucVu> GetId(int id);
        Task Update(BLChucVu chucvu);
        Task Delete(int id);
    }
}
