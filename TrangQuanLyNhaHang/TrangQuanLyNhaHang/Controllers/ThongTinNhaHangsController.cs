using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrangQuanLyNhaHang.Models;

namespace TrangQuanLyNhaHang.Controllers
{
    public class ThongTinNhaHangsController : Controller
    {
        private NhaHangEntities db = new NhaHangEntities();

        // GET: ThongTinNhaHangs
        public ActionResult Index()
        {
            var thongTinNhaHangs = db.ThongTinNhaHangs;
            return View(thongTinNhaHangs.ToList());
        }

        // GET: ThongTinNhaHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinNhaHang thongTinNhaHang = db.ThongTinNhaHangs.Find(id);
            if (thongTinNhaHang == null)
            {
                return HttpNotFound();
            }
            return View(thongTinNhaHang);
        }

        // GET: ThongTinNhaHangs/Create
        public ActionResult Create()
        {
            ViewBag.NguoiDang = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Email");
            return View();
        }

        // POST: ThongTinNhaHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaThongTin,NguoiDang,URLMap,TenNhaHang,DiaChi,Email,SoDienThoai1,SoDienThoai2,ThongTinKhac")] ThongTinNhaHang thongTinNhaHang)
        {
            if (ModelState.IsValid)
            {
                db.ThongTinNhaHangs.Add(thongTinNhaHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NguoiDang = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Email", thongTinNhaHang.NguoiDang);
            return View(thongTinNhaHang);
        }

        // GET: ThongTinNhaHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinNhaHang thongTinNhaHang = db.ThongTinNhaHangs.Find(id);
            if (thongTinNhaHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.NguoiDang = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Email", thongTinNhaHang.NguoiDang);
            return View(thongTinNhaHang);
        }

        // POST: ThongTinNhaHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaThongTin,NguoiDang,URLMap,TenNhaHang,DiaChi,Email,SoDienThoai1,SoDienThoai2,ThongTinKhac")] ThongTinNhaHang thongTinNhaHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongTinNhaHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NguoiDang = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Email", thongTinNhaHang.NguoiDang);
            return View(thongTinNhaHang);
        }

        // GET: ThongTinNhaHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinNhaHang thongTinNhaHang = db.ThongTinNhaHangs.Find(id);
            if (thongTinNhaHang == null)
            {
                return HttpNotFound();
            }
            return View(thongTinNhaHang);
        }

        // POST: ThongTinNhaHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongTinNhaHang thongTinNhaHang = db.ThongTinNhaHangs.Find(id);
            db.ThongTinNhaHangs.Remove(thongTinNhaHang);
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
