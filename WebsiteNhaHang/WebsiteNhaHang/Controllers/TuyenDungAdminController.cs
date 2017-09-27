using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteNhaHang.Models;


using PagedList;
using PagedList.Mvc;

namespace TrangAdmin.Controllers
{
    public class TuyenDungAdminController : Controller
    {
        private NhaHangEntities db = new NhaHangEntities();

        // GET: TuyenDungAdmin
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var tuyenDung = db.TuyenDungs.Include(t => t.TaiKhoan);
            return View(tuyenDung.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: TuyenDungAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuyenDung tuyenDung = db.TuyenDungs.Find(id);
            if (tuyenDung == null)
            {
                return HttpNotFound();
            }
            return View(tuyenDung);
        }

        // GET: TuyenDungAdmin/Create
        public ActionResult Create()
        {
            ViewBag.NguoiDang = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Email");
            return View();
        }

        // POST: TuyenDungAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTuyenDung,TenTuyenDung,NgayDang,NgayBatDau,NgayKetThuc,ChiTiet,NguoiDang")] TuyenDung tuyenDung)
        {
            if (ModelState.IsValid)
            {
                db.TuyenDungs.Add(tuyenDung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NguoiDang = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Email", tuyenDung.NguoiDang);
            return View(tuyenDung);
        }

        // GET: TuyenDungAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuyenDung tuyenDung = db.TuyenDungs.Find(id);
            if (tuyenDung == null)
            {
                return HttpNotFound();
            }
            ViewBag.NguoiDang = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Email", tuyenDung.NguoiDang);
            return View(tuyenDung);
        }

        // POST: TuyenDungAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTuyenDung,TenTuyenDung,NgayDang,NgayBatDau,NgayKetThuc,ChiTiet,NguoiDang")] TuyenDung tuyenDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tuyenDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NguoiDang = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Email", tuyenDung.NguoiDang);
            return View(tuyenDung);
        }

        // GET: TuyenDungAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TuyenDung tuyenDung = db.TuyenDungs.Find(id);
            if (tuyenDung == null)
            {
                return HttpNotFound();
            }
            return View(tuyenDung);
        }

        // POST: TuyenDungAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TuyenDung tuyenDung = db.TuyenDungs.Find(id);
            db.TuyenDungs.Remove(tuyenDung);
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
