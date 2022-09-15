using BlzSinhVien.Server.Data;
using BlzSinhVien.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BlzSinhVien.Server.Service.SinhVienService
{
    public class SinhVienService : ISinhVienService
    {
        #region API
        private readonly DataContext _context;

        public SinhVienService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BLSinhVien>> Create(BLSinhVien sinhvien)
        {
            if (sinhvien.LopHocId == 0) sinhvien.LopHocId = null;
            _context.SinhViens.Add(sinhvien);
            await _context.SaveChangesAsync();
            var result = await _context.SinhViens.ToListAsync();
            return result;
        }
        public async Task<List<BLSinhVien>> Update(int Id,BLSinhVien sinhvien)
        {
            if (sinhvien.LopHocId == 0) sinhvien.LopHocId = null;
            var itemsv = await _context.SinhViens.FirstOrDefaultAsync(e => e.Id == Id);
            if(itemsv != null)
            {
                itemsv.MaSinhVien = sinhvien.MaSinhVien;
                itemsv.TenSinhVien = sinhvien.TenSinhVien;
                itemsv.NgaySinh = sinhvien.NgaySinh;
                itemsv.GioiTinh = sinhvien.GioiTinh;
                itemsv.DanToc = sinhvien.DanToc;
                itemsv.DiaChi = sinhvien.DiaChi;
                itemsv.SoDienThoai = sinhvien.SoDienThoai;
                itemsv.LopHocId = sinhvien.LopHocId;
            }
            await _context.SaveChangesAsync();
            var result = await _context.SinhViens.ToListAsync();
            return result;
        }

        public async Task<List<BLSinhVien>> Delete(int Id)
        {

            var itemsv = await _context.SinhViens.FirstOrDefaultAsync(e => e.Id == Id);
            if (itemsv != null)
            {
                _context.SinhViens.Remove(itemsv);
                await _context.SaveChangesAsync();
            }
            var result = await _context.SinhViens.ToListAsync();

            return result;
        }

        public async Task<BLSinhVien> GetId(int id)
        {
            var result = await _context.SinhViens.FirstOrDefaultAsync(e => e.Id == id);
            return result;
        }

        public async Task<List<BLSinhVien>> GetSinhVien()
        {
            var result = await _context.SinhViens.ToListAsync();
            result.ForEach(e =>
            {
                if (e.LopHocId == null) { e.LopHocId = 0; }
            });
            return result;
        }
        #endregion

    }
}
