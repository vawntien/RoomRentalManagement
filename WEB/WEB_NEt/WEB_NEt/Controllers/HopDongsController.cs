using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEB_NEt.Models;

namespace WEB_NEt.Controllers
{
    public class HopDongsController : Controller
    {
        private QLPhongTroEntities db = new QLPhongTroEntities();

        // GET: CreateBooking (Form đặt phòng)
        public ActionResult CreateBooking(string id)
        {
            if (Session["UserAccount"] == null )
            {
                return RedirectToAction("Login", "Account");
            }    
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var phong = db.Phong.Find(id);
            if (phong == null)
                return HttpNotFound();

            var model = new HopDongViewModel
            {
                HopDong = new HopDong
                {
                    MaPhong = phong.MaPhong // Lưu id phòng
                },
                Khach = new KhachThue() // Object khách mới để điền form
            };

            ViewBag.PhongName = phong.TenPhong;
            ViewBag.DichVuList = db.DichVu.ToList();

            return View(model);
        }

        // POST: CreateBooking (Xử lý lưu dữ liệu)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBooking(HopDongViewModel model, string[] SelectedDV)
        {
            // 1. Validate ngày tháng
            if (model.HopDong.NgayKetThuc <= model.HopDong.NgayBatDau)
            {
                ModelState.AddModelError("HopDong.NgayKetThuc", "Ngày kết thúc phải sau ngày bắt đầu.");
            }

            // 2. Nếu Model không hợp lệ, trả về View
            if (!ModelState.IsValid)
            {
                ViewBag.DichVuList = db.DichVu.ToList();
                ViewBag.PhongName = db.Phong.Find(model.HopDong.MaPhong)?.TenPhong;
                return View(model);
            }

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // --- BƯỚC 1: XỬ LÝ KHÁCH THUÊ (Đã sửa lỗi trùng lặp) ---
                    int maKhachSuDung;

                    // Kiểm tra xem trong DB đã có ai mang số CCCD này chưa
                    var khachTonTai = db.KhachThue.FirstOrDefault(k => k.CCCD == model.Khach.CCCD);

                    if (khachTonTai != null)
                    {
                        // Nếu ĐÃ CÓ: Cập nhật thông tin mới nhất và dùng lại ID cũ
                        khachTonTai.HoTen = model.Khach.HoTen;
                        khachTonTai.SoDT = model.Khach.SoDT;
                        khachTonTai.Email = model.Khach.Email;
                        khachTonTai.DiaChi = model.Khach.DiaChi;
                        khachTonTai.NgaySinh = model.Khach.NgaySinh;

                        db.Entry(khachTonTai).State = EntityState.Modified;
                        db.SaveChanges(); // Lưu cập nhật

                        maKhachSuDung = khachTonTai.MaKhach;
                    }
                    else
                    {
                        // Nếu CHƯA CÓ: Tạo mới hoàn toàn
                        var khachMoi = new KhachThue
                        {
                            HoTen = model.Khach.HoTen,
                            CCCD = model.Khach.CCCD,
                            SoDT = model.Khach.SoDT,
                            Email = model.Khach.Email,
                            DiaChi = model.Khach.DiaChi,
                            NgaySinh = model.Khach.NgaySinh
                        };
                        db.KhachThue.Add(khachMoi);
                        db.SaveChanges(); // Lưu để sinh ID

                        maKhachSuDung = khachMoi.MaKhach;
                    }

                    // --- BƯỚC 2: KIỂM TRA PHÒNG ---
                    var phong = db.Phong.Find(model.HopDong.MaPhong);
                    if (phong == null || phong.TinhTrang != "Trống")
                    {
                        TempData["Error"] = "Phòng không tồn tại hoặc đã được thuê!";
                        transaction.Rollback();

                        ViewBag.DichVuList = db.DichVu.ToList();
                        ViewBag.PhongName = db.Phong.Find(model.HopDong.MaPhong)?.TenPhong;
                        return View(model);
                    }

                    // --- BƯỚC 3: TẠO HỢP ĐỒNG ---
                    var hopDong = new HopDong
                    {
                        MaPhong = phong.MaPhong,
                        MaKhach = maKhachSuDung, // Sử dụng ID khách vừa xử lý ở trên
                        MaChu = phong.MaChu,
                        NgayBatDau = model.HopDong.NgayBatDau,
                        NgayKetThuc = model.HopDong.NgayKetThuc,
                        TienCoc = model.HopDong.TienCoc,
                        TrangThai = "Đang hiệu lực",
                        NguoiTaoDon = (Session["UserId"] != null) ? (int?)Session["UserId"] : null
                    };
                    db.HopDong.Add(hopDong);
                    db.SaveChanges();

                    // --- BƯỚC 4: THÊM DỊCH VỤ ---
                    if (SelectedDV != null)
                    {
                        foreach (var dvId in SelectedDV)
                        {
                            var hddv = new HopDongDichVu
                            {
                                MaHopDong = hopDong.MaHopDong,
                                MaDV = dvId,
                                SoLuong = 1
                            };
                            db.HopDongDichVu.Add(hddv);
                        }
                        db.SaveChanges();
                    }

                    // --- BƯỚC 5: CẬP NHẬT TRẠNG THÁI PHÒNG ---
                    phong.TinhTrang = "Đã thuê";
                    db.Entry(phong).State = EntityState.Modified;
                    db.SaveChanges();

                    // Hoàn tất mọi thứ
                    transaction.Commit();

                    TempData["Success"] = "Đặt phòng thành công!";
                    return RedirectToAction("MyRooms","Account");
                }
                catch (Exception ex)
                {
                    // Gặp lỗi thì hoàn tác toàn bộ database
                    transaction.Rollback();

                    // Lấy thông báo lỗi chi tiết nhất
                    string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    TempData["Error"] = "Có lỗi xảy ra: " + message;

                    // Load lại dữ liệu để hiện lại form
                    ViewBag.DichVuList = db.DichVu.ToList();
                    ViewBag.PhongName = db.Phong.Find(model.HopDong.MaPhong)?.TenPhong;
                    return View(model);
                }
            }
        }

        // GET: HopDongs
        public ActionResult Index()
        {
            var hopDong = db.HopDong.Include(h => h.ChuPhong).Include(h => h.KhachThue).Include(h => h.Phong);
            return View(hopDong.ToList());
        }

        // GET: HopDongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HopDong hopDong = db.HopDong.Find(id);
            if (hopDong == null)
            {
                return HttpNotFound();
            }
            return View(hopDong);
        }

        // GET: HopDongs/Create (Tạo thủ công qua Admin - giữ nguyên logic cũ)
        public ActionResult Create()
        {
            ViewBag.MaChu = new SelectList(db.ChuPhong, "MaChu", "HoTen");
            ViewBag.MaKhach = new SelectList(db.KhachThue, "MaKhach", "HoTen");
            ViewBag.MaPhong = new SelectList(db.Phong, "MaPhong", "TenPhong");
            return View();
        }

        // POST: HopDongs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHopDong,MaPhong,MaKhach,MaChu,NgayBatDau,NgayKetThuc,TienCoc,TrangThai,NgayTao")] HopDong hopDong)
        {
            if (ModelState.IsValid)
            {
                db.HopDong.Add(hopDong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChu = new SelectList(db.ChuPhong, "MaChu", "HoTen", hopDong.MaChu);
            ViewBag.MaKhach = new SelectList(db.KhachThue, "MaKhach", "HoTen", hopDong.MaKhach);
            ViewBag.MaPhong = new SelectList(db.Phong, "MaPhong", "TenPhong", hopDong.MaPhong);
            return View(hopDong);
        }

        // GET: HopDongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HopDong hopDong = db.HopDong.Find(id);
            if (hopDong == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChu = new SelectList(db.ChuPhong, "MaChu", "HoTen", hopDong.MaChu);
            ViewBag.MaKhach = new SelectList(db.KhachThue, "MaKhach", "HoTen", hopDong.MaKhach);
            ViewBag.MaPhong = new SelectList(db.Phong, "MaPhong", "TenPhong", hopDong.MaPhong);
            return View(hopDong);
        }

        // POST: HopDongs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHopDong,MaPhong,MaKhach,MaChu,NgayBatDau,NgayKetThuc,TienCoc,TrangThai,NgayTao")] HopDong hopDong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hopDong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChu = new SelectList(db.ChuPhong, "MaChu", "HoTen", hopDong.MaChu);
            ViewBag.MaKhach = new SelectList(db.KhachThue, "MaKhach", "HoTen", hopDong.MaKhach);
            ViewBag.MaPhong = new SelectList(db.Phong, "MaPhong", "TenPhong", hopDong.MaPhong);
            return View(hopDong);
        }

        // GET: HopDongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HopDong hopDong = db.HopDong.Find(id);
            if (hopDong == null)
            {
                return HttpNotFound();
            }
            return View(hopDong);
        }

        // POST: HopDongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HopDong hopDong = db.HopDong.Find(id);
            db.HopDong.Remove(hopDong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}