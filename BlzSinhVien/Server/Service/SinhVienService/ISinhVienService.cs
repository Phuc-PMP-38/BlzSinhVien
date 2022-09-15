using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Server.Service.SinhVienService
{
    public interface ISinhVienService
    {
        Task<List<BLSinhVien>> GetSinhVien();
        Task<List<BLSinhVien>> Create(BLSinhVien sinhvien);
        Task<BLSinhVien> GetId(int id);
        Task<List<BLSinhVien>> Update(int Id,BLSinhVien sinhvien);
        Task<List<BLSinhVien>> Delete(int Id);
    }
}
