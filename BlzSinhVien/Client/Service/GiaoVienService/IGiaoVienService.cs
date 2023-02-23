using BlzSinhVien.Shared.Model;
using BlzSinhVien.Shared.Model.User;

namespace BlzSinhVien.Client.Service.GiaoVienService
{
    public interface IGiaoVienService
    {
        List<BLGiaoVien> GiaoVien { get; set; }
        Task GetGiaoVien();
        Task Create(UserRegisterRequestGV giaovien);
        Task<BLGiaoVien?> GetId(int id);
        Task Update(BLGiaoVien giaovien);
        Task Delete(int id);
    }
}


