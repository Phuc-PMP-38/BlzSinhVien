using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlzSinhVien.Shared.Model
{
    public class BLGiangDuong : BLBase
    {
        public string MaHocPhan { get; set; }
        public int GiaoVienId { get; set; }
        [JsonIgnore]
        public virtual BLGiaoVien GiaoVien { get; set; }
        public int LopHocId { get; set; }
        [JsonIgnore]
        public virtual BLLopHoc LopHoc { get; set; }
        public int MonHocChuyenNganhId { get; set; }
        [JsonIgnore]
        public virtual BLMonHocChuyenNganh MonHocChuyenNganh { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int HocKyId { get; set; }
        [JsonIgnore]
        public virtual BLHocKy HocKy { get; set; }
        public string Action {get;set;}
    }   
}
