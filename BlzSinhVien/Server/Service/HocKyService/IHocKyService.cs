using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Server.Service.HocKyService
{
    public interface IHocKyService
    {
        Task<List<BLHocKy>> Get();
        Task<BLHocKy?> GetId(int Id);
        Task<List<BLHocKy>?> CreateHK(BLHocKy hocky);
        Task<List<BLHocKy>?> UpdateHK(int Id, BLHocKy hocky);
        Task<List<BLHocKy>?> DeleteHK(int Id);
    }
}
