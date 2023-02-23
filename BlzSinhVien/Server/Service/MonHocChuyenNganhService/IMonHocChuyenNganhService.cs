using BlzSinhVien.Shared.Model;

namespace BlzSinhVien.Server.Service.MonHocChuyenNganhService
{
    public interface IMonHocChuyenNganhService
    {
        Task<List<BLMonHocChuyenNganh>> Get();
        Task<BLMonHocChuyenNganh?> GetId(int Id);
        Task<List<BLMonHocChuyenNganh>?> CreateMHCN(BLMonHocChuyenNganh monchuyennganh);
        Task<List<BLMonHocChuyenNganh>?> UpdateMHCN(int Id, BLMonHocChuyenNganh monchuyennganh);
        Task<List<BLMonHocChuyenNganh>?> DeleteMHCN(int Id);
    }
}
