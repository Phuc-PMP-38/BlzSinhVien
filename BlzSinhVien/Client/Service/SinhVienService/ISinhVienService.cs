using BlzSinhVien.Shared.Model;
using BlzSinhVien.Shared.Model.User;

namespace BlzSinhVien.Client.Service.SinhVienService
{
    public interface ISinhVienService
    {
        List<BLSinhVien> SinhVien { get; set; }
        List<BLLopHoc> Lophoc { get; set; }
        Task GetSinhVien();
        Task Create(UserRegisterRequest sinhvien);
        Task GetLopHoc();
        Task<BLSinhVien> GetId(int id);
        Task Update(BLSinhVien sinhvien);
        Task Delete(int id);
    }
}
