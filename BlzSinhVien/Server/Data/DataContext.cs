using BlzSinhVien.Shared.Model;
using BlzSinhVien.Shared.Model.User;
using Microsoft.EntityFrameworkCore;

namespace BlzSinhVien.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<BLSinhVien> SinhViens { get; set; }
        public DbSet<BLLopHoc> LopHocs { get; set; }
        public DbSet<BLUser> BLUsers { get; set; }
        public DbSet<BLChucVu> ChucVus { get; set; }
    }
}
