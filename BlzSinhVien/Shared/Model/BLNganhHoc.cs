using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlzSinhVien.Shared.Model
{
    public class BLNganhHoc : BLBase
    {
       
        public string TenNganh { get; set; }
        public int KhoaId { get; set; }
        [JsonIgnore]
        public virtual BLKhoa Khoa { get; set; }
        [JsonIgnore]
        public virtual ICollection<BLMonHocChuyenNganh> MonHocChuyenNganh { get; set; }
        [JsonIgnore]
        public virtual ICollection<BLLopHoc> LopHoc { get; set; }

    }
}
