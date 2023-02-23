using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Client.Service.MonHocService
{
    public interface IMonHocService
    {
        List<BLMonHoc> MonHoc { get; set; }
        string Messerror { get; set; }
        bool CheckError { get; set; }
        Task GetMonHoc();
        Task Create(BLMonHoc monhoc);
        Task<BLMonHoc?> GetId(int id);  
        Task Update(BLMonHoc monhoc);
        Task Delete(int id);
    }
}
