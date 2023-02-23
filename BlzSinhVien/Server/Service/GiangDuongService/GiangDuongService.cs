using BlzSinhVien.Server.Data;
using BlzSinhVien.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BlzSinhVien.Server.Service.GiangDuongService
{
    public class GiangDuongService : IGiangDuongService
    {
        private readonly DataContext _context;

        public GiangDuongService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BLGiangDuong>> CreateGD(BLGiangDuong giangduong)
        {
            _context.GiangDuongs.Add(giangduong);
            await _context.SaveChangesAsync();
            return await _context.GiangDuongs.ToListAsync();
        }

        public async Task<List<BLGiangDuong>?> DeleteGD(int Id)
        {
            var result = await _context.GiangDuongs.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
                return null;
            _context.GiangDuongs.Remove(result);
            await _context.SaveChangesAsync();
            return await _context.GiangDuongs.ToListAsync();
        }

        public async Task<List<BLGiangDuong>> Get()
        {
            return await _context.GiangDuongs.ToListAsync();
        }

        public async Task<BLGiangDuong?> GetId(int Id)
        {
            var result = await _context.GiangDuongs.FirstOrDefaultAsync(e => e.Id == Id);
            if(result ==null)
                return null;
            return result;
        }

        public async Task<List<BLGiangDuong>?> UpdateGD(int Id, BLGiangDuong giangduong)
        {
            var result = await _context.GiangDuongs.FirstOrDefaultAsync(e => e.Id == Id);
            if (result == null)
                return null;
            result.GiaoVienId = giangduong.GiaoVienId;
            result.LopHocId = giangduong.LopHocId;
            result.MonHocChuyenNganhId = giangduong.MonHocChuyenNganhId;
            result.StartDate = giangduong.StartDate;
            result.EndDate = giangduong.EndDate;
            result.HocKy = giangduong.HocKy;
            result.Action = giangduong.Action;
            await _context.SaveChangesAsync();
            return await _context.GiangDuongs.ToListAsync();
        }
    }
}
