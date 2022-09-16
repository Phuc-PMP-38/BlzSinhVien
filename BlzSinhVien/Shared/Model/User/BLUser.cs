using System.Text.Json.Serialization;

namespace BlzSinhVien.Shared.Model.User
{
    public class BLUser : BLBase
    {
        public string EmailAddress { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string Role { get; set; }
        public DateTime? ResetTokenExpires { get; set; } 
        public virtual BLSinhVien SinhVien { get; set; }
        public int ChucVuId { get; set; }
        [JsonIgnore]
        public virtual BLChucVu ChucVu { get; set; }
    }
}
