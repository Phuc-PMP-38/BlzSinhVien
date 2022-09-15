using BlzSinhVien.Server.Data;
using BlzSinhVien.Shared.Model;
using BlzSinhVien.Shared.Model.User;
using Microsoft.EntityFrameworkCore;

namespace BlzSinhVien.Server.Service.ChucVuService
{
    public class ChucVuService : IChucVuService
    {
        private readonly DataContext _context;

        public ChucVuService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<BLChucVu>> CreateCV(BLChucVu chucvu)
        {
            try
            {
                chucvu.Users = new List<BLUser>();
                _context.ChucVus.Add(chucvu);
                await _context.SaveChangesAsync();
                return await _context.ChucVus.ToListAsync();
            }
            catch
            {
                return await _context.ChucVus.ToListAsync();
            }
        }

        public async Task<List<BLChucVu>> DeleteCV(int Id)
        {
            var result = await _context.ChucVus.FindAsync(Id);
            if (result == null)
            {
                return null;
            }
            _context.Remove(result);
            await _context.SaveChangesAsync();
            return await _context.ChucVus.ToListAsync();
        }

        public async Task<List<BLChucVu>> Get()
        {
            return await _context.ChucVus.ToListAsync();    
        }

        public async Task<BLChucVu> GetId(int Id)
        {
            var result =await _context.ChucVus.FindAsync(Id);
            if(result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<List<BLChucVu>> UpdateCV(int Id, BLChucVu chucvu)
        {
            try
            {
                var result = await _context.ChucVus.FindAsync(Id);
                if (result == null)
                    return await _context.ChucVus.ToListAsync();
                result.RoleDesc = chucvu.RoleDesc;
                await _context.SaveChangesAsync();
                return await _context.ChucVus.ToListAsync();
            }
            catch
            {
                return await _context.ChucVus.ToListAsync();
            }
        }
    }
}
