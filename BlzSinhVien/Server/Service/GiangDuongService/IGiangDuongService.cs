using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Server.Service.GiangDuongService
{
    public interface IGiangDuongService
    {
        Task<List<BLGiangDuong>> Get();
        Task<BLGiangDuong?> GetId(int Id);
        Task<List<BLGiangDuong>> CreateGD(BLGiangDuong giangduong);
        Task<List<BLGiangDuong>?> UpdateGD(int Id, BLGiangDuong giangduong);
        Task<List<BLGiangDuong>?> DeleteGD(int Id);
    }
}
