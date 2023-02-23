using BlzSinhVien.Shared.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlzSinhVien.Shared.Model
{
    public class BLImage : BLBase
    {
        public string? FileName { get; set; } = string.Empty;
        public string? StoredFileName { get; set; } = string.Empty;
        public string? ContentType { get; set; } = string.Empty;

    }
}
