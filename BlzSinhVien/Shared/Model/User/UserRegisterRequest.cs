using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlzSinhVien.Shared.Model.User
{
    public class UserRegisterRequest 
    {
        [Required, EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        [Required, MinLength(6, ErrorMessage = "Please enter at least 6 characters, dude!")]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Role { get; set; }
        public int ChucVuId { get; set; }
        public string MaRole { get; set; }
        public virtual BLSinhVien SinhVien { get; set; } = new BLSinhVien();
    }
}
