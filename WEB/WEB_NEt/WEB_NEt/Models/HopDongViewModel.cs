using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_NEt.Models
{
    public class HopDongViewModel
    {
        public HopDong HopDong { get; set; }

        // Thông tin khách thuê mới
        public KhachThue Khach { get; set; } = new KhachThue();

        // Danh sách dịch vụ được chọn khi booking
        public List<string> SelectedDV { get; set; } = new List<string>();
    }
}