using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Client.Service.KhoaHocService
{
    public interface IKhoaHocService
    {
        List<BLKhoa> ListKhoa { get; set; }
        string Messerror { get; set; }
        bool CheckError { get; set; }
        Task GetKhoa();
        Task Create(BLKhoa khoa);
        Task<BLKhoa?> GetId(int id);
        Task Update(BLKhoa khoa);
        Task Delete(int id);
    }
}
