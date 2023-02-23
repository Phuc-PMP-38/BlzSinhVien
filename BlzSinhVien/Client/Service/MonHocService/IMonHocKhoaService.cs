using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Client.Service.MonHocService
{
    public interface IMonHocKhoaService
    {
        List<BLMonHocKhoa> MonHocKhoa { get; set; }
        string Messerror { get; set; }
        bool CheckError { get; set; }
        Task GetMonHocKhoa();
        Task Create(BLMonHocKhoa monhockhoa);
        Task<BLMonHocKhoa?> GetId(int id);
        Task Update(BLMonHocKhoa monhockhoa);
        Task Delete(int id);
    }
}
