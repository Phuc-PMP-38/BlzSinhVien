using BlzSinhVien.Server.Data;
using BlzSinhVien.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BlzSinhVien.Server.Service.LopHocService
{
    public class LopHocService : ILopHocService
    {
        private readonly DataContext _context;

        public LopHocService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BLLopHoc>?> CreateLH(BLLopHoc lophoc)
        {
            try
            {
                lophoc.SinhViens = new List<BLSinhVien>();
                _context.LopHocs.Add(lophoc);
                await _context.SaveChangesAsync();
                return await _context.LopHocs.ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<BLLopHoc>?> DeleteLH(int Id)
        {
            var result = await _context.LopHocs.FindAsync(Id);
            if (result == null)
            {
                return null;
            }
            _context.LopHocs.Remove(result);
            await _context.SaveChangesAsync();
            return await _context.LopHocs.ToListAsync();
        }

        public async Task<List<BLLopHoc>> Get()
        {
            var result = await _context.LopHocs.ToListAsync();
            return result;
        }
        public async Task<BLLopHoc?> GetId(int Id)
        {
            var result = await _context.LopHocs.FindAsync(Id);
            if(result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<List<BLLopHoc>?> UpdateLH(int Id, BLLopHoc lophoc)
        {
            try
            {
                var result = await _context.LopHocs.FindAsync(Id);
                if (result == null)
                    return null;
                result.TenLopHoc = lophoc.TenLopHoc;
                result.MaLopHoc = lophoc.MaLopHoc;
                result.NganhHocId = lophoc.NganhHocId;
                await _context.SaveChangesAsync();
                return await _context.LopHocs.ToListAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
