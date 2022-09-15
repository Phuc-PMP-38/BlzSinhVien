using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Server.Service.LopHocService
{
    public interface ILopHocService
    {
        Task<List<BLLopHoc>> Get();
        Task<BLLopHoc> GetId(int Id);
        Task<List<BLLopHoc>> CreateLH(BLLopHoc lophoc);
        Task<List<BLLopHoc>> UpdateLH(int Id,BLLopHoc lophoc);
        Task<List<BLLopHoc>> DeleteLH(int Id);
    }
}
