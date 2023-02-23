using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Server.Service.MonHocKhoaService
{
    public interface IMonHocKhoaService
    {
        Task<List<BLMonHocKhoa>> Get();
        Task<BLMonHocKhoa?> GetId(int Id);
        Task<List<BLMonHocKhoa>> CreateGD(BLMonHocKhoa monhockhoa);
        Task<List<BLMonHocKhoa>?> UpdateGD(int Id, BLMonHocKhoa monhockhoa);
        Task<List<BLMonHocKhoa>?> DeleteGD(int Id);
    }
}
