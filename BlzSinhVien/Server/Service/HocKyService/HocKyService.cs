using BlzSinhVien.Server.Data;
using BlzSinhVien.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BlzSinhVien.Server.Service.HocKyService
{
    public class HocKyService : IHocKyService
    {
        private readonly DataContext _context;

        public HocKyService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BLHocKy>?> CreateHK(BLHocKy hocky)
        {
            try
            {
                _context.HocKys.Add(hocky);
                await _context.SaveChangesAsync();
                return await _context.HocKys.ToListAsync();
            }catch
            {
                return null;
            }
            
        }

        public async Task<List<BLHocKy>?> DeleteHK(int Id)
        {
            var request = await _context.HocKys.FirstOrDefaultAsync(e => e.Id == Id);
            if (request != null)
            {
                _context.HocKys.Remove(request);
                await _context.SaveChangesAsync();
                return await _context.HocKys.ToListAsync();
            }
            return null;
                
        }

        public async Task<List<BLHocKy>> Get()
        {
            return await _context.HocKys.ToListAsync();
        }

        public async Task<BLHocKy?> GetId(int Id)
        {
            var request = await _context.HocKys.FirstOrDefaultAsync(e => e.Id == Id);
            if (request != null)
                return request;
            return null;
        }

        public async Task<List<BLHocKy>?> UpdateHK(int Id, BLHocKy hocky)
        {
            var request = await _context.HocKys.FirstOrDefaultAsync(e => e.Id == Id);
            if (request != null)
            {
                request.HocKyOn = hocky.HocKyOn;
                request.HocKyIn = hocky.HocKyIn;
                request.HocKyOut = hocky.HocKyOut;
                await _context.SaveChangesAsync();
                return await _context.HocKys.ToListAsync();
            }
            return null;
        }
    }
}
