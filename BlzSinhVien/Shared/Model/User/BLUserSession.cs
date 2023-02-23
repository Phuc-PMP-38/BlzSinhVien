using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlzSinhVien.Shared.Model.User
{
    public class BLUserSession : BLBase 
    {
        public string EmailAddress { get; set; }
        public string Role { get; set; }
        public virtual BLSinhVien SinhVien { get; set; }
        public virtual BLGiaoVien GiaoVien { get; set; }
    }
}
