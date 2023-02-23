using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlzSinhVien.Shared.Model
{
    public class BLMonHocKhoa : BLBase
    {
        public int KhoaId { get; set; }
        [JsonIgnore]
        public virtual BLKhoa Khoa { get; set; }
        public int MonHocID { get; set; }
        public virtual BLMonHoc MonHoc { get; set; }
        [Required]
        public int NamHoc { get; set; }
    }
}
