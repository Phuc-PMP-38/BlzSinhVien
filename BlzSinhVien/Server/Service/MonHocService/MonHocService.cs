using BlzSinhVien.Server.Data;
using BlzSinhVien.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BlzSinhVien.Server.Service.MonHocService
{
    public class MonHocService : IMonHocService
    {
        private readonly DataContext _context;

        public MonHocService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<BLMonHoc>?> CreatMH(BLMonHoc monhoc)
        {
            var result = await _context.MonHocs.FirstOrDefaultAsync(e => e.TenMonHoc == monhoc.TenMonHoc);
            if (result != null)
            {
                return null;
            }
            _context.MonHocs.Add(monhoc);
            await _context.SaveChangesAsync();
            return await _context.MonHocs.ToListAsync();
        }

        public async Task<List<BLMonHoc>?> DeleteMh(int Id)
        {
            var result = await _context.MonHocs.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
            {
                return null;
            }
            _context.MonHocs.Remove(result);
            await _context.SaveChangesAsync();
            return await _context.MonHocs.ToListAsync();
        }

        public async Task<List<BLMonHoc>> Get()
        {
            return await _context.MonHocs.ToListAsync();
        }

        public async Task<BLMonHoc?> GetId(int Id)
        {
            var result = await _context.MonHocs.FirstOrDefaultAsync(e => e.Id == Id);
            if(result== null)
            {
                return null;
            }
            return result;
        }

        public async Task<List<BLMonHoc>?> UpdateMH(int Id, BLMonHoc monhoc)
        {
            var result = await _context.MonHocs.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
            {
                return null;
            }
            result.MaMonHoc = monhoc.MaMonHoc;
            result.TenMonHoc = monhoc.TenMonHoc;
            result.SoTietLyThuyet = monhoc.SoTietLyThuyet;
            result.SoTinChi = monhoc.SoTinChi;
            result.SoTietThucHanh = monhoc.SoTietThucHanh;
            await _context.SaveChangesAsync();
            return await _context.MonHocs.ToListAsync();
        }
    }
}
