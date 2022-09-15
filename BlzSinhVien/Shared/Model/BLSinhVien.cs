using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using BlzSinhVien.Shared.Model.User;

namespace BlzSinhVien.Shared.Model
{
    public class BLSinhVien : BLBase
    {
        [Required]
        public string MaSinhVien { get; set; }
        [Required]
        public string TenSinhVien { get; set; }
        public DateTime? NgaySinh { get; set; } = DateTime.Today;
        [Required]
        public string GioiTinh { get; set; }
        [Required]
        public string DanToc { get; set; }
        [Required]
        public string DiaChi { get; set; }
        [Required]
        public string SoDienThoai { get; set; }
        [JsonIgnore]
        public virtual BLLopHoc LopHoc { get; set; }
        public int? LopHocId { get; set; }
        [JsonIgnore]
        public virtual BLUser User { get; set; }
        public int? UserId { get; set; }
    }
}
