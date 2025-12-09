using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_NEt.Models
{
    public class RoomViewModel
    {
        public Phong Phong { get; set; }
        public List<string> AnhPhu { get; set; } = new List<string>(); // Url ảnh
        public string AnhChinh { get; set; } // Url ảnh

    }
}