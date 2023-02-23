using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Server.Service.MonHocService
{
    public interface IMonHocService
    {
        Task<List<BLMonHoc>> Get();
        Task<BLMonHoc?> GetId(int Id);
        Task<List<BLMonHoc>?> CreatMH(BLMonHoc monhoc);
        Task<List<BLMonHoc>?> UpdateMH(int Id, BLMonHoc monhoc);
        Task<List<BLMonHoc>?> DeleteMh(int Id);
    }
}
