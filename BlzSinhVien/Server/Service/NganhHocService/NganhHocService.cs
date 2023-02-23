using BlzSinhVien.Server.Data;
using BlzSinhVien.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BlzSinhVien.Server.Service.NganhHocService
{
    public class NganhHocService : INganhHocService
    {
        private readonly DataContext _context;

        public NganhHocService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BLNganhHoc>?> CreateNH(BLNganhHoc nganhhoc)
        {
            var result = await _context.NganhHocs.FirstOrDefaultAsync(e => e.TenNganh == nganhhoc.TenNganh);
            if (result != null)
                return null;
            _context.NganhHocs.Add(nganhhoc);
            await _context.SaveChangesAsync();
            return await _context.NganhHocs.ToListAsync();
        }

        public async Task<List<BLNganhHoc>?> DeleteNH(int Id)
        {
            var result = await _context.NganhHocs.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
                return null;
            _context.NganhHocs.Remove(result);
            await _context.SaveChangesAsync();
            return await _context.NganhHocs.ToListAsync();
        }

        public async Task<List<BLNganhHoc>> Get()
        {
            return await _context.NganhHocs.ToListAsync();
        }

        public async Task<BLNganhHoc?> GetId(int Id)
        {
            var result = await _context.NganhHocs.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
                return null;
            return result;
        }

        public async Task<List<BLNganhHoc>?> UpdateNH(int Id, BLNganhHoc nganhhoc)
        {
            var result = await _context.NganhHocs.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
                return null;
            result.TenNganh = nganhhoc.TenNganh;
            await _context.SaveChangesAsync();
            return await _context.NganhHocs.ToListAsync();
        }
    }
}
