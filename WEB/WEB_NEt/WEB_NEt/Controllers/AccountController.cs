using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity; // Cần cho .Include()
using WEB_NEt.Models; // Đảm bảo bạn đã import Models

namespace WEB_NEt.Controllers
{
    public class AccountController : Controller
    {
        private QLPhongTroEntities db = new QLPhongTroEntities();

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // === 1. Kiểm tra xem Tài khoản hoặc Email đã tồn tại chưa ===
            if (db.NguoiDung.Any(u => u.TaiKhoan == model.TaiKhoan))
            {
                ModelState.AddModelError("TaiKhoan", "Tên tài khoản này đã tồn tại.");
                return View(model);
            }
            if (db.KhachThue.Any(k => k.Email == model.Email))
            {
                ModelState.AddModelError("Email", "Email này đã được sử dụng.");
                return View(model);
            }

            // === 2. Dùng Transaction để tạo cả KhachThue và NguoiDung ===
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // a. Tạo KhachThue trước
                    var khach = new KhachThue
                    {
                        HoTen = model.HoTen,
                        SoDT = model.SoDT,
                        Email = model.Email,
                        CCCD = model.CCCD,
                        NgaySinh = model.NgaySinh
                        // (Các trường khác có thể null hoặc có giá trị default)
                    };
                    db.KhachThue.Add(khach);
                    db.SaveChanges(); // Lưu để lấy được khach.MaKhach

                    // b. Tạo NguoiDung (Tài khoản)
                    var nguoiDung = new NguoiDung
                    {
                        TaiKhoan = model.TaiKhoan,
                        MatKhau = model.MatKhau, // !! Sẽ cần mã hóa mật khẩu sau
                        Email = model.Email,
                        MaKhach = khach.MaKhach, // <-- Liên kết với KhachThue
                        VaiTro = "User", // Mặc định là User
                        TrangThai = "Hoạt động"
                    };
                    db.NguoiDung.Add(nguoiDung);
                    db.SaveChanges();

                    // c. Hoàn tất
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    // Ghi log lỗi (ex.Message)
                    ModelState.AddModelError("", "Đã có lỗi xảy ra trong quá trình đăng ký.");
                    return View(model);
                }
            }

            TempData["Success"] = "Đăng ký tài khoản thành công! Bạn có thể đăng nhập ngay bây giờ.";
            return RedirectToAction("Login"); // Chuyển hướng đến trang Đăng nhập
        }

        // Tạm thời tạo action Login (chưa code) để Redirect ở trên hoạt động
        // (Bên trong file AccountController.cs)

        // GET: Account/Login (Bạn đã có action này, giờ cập nhật nó)
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // === 1. Kiểm tra người dùng trong CSDL ===
            // (Trong dự án thực tế, bạn PHẢI MÃ HÓA mật khẩu)
            var user = db.NguoiDung
                         .Include(u => u.KhachThue) // Lấy luôn thông tin KhachThue
                         .FirstOrDefault(u => u.TaiKhoan == model.TaiKhoan && u.MatKhau == model.MatKhau);

            if (user == null)
            {
                ModelState.AddModelError("", "Sai tên đăng nhập hoặc mật khẩu.");
                return View(model);
            }

            if (user.TrangThai == "Khóa")
            {
                ModelState.AddModelError("", "Tài khoản này đã bị khóa.");
                return View(model);
            }

            // === 2. Lưu thông tin vào SESSION ===
            Session["UserAccount"] = user;
            Session["UserName"] = user.KhachThue?.HoTen ?? user.TaiKhoan; // Ưu tiên Họ tên
            Session["UserId"] = user.MaKhach; // Quan trọng: Dùng cho Nhiệm vụ 3
            Session["UserRole"] = user.VaiTro; // (Admin / User)

            // (Lưu ý: ASP.NET Identity dùng Cookie, nhưng Session đơn giản hơn cho bạn)

            // === 3. Chuyển hướng ===
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                // Nếu là Admin thì về trang Dashboard (nếu có)
                // if (user.VaiTro == "Admin") 
                //     return RedirectToAction("Index", "Admin");

                // User thường thì về trang chủ
                return RedirectToAction("Index", "Home");
            }
        }

        //
        // POST: Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Clear(); // Xóa tất cả Session
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        // GET: Account/MyRooms (Đây là trang "Phòng đã thuê")
        public ActionResult MyRooms()
        {
            // 1. KIỂM TRA ĐĂNG NHẬP
            // Kiểm tra xem Session có "UserId" (MaKhach) không
            if (Session["UserId"] == null)
            {
                // Nếu không có, bắt họ đăng nhập.
                // "returnUrl" sẽ tự động đưa họ về trang này sau khi đăng nhập thành công.
                return RedirectToAction("Login", "Account",
                    new { returnUrl = Url.Action("MyRooms", "Account") });
            }

            // 2. LẤY MÃ KHÁCH
            // Chúng ta đã lưu MaKhach vào Session["UserId"] lúc đăng nhập
            var maKhachHienTai = (int)Session["UserId"];

            // 3. TRUY VẤN CSDL
            // Lấy tất cả hợp đồng của khách này, VÀ lấy kèm thông tin "Phong"
            var myContracts = db.HopDong
                         .Include(h => h.Phong)
                         // Logic: Lấy hợp đồng mà tôi là người ở (MaKhach) 
                         // HOẶC hợp đồng mà tôi là người tạo đơn (NguoiTaoDon)
                         .Where(h => h.MaKhach == maKhachHienTai || h.NguoiTaoDon == maKhachHienTai)
                         .OrderByDescending(h => h.NgayBatDau)
                         .ToList();

            // 4. GỬI DỮ LIỆU SANG VIEW
            return View(myContracts);
        }
    }
}