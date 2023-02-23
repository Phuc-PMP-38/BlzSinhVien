using BlzSinhVien.Server.Data;
using BlzSinhVien.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BlzSinhVien.Server.Service.KhoaService
{
    public class KhoaService : IKhoaService
    {
        private readonly DataContext _context;

        public KhoaService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BLKhoa>> CreateKhoa(BLKhoa khoa)
        {
            _context.Khoa.Add(khoa);
            await _context.SaveChangesAsync();
            return await _context.Khoa.ToListAsync();
        }

        public async Task<List<BLKhoa>?> DeleteKhoa(int Id)
        {
            var result = await _context.Khoa.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
                return null;
            _context.Khoa.Remove(result);
            await _context.SaveChangesAsync();
            return await _context.Khoa.ToListAsync();
        }

        public async Task<List<BLKhoa>> Get()
        {
            return await _context.Khoa.ToListAsync();
        }

        public async Task<BLKhoa?> GetId(int Id)
        {
            var result = await _context.Khoa.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
                return null;
            return result;
        }

        public async Task<List<BLKhoa>?> UpdateKhoa(int Id, BLKhoa khoa)
        {
            var result = await _context.Khoa.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
                return null;
            result.TenKhoa = khoa.TenKhoa;
            await _context.SaveChangesAsync();
            return await _context.Khoa.ToListAsync();
        }
    }
}
