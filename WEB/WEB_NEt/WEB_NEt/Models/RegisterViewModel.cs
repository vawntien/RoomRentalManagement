using System;
using System.ComponentModel.DataAnnotations;

namespace WEB_NEt.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập CCCD")]
        public string CCCD { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string SoDT { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime? NgaySinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên tài khoản")]
        public string TaiKhoan { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        [DataType(DataType.Password)]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu và mật khẩu xác nhận không khớp.")]
        public string XacNhanMatKhau { get; set; }
    }
}