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



        public ActionResult CreateBooking(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var phong = db.Phong.Find(id);
            if (phong == null)
                return HttpNotFound();

            var model = new HopDongViewModel
            {
                HopDong = new HopDong
                {
                    MaPhong = phong.MaPhong // Lưu id phòng để POST
                },
                Khach = new KhachThue() // Thông tin khách mới
            };

            ViewBag.PhongName = phong.TenPhong;

            // Dịch vụ
            ViewBag.DichVuList = db.DichVu.ToList();

            return View(model);
        }

        // POST: HopDong/CreateBooking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBooking(HopDongViewModel model, string[] SelectedDV)
        {
            if (model.HopDong.NgayKetThuc <= model.HopDong.NgayBatDau)
            {
                ModelState.AddModelError("HopDong.NgayKetThuc", "Ngày kết thúc phải sau ngày bắt đầu.");
            }

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
                    // Thêm khách thuê
                    var khach = new KhachThue
                    {
                        HoTen = model.Khach.HoTen,
                        CCCD = model.Khach.CCCD,
                        SoDT = model.Khach.SoDT,
                        Email = model.Khach.Email,
                        DiaChi = model.Khach.DiaChi,
                        NgaySinh = model.Khach.NgaySinh
                    };
                    db.KhachThue.Add(khach);
                    db.SaveChanges();

                    // Lấy phòng
                    var phong = db.Phong.Find(model.HopDong.MaPhong);
                    if (phong == null || phong.TinhTrang != "Trống")
                    {
                        TempData["Error"] = "Phòng không tồn tại hoặc đã được thuê!";
                        transaction.Rollback();
                        ViewBag.DichVuList = db.DichVu.ToList();
                        ViewBag.PhongName = db.Phong.Find(model.HopDong.MaPhong)?.TenPhong;
                        return View(model);
                    }

                    // Thêm hợp đồng
                    var hopDong = new HopDong
                    {
                        MaPhong = phong.MaPhong,
                        MaKhach = khach.MaKhach,
                        MaChu = phong.MaChu,
                        NgayBatDau = model.HopDong.NgayBatDau,
                        NgayKetThuc = model.HopDong.NgayKetThuc,
                        TienCoc = model.HopDong.TienCoc,
                        TrangThai = "Đang hiệu lực",

                        NguoiTaoDon = (Session["UserId"] != null) ? (int?)Session["UserId"] : null
                    };
                    db.HopDong.Add(hopDong);
                    db.SaveChanges();

                    // Thêm dịch vụ
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

                    // Cập nhật trạng thái phòng
                    phong.TinhTrang = "Đã thuê";
                    db.Entry(phong).State = EntityState.Modified;
                    db.SaveChanges();

                    transaction.Commit();

                    TempData["Success"] = "Đặt phòng thành công!";
                    // Chuyển hướng đến trang Details của HopDong, dùng MaHopDong vừa tạo
                    return RedirectToAction("Details", new { id = hopDong.MaHopDong });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    TempData["Error"] = "Có lỗi xảy ra: " + message;

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

        // GET: HopDongs/Create
        public ActionResult Create()
        {
            ViewBag.MaChu = new SelectList(db.ChuPhong, "MaChu", "HoTen");
            ViewBag.MaKhach = new SelectList(db.KhachThue, "MaKhach", "HoTen");
            ViewBag.MaPhong = new SelectList(db.Phong, "MaPhong", "TenPhong");
            return View();
        }

        // POST: HopDongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
