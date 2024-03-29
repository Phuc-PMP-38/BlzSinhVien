﻿using BlzSinhVien.Server.Data;
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
        public async Task<List<BLChucVu>?> CreateCV(BLChucVu chucvu)
        {
            try
            {
                var CheckName = await _context.ChucVus.FirstOrDefaultAsync(e => e.RoleDesc == chucvu.RoleDesc);
                if(CheckName != null)
                {
                    return null;
                }
                _context.ChucVus.Add(chucvu);
                await _context.SaveChangesAsync();
                return await _context.ChucVus.ToListAsync();
            }
            catch
            {
                return null;
            }
        }
        public async Task<BLChucVu?> CheckName(string name)
        {
            try
            {
                var CheckName = await _context.ChucVus.FirstOrDefaultAsync(e => e.RoleDesc == name);
                if (CheckName == null)
                {
                    return null;
                }
                return CheckName;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<BLChucVu>?> DeleteCV(int Id)
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

        public async Task<List<BLChucVu>?> Get()
        {
            return await _context.ChucVus.ToListAsync();    
        }

        public async Task<BLChucVu?> GetId(int Id)
        {
            var result =await _context.ChucVus.FindAsync(Id);
            if(result == null)
            {
                return null;
            }
            return result;
        }
        public async Task<List<BLChucVu>?> GetMaRole(string Marole)
        {
            var result = await _context.ChucVus.Where(e=>e.MaRole == Marole).ToListAsync();
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<List<BLChucVu>?> UpdateCV(int Id, BLChucVu chucvu)
        {
            try
            {
                var result = await _context.ChucVus.FirstOrDefaultAsync(e=>e.Id == Id);
                if (result == null)
                    return null;
                result.MaRole = chucvu.MaRole;
                result.RoleDesc = chucvu.RoleDesc;
                result.TenChucVu = chucvu.TenChucVu;
                var listuser = await _context.BLUsers.ToListAsync();
                listuser.ForEach(e => { 
                    if(e.ChucVuId == Id)
                    {
                        e.Role = chucvu.RoleDesc;
                    }
                });
                await _context.SaveChangesAsync();
                return await _context.ChucVus.ToListAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
