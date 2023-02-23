using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Server.Service.GiaoVienService
{
    public interface IGiaoVienService
    {
        Task<List<BLGiaoVien>> GetList();
        Task<BLGiaoVien?> GetId(int Id);
        Task<BLGiaoVien?> GetNameGV(string fistname,string lastname);
        Task<List<BLGiaoVien>?> Create(BLGiaoVien giaovien,int Id,int IdAdmin);
        Task<List<BLGiaoVien>?> Update(int Id,BLGiaoVien giaovien);
        Task<List<BLGiaoVien>?> Delete(int Id);
    }
}
