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
        [Required, MaxLength(11, ErrorMessage = "Please enter at least 11 characters, dude!")]
        public string MaSinhVien { get; set; }
        [Required, MinLength(6, ErrorMessage = "Please enter at least 6 characters, dude!")]
        public string FistName { get; set; }
        [Required, MinLength(1, ErrorMessage = "Please enter at least 1 characters, dude!")]
        public string LastName { get; set; }
        public string TenSinhVien
        {
            get
            {
                return this.FistName + " " + this.LastName;
            }
        }
        public DateTime? NgaySinh { get; set; } = DateTime.Today;
        [Required, MinLength(1, ErrorMessage = "Please enter at least 1 characters, dude!")]
        public string GioiTinh { get; set; }
        [Required, MinLength(3, ErrorMessage = "Please enter at least 3 characters, dude!")]
        public string DanToc { get; set; }
        [Required, MinLength(4, ErrorMessage = "Please enter at least 4 characters, dude!")]
        public string DiaChi { get; set; }
        [Required, Phone]
        public string SoDienThoai { get; set; }
        [JsonIgnore]
        public virtual BLLopHoc LopHoc { get; set; }
        public int? LopHocId { get; set; } = 0;
        [JsonIgnore]
        public virtual BLGiaoVien GiaoViens { get; set; }
        public int? GiaoViensId { get; set; } = 0;
        [JsonIgnore]
        public virtual BLUser User { get; set; }
        public int? UserId { get; set; } = 0;
        [JsonIgnore]
        public virtual BLHocKy HocKy { get; set; }
        public int HocKyId { get; set; } = 0;
    }
}
