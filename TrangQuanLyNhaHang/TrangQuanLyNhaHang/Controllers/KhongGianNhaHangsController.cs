using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrangQuanLyNhaHang.Models;

using PagedList;
using PagedList.Mvc;
namespace TrangQuanLyNhaHang.Controllers
{
    public class KhongGianNhaHangsController : Controller
    {
        private NhaHangEntities db = new NhaHangEntities();

        // GET: KhongGianNhaHangs
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var khongGianNhaHangs = db.KhongGianNhaHangs.Include(k => k.LoaiKhongGianNhaHang).Include(k => k.TaiKhoan);
            return View(khongGianNhaHangs.ToList().OrderBy(n => n.TenKhongGian).ToPagedList(pageNumber, pageSize));
        }

        // GET: KhongGianNhaHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhongGianNhaHang khongGianNhaHang = db.KhongGianNhaHangs.Find(id);
            if (khongGianNhaHang == null)
            {
                return HttpNotFound();
            }
            return View(khongGianNhaHang);
        }

        // GET: KhongGianNhaHangs/Create
        public ActionResult Create()
        {
            ViewBag.LoaiKhongGian = new SelectList(db.LoaiKhongGianNhaHangs, "MaLoaiKhongGian", "TenLoai");
            ViewBag.NguoiDang = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Email");
            return View();
        }

        // POST: KhongGianNhaHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhongGian,TenKhongGian,HinhAnh,GioiThieu,LoaiKhongGian,NguoiDang,NgayDang")] KhongGianNhaHang khongGianNhaHang)
        {
            if (ModelState.IsValid)
            {
                db.KhongGianNhaHangs.Add(khongGianNhaHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoaiKhongGian = new SelectList(db.LoaiKhongGianNhaHangs, "MaLoaiKhongGian", "TenLoai", khongGianNhaHang.LoaiKhongGian);
            ViewBag.NguoiDang = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Email", khongGianNhaHang.NguoiDang);
            return View(khongGianNhaHang);
        }

        // GET: KhongGianNhaHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhongGianNhaHang khongGianNhaHang = db.KhongGianNhaHangs.Find(id);
            if (khongGianNhaHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiKhongGian = new SelectList(db.LoaiKhongGianNhaHangs, "MaLoaiKhongGian", "TenLoai", khongGianNhaHang.LoaiKhongGian);
            ViewBag.NguoiDang = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Email", khongGianNhaHang.NguoiDang);
            return View(khongGianNhaHang);
        }

        // POST: KhongGianNhaHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhongGian,TenKhongGian,HinhAnh,GioiThieu,LoaiKhongGian,NguoiDang,NgayDang")] KhongGianNhaHang khongGianNhaHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khongGianNhaHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoaiKhongGian = new SelectList(db.LoaiKhongGianNhaHangs, "MaLoaiKhongGian", "TenLoai", khongGianNhaHang.LoaiKhongGian);
            ViewBag.NguoiDang = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Email", khongGianNhaHang.NguoiDang);
            return View(khongGianNhaHang);
        }

        // GET: KhongGianNhaHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhongGianNhaHang khongGianNhaHang = db.KhongGianNhaHangs.Find(id);
            if (khongGianNhaHang == null)
            {
                return HttpNotFound();
            }
            return View(khongGianNhaHang);
        }

        // POST: KhongGianNhaHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhongGianNhaHang khongGianNhaHang = db.KhongGianNhaHangs.Find(id);
            db.KhongGianNhaHangs.Remove(khongGianNhaHang);
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
