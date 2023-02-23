using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlzSinhVien.Shared.Model
{ 
    public class BLLopHoc : BLBase
    {
        public string MaLopHoc { get; set; }
        public string TenLopHoc { get; set; }
        public int NganhHocId { get; set; }
        [JsonIgnore]
        public virtual BLNganhHoc NganhHoc { get; set; }
        [JsonIgnore]
        public virtual ICollection<BLSinhVien> SinhViens { get; set; }
        [JsonIgnore]
        public virtual ICollection<BLGiangDuong> GiangDuongs { get; set; }
    }
}
