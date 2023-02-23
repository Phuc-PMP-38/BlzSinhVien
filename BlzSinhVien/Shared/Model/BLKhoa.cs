using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlzSinhVien.Shared.Model
{
    public class BLKhoa : BLBase
    {
        public string TenKhoa { get; set; }
        [JsonIgnore]
        public virtual ICollection<BLNganhHoc> NganhHoc { get; set; }
    }
}
