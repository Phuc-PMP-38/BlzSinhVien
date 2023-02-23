using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace BlzSinhVien.Shared.Model
{
    public class BLMonHocChuyenNganh : BLBase
    {
        public int NganhHocId { get; set; }
        public virtual BLNganhHoc NganhHoc { get; set; } = new BLNganhHoc();
        public int MonHocKhoaId { get; set; }
        public virtual BLMonHocKhoa MonHocKhoa { get; set; } = new BLMonHocKhoa();
        [JsonIgnore]
        public virtual ICollection<BLGiangDuong> GiangDuongs { get; set; }
        [Required]
        public int NamHoc { get; set; }
    }
}
