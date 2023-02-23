using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Client.Service.MonHocService
{
    public interface IMonHocNganhService
    {
        List<BLMonHocChuyenNganh> MonHocNganh { get; set; }
        string Messerror { get; set; }
        bool CheckError { get; set; }
        Task GetMonHocNganh();
        Task Create(BLMonHocChuyenNganh monhoc);
        Task<BLMonHocChuyenNganh?> GetId(int id);
        Task Update(BLMonHocChuyenNganh monhoc);
        Task Delete(int id);
    }
}
