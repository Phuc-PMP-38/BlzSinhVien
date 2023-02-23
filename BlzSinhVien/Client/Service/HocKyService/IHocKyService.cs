using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Client.Service.HocKyService
{
    public interface IHocKyService
    {
        List<BLHocKy> HocKy { get; set; }
        string Messerror { get; set; }
        bool CheckError { get; set; }
        Task GetHocKy();
        Task Create(BLHocKy hocky);
        Task<BLHocKy?> GetId(int id);
        Task Update(BLHocKy hocky);
        Task Delete(int id);
    }
}
