using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_NEt.Models
{
   
    [MetadataType(typeof(KhachThueMetadata))]
    public partial class KhachThue
    {
        
    }

    
    public class KhachThueMetadata
    {
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ tên.")]
        public string HoTen { get; set; }

        [Display(Name = "CCCD/CMND")]
        [Required(ErrorMessage = "Vui lòng nhập CCCD.")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "CCCD phải đúng 12 chữ số.")]
        public string CCCD { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "SĐT phải 10 số và bắt đầu bằng số 0.")]
        // ^0: Bắt đầu bằng 0; \d{9}: theo sau là 9 chữ số; $: kết thúc chuỗi
        public string SoDT { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng nhập Email.")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
        public string DiaChi { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh.")]
        public Nullable<System.DateTime> NgaySinh { get; set; }
    }
}