using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Server.Service.NganhHocService
{
    public interface INganhHocService
    {
        Task<List<BLNganhHoc>> Get();
        Task<BLNganhHoc?> GetId(int Id);
        Task<List<BLNganhHoc>?> CreateNH(BLNganhHoc nganhhoc);
        Task<List<BLNganhHoc>?> UpdateNH(int Id, BLNganhHoc nganhhoc);
        Task<List<BLNganhHoc>?> DeleteNH(int Id);
    }
}
