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
        public DbSet<BLNganhHoc> NganhHocs { get; set; }
        public DbSet<BLMonHocChuyenNganh> MonHocChuyenNganhs { get; set; }
        public DbSet<BLMonHocKhoa> MonHocKhoa { get; set; }
        public DbSet<BLKhoa> Khoa { get; set; }
        public DbSet<BLMonHoc> MonHocs { get; set; }
        public DbSet<BLGiaoVien> GiaoViens { get; set; }
        public DbSet<BLHocKy> HocKys { get; set; }
        public DbSet<BLImage> Images { get; set; }
        public DbSet<BLGiangDuong> GiangDuongs { get; set; }
    }
}
