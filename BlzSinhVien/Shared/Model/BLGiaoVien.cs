using BlzSinhVien.Shared.Model.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlzSinhVien.Shared.Model
{
    public class BLGiaoVien : BLBase
    {
        [Required]
        public int UsersId { get; set; }
        [JsonIgnore]
        public virtual BLUser Users { get; set; }
        [Required, MinLength(8, ErrorMessage = "Please enter at least 8 characters, dude!")]
        public string MaGiaoVien { get; set; }
        [Required, MinLength(5, ErrorMessage = "Please enter at least 5 characters, dude!")]
        public string FistName { get; set; }
        [Required, MinLength(1, ErrorMessage = "Please enter at least 1 characters, dude!")]
        public string LastName { get; set; }        
        public string TenGiaoVien
        {
            get
            {
                return this.FistName +" "+ this.LastName;
            }
        }
        public DateTime? NgaySinh { get; set; } = DateTime.Now;
        [Required, MinLength(1, ErrorMessage = "Please enter at least 1 characters, dude!")]
        public string GioiTinh { get; set; }
        [Required, Phone]
        public string SoDienThoai { get; set; }
        [Required, MinLength(1, ErrorMessage = "Please enter at least 1 characters, dude!")]
        public string DanToc { get; set; }
        [Required, MinLength(4, ErrorMessage = "Please enter at least 4 characters, dude!")]
        public string DiaChi { get; set; }
        public int KhoaId { get; set; }
        [JsonIgnore]
        public BLKhoa Khoa { get; set; }
        [JsonIgnore]
        public virtual ICollection<BLGiangDuong> GiangDuongs { get; set; } = new List<BLGiangDuong>();
    }
}
