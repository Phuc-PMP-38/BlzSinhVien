using BlzSinhVien.Server.Data;
using BlzSinhVien.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BlzSinhVien.Server.Service.GiaoVienService
{
    public class GiaoVienService : IGiaoVienService
    {
        private readonly DataContext _context;

        public GiaoVienService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BLGiaoVien>?> Create(BLGiaoVien giaovien,int Id,int IdAdmin)
        {
            giaovien.GiangDuongs = null;
            giaovien.UsersId = Id;
            _context.GiaoViens.Add(giaovien);
            await _context.SaveChangesAsync();
            return await _context.GiaoViens.ToListAsync();
        }

        public async Task<List<BLGiaoVien>?> Delete(int Id)
        {
            var result = await _context.GiaoViens.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
                return null;
            _context.GiaoViens.Remove(result);
            await _context.SaveChangesAsync();
            return await _context.GiaoViens.ToListAsync();
        }

        public async Task<BLGiaoVien?> GetId(int Id)
        {
            var result = await _context.GiaoViens.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
                return null;
            return result;
        }

        public async Task<List<BLGiaoVien>> GetList()
        {
            return await _context.GiaoViens.ToListAsync();
        }

        public async Task<BLGiaoVien?> GetNameGV(string fistname,string lastname)
        {
            var result = await _context.GiaoViens.FirstOrDefaultAsync(e => (e.FistName == fistname || e.LastName == lastname));
            if (result == null)
                return null;
            return result;
        }

        public async Task<List<BLGiaoVien>?> Update(int Id,BLGiaoVien giaovien)
        {
            var result  = await _context.GiaoViens.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
                return null;
            result.UsersId = giaovien.UsersId;
            result.MaGiaoVien = giaovien.MaGiaoVien;
            result.FistName = giaovien.FistName;
            result.LastName = giaovien.LastName;
            result.NgaySinh = giaovien.NgaySinh;
            result.GioiTinh = giaovien.GioiTinh;
            result.SoDienThoai = giaovien.SoDienThoai;
            result.DanToc = giaovien.DanToc;
            result.DiaChi = giaovien.DiaChi;
            result.KhoaId = giaovien.KhoaId;
            await _context.SaveChangesAsync();
            return await _context.GiaoViens.ToListAsync();
        }
    }
}