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
    public class NguoiDungsController : Controller
    {
        private QLPhongTroEntities db = new QLPhongTroEntities();

        // GET: NguoiDungs
        public ActionResult Index()
        {
            var nguoiDung = db.NguoiDung.Include(n => n.ChuPhong).Include(n => n.KhachThue);
            return View(nguoiDung.ToList());
        }

        // GET: NguoiDungs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDung.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // GET: NguoiDungs/Create
        public ActionResult Create()
        {
            ViewBag.MaChu = new SelectList(db.ChuPhong, "MaChu", "HoTen");
            ViewBag.MaKhach = new SelectList(db.KhachThue, "MaKhach", "HoTen");
            return View();
        }

        // POST: NguoiDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaiKhoan,MatKhau,VaiTro,MaKhach,MaChu,Email,NgayDangKy,TrangThai,AnhDaiDien")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDung.Add(nguoiDung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChu = new SelectList(db.ChuPhong, "MaChu", "HoTen", nguoiDung.MaChu);
            ViewBag.MaKhach = new SelectList(db.KhachThue, "MaKhach", "HoTen", nguoiDung.MaKhach);
            return View(nguoiDung);
        }

        // GET: NguoiDungs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var nguoiDung = db.NguoiDung.Find(id);
            if (nguoiDung == null)
                return HttpNotFound();

            return View(nguoiDung);
        }


        // POST: NguoiDungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NguoiDung model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Dữ liệu không hợp lệ.";
                return View(model);
            }

            var user = db.NguoiDung.Find(model.TaiKhoan);
            if (user == null)
                return HttpNotFound();

            try
            {
                user.MatKhau = model.MatKhau;
                user.Email = model.Email;

                db.SaveChanges();

                TempData["Success"] = "Cập nhật tài khoản thành công!";
                return RedirectToAction("Edit", new { id = model.TaiKhoan });
            }
            catch
            {
                TempData["Error"] = "Cập nhật thất bại. Vui lòng thử lại.";
                return View(model);
            }
        }


        // GET: NguoiDungs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = db.NguoiDung.Find(id);
            if (nguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(nguoiDung);
        }

        // POST: NguoiDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NguoiDung nguoiDung = db.NguoiDung.Find(id);
            db.NguoiDung.Remove(nguoiDung);
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
