using BlzSinhVien.Server.Data;
using BlzSinhVien.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BlzSinhVien.Server.Service.MonHocKhoaService
{
    public class MonHocKhoaService : IMonHocKhoaService
    {
        private readonly DataContext _context;

        public MonHocKhoaService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BLMonHocKhoa>> CreateGD(BLMonHocKhoa monhockhoa)
        {
            monhockhoa.MonHoc = null;
            _context.MonHocKhoa.Add(monhockhoa);
            await _context.SaveChangesAsync();
            return await _context.MonHocKhoa.ToListAsync();
        }

        public async Task<List<BLMonHocKhoa>?> DeleteGD(int Id)
        {
            var result = await _context.MonHocKhoa.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
            {
                return null;
            }
            _context.MonHocKhoa.Remove(result);
            await _context.SaveChangesAsync();
            return await _context.MonHocKhoa.ToListAsync();
        }

        public async Task<List<BLMonHocKhoa>> Get()
        {
            return await _context.MonHocKhoa.Include(e => e.MonHoc).Include(e=>e.Khoa).ToListAsync();
        }

        public async Task<BLMonHocKhoa?> GetId(int Id)
        {
            var result = await _context.MonHocKhoa.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<List<BLMonHocKhoa>?> UpdateGD(int Id, BLMonHocKhoa monhockhoa)
        {
            var result = await _context.MonHocKhoa.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
                return null;
            monhockhoa.MonHoc = null;
            result.KhoaId = monhockhoa.KhoaId;
            result.MonHocID = monhockhoa.MonHocID;
            result.NamHoc = monhockhoa.NamHoc;
            await _context.SaveChangesAsync();
            return await _context.MonHocKhoa.ToListAsync();
        }
    }
}
