using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlzSinhVien.Shared.Model
{
    public class BLHocKy : BLBase
    {
        public int HocKyOn { get; set; } // Năm bắt đầu
        public int HocKyIn { get; set; } //Năm kết thúc
        public string HocKy
        {
            get
            {
                return HocKyOn + " - " + HocKyIn;
            }
        }
        public int HocKyOut { get; set; } // dùng vô cái nào - Năm học của SV,Kỳ Học,...
    }
}
