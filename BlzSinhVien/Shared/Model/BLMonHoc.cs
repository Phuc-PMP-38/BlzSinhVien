using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlzSinhVien.Shared.Model
{
    public class BLMonHoc : BLBase
    {
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int SoTinChi { get; set; }
        public int SoTietLyThuyet { get; set; }
        public int SoTietThucHanh { get; set; }
        [JsonIgnore]
        public virtual ICollection<BLMonHocKhoa> MonHocKhoa { get; set; }
    }
}
