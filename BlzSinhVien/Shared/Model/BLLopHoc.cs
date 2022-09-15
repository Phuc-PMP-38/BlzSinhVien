using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlzSinhVien.Shared.Model
{ 
    public class BLLopHoc : BLBase
    {
        public string MaLopHoc { get; set; }
        public string TenLopHoc { get; set; }
        public virtual ICollection<BLSinhVien> SinhViens { get; set; }
    }
}
