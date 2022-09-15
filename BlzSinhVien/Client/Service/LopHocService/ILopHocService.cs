using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Client.Service.LopHocService
{
    public interface ILopHocService
    {
        List<BLLopHoc> Lophoc { get; set; }
        Task GetLopHoc();
        Task Create(BLLopHoc lophoc);
        Task<BLLopHoc> GetId(int id);
        Task Update(BLLopHoc lophoc);
        Task Delete(int id);
    }
}
