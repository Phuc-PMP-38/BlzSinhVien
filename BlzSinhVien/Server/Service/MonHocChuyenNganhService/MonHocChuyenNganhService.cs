using BlzSinhVien.Server.Data;
using BlzSinhVien.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BlzSinhVien.Server.Service.MonHocChuyenNganhService
{
    public class MonHocChuyenNganhService : IMonHocChuyenNganhService
    {
        private readonly DataContext _context;

        public MonHocChuyenNganhService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<BLMonHocChuyenNganh>?> CreateMHCN(BLMonHocChuyenNganh monchuyennganh)
        {
            monchuyennganh.NganhHoc = null;
            monchuyennganh.MonHocKhoa = null;
            _context.MonHocChuyenNganhs.Add(monchuyennganh);
            await _context.SaveChangesAsync();
            return await _context.MonHocChuyenNganhs.ToListAsync();
        }

        public async Task<List<BLMonHocChuyenNganh>?> DeleteMHCN(int Id)
        {
            var result = await _context.MonHocChuyenNganhs.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
                return null;
            _context.MonHocChuyenNganhs.Remove(result);
            await _context.SaveChangesAsync();
            return await _context.MonHocChuyenNganhs.ToListAsync();
        }

        public async Task<List<BLMonHocChuyenNganh>> Get()
        {
            return await _context.MonHocChuyenNganhs.Include(e=>e.NganhHoc).Include(e=>e.MonHocKhoa).ToListAsync();
        }

        public async Task<BLMonHocChuyenNganh?> GetId(int Id)
        {
            var result = await _context.MonHocChuyenNganhs.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
                return null;
            return result;
        }

        public async Task<List<BLMonHocChuyenNganh>?> UpdateMHCN(int Id, BLMonHocChuyenNganh monchuyennganh)
        {
            var result = await _context.MonHocChuyenNganhs.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
                return null;
            result.MonHocKhoaId = monchuyennganh.MonHocKhoaId;
            result.NganhHocId = monchuyennganh.NganhHocId;
            result.NamHoc = monchuyennganh.NamHoc;
            await _context.SaveChangesAsync();
            return await _context.MonHocChuyenNganhs.ToListAsync();
        }
    }
}
