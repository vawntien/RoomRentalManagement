using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WEB_NEt.Models;

namespace WEB_NEt.Controllers
{
    public class RoomController : Controller
    {
        private QLPhongTroEntities db = new QLPhongTroEntities();

        // GET: Room
        public ActionResult Index(int page = 1, string keyword = "", string loaiphong = "")
        {
            int pageSize = 10;

            var rooms = db.Phong.AsQueryable();

            // Chỉ lấy phòng còn trống
            rooms = rooms.Where(r => r.TinhTrang == "Trống");

            // Lọc theo keyword (tên phòng hoặc địa chỉ)
            if (!string.IsNullOrEmpty(keyword))
            {
                rooms = rooms.Where(r => r.TenPhong.Contains(keyword));
            }

            // Lọc theo loại phòng
            if (!string.IsNullOrEmpty(loaiphong))
            {
                rooms = rooms.Where(r => r.LoaiPhong == loaiphong);
            }

            rooms = rooms.OrderBy(r => r.MaPhong);

            var totalRooms = rooms.Count();

            var pagedRooms = rooms.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Convert sang RoomViewModel
            var models = pagedRooms.Select(r => new RoomViewModel
            {
                Phong = r,
                AnhChinh = "/dataphong/" + r.AnhChinh,
                AnhPhu = db.AnhPhong.Where(a => a.MaPhong == r.MaPhong)
                                    .Select(a => "/dataphong/" + a.UrlHinhAnh)
                                    .ToList()
            }).ToList();

            // Danh sách loại phòng để hiển thị filter
            ViewBag.LoaiPhongList = db.Phong.Select(r => r.LoaiPhong).Distinct().ToList();
            ViewBag.SelectedLoaiPhong = loaiphong;
            ViewBag.Keyword = keyword;

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRooms / pageSize);
            ViewBag.CurrentPage = page;

            return View(models);
        }


        // GET: Room/Details/5
        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var room = db.Phong.Find(id); // db.Phong.MaPhong là string
            if (room == null)
                return HttpNotFound();

            // Lấy danh sách ảnh phụ
            var anhPhu = db.AnhPhong
                           .Where(a => a.MaPhong == id)
                           .OrderBy(a => a.MaAnh)
                           .Select(a => "/dataphong/" + a.UrlHinhAnh)
                           .ToList();

            var model = new RoomViewModel
            {
                Phong = room,
                AnhPhu = anhPhu
            };

            return View(model);
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            ViewBag.MaChu = new SelectList(db.ChuPhong, "MaChu", "HoTen");
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhong,TenPhong,DienTich,GiaPhong,TinhTrang,SoNguoiToiDa,AnhChinh,MoTaChiTiet,NoiThat,CoGac,Tang,LoaiPhong,MaChu")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                db.Phong.Add(phong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChu = new SelectList(db.ChuPhong, "MaChu", "HoTen", phong.MaChu);
            return View(phong);
        }

        // GET: Room/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phong phong = db.Phong.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChu = new SelectList(db.ChuPhong, "MaChu", "HoTen", phong.MaChu);
            return View(phong);
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhong,TenPhong,DienTich,GiaPhong,TinhTrang,SoNguoiToiDa,AnhChinh,MoTaChiTiet,NoiThat,CoGac,Tang,LoaiPhong,MaChu")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChu = new SelectList(db.ChuPhong, "MaChu", "HoTen", phong.MaChu);
            return View(phong);
        }

        // GET: Room/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phong phong = db.Phong.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            return View(phong);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Phong phong = db.Phong.Find(id);
            db.Phong.Remove(phong);
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
