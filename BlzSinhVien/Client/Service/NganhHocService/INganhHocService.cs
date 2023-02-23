using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Client.Service.NganhHocService
{
    public interface INganhHocService
    {
        List<BLNganhHoc> ListNganhHoc { get; set; }
        string Messerror { get; set; }
        bool CheckError { get; set; }
        Task GetNganhHoc();
        Task Create(BLNganhHoc nganhhoc);
        Task<BLNganhHoc?> GetId(int id);
        Task Update(BLNganhHoc nganhhoc);
        Task Delete(int id);
    }
}
