using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Server.Service.KhoaService
{
    public interface IKhoaService
    {
        Task<List<BLKhoa>> Get();
        Task<BLKhoa?> GetId(int Id);
        Task<List<BLKhoa>> CreateKhoa(BLKhoa khoa);
        Task<List<BLKhoa>?> UpdateKhoa(int Id, BLKhoa khoa);
        Task<List<BLKhoa>?> DeleteKhoa(int Id);
    }
}
