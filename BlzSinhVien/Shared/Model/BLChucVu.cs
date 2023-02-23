using BlzSinhVien.Shared.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlzSinhVien.Shared.Model
{
    public class BLChucVu : BLBase
    {
        public string MaRole { get; set; }
        public string RoleDesc { get; set; }
        public string TenChucVu { get; set; }
    }
}
