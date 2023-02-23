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

        public async Task<List<BLSinhVien>?> Create(BLSinhVien sinhvien,int Id)
        {
            if (sinhvien.LopHocId == 0) sinhvien.LopHocId = null;
            if (sinhvien.GiaoViensId == 0) sinhvien.GiaoViensId = null;
            sinhvien.UserId = Id;
            _context.SinhViens.Add(sinhvien);
            await _context.SaveChangesAsync();
            var result = await _context.SinhViens.ToListAsync();
            return result;
        }
        public async Task<List<BLSinhVien>?> Update(int Id,BLSinhVien sinhvien)
        {
            if (sinhvien.LopHocId == 0) sinhvien.LopHocId = null;
            var itemsv = await _context.SinhViens.FirstOrDefaultAsync(e => e.Id == Id);
            if(itemsv != null)
            {
                itemsv.MaSinhVien = sinhvien.MaSinhVien;
                itemsv.FistName = sinhvien.FistName;
                itemsv.LastName = sinhvien.LastName;
                itemsv.NgaySinh = sinhvien.NgaySinh;
                itemsv.GioiTinh = sinhvien.GioiTinh;
                itemsv.DanToc = sinhvien.DanToc;
                itemsv.DiaChi = sinhvien.DiaChi;
                itemsv.SoDienThoai = sinhvien.SoDienThoai;
                itemsv.LopHocId = sinhvien.LopHocId;
                itemsv.HocKyId = sinhvien.HocKyId;
            }
            await _context.SaveChangesAsync();
            var result = await _context.SinhViens.ToListAsync();
            return result;
        }

        public async Task<List<BLSinhVien>?> Delete(int Id)
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

        public async Task<BLSinhVien?> GetId(int id)
        {
            var result = await _context.SinhViens.FirstOrDefaultAsync(e => e.Id == id);
            if (result == null)
                return null;
            return result;
        }

        public async Task<List<BLSinhVien>> GetSinhVien()
        {
            return await _context.SinhViens.ToListAsync();
        }
        #endregion

    }
}
