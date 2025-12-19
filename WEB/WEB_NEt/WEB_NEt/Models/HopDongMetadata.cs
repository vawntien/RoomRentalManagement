using System;
using System.ComponentModel.DataAnnotations;

namespace WEB_NEt.Models
{
    [MetadataType(typeof(HopDongMetadata))]
    public partial class HopDong
    {
    }

    public class HopDongMetadata
    {
        [Display(Name = "Tiền cọc")]
        [Required(ErrorMessage = "Vui lòng nhập tiền cọc.")]
        [Range(0, double.MaxValue, ErrorMessage = "Tiền cọc không được là số âm.")]
        // Hoặc nếu muốn chặn cứng tối thiểu 2 triệu như trong View cũ:
        // [Range(2000000, double.MaxValue, ErrorMessage = "Tiền cọc tối thiểu 2 triệu.")]
        public Nullable<decimal> TienCoc { get; set; }

        [Display(Name = "Ngày bắt đầu")]
        [Required(ErrorMessage = "Chọn ngày bắt đầu.")]
        public Nullable<System.DateTime> NgayBatDau { get; set; }

        [Display(Name = "Ngày kết thúc")]
        [Required(ErrorMessage = "Chọn ngày kết thúc.")]
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
    }
}