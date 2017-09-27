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
namespace WebsiteNhaHang.Controllers
{
    public class SuKiensAdminController : Controller
    {
        private NhaHangEntities db = new NhaHangEntities();

        // GET: SuKiensAdmin
        public ActionResult Index(int? page)
        {         
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var suKien = db.SuKien.Include(s => s.TaiKhoan);
            return View(suKien.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: SuKiensAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuKien suKien = db.SuKien.Find(id);
            if (suKien == null)
            {
                return HttpNotFound();
            }
            return View(suKien);
        }

        // GET: SuKiensAdmin/Create
        public ActionResult Create()
        {
            ViewBag.NguoiDang = new SelectList(db.TaiKhoan, "MaTaiKhoan", "Email");
            return View();
        }

        // POST: SuKiensAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSuKien,TenSuKien,NgayBatDau,NgayKetThuc,NgayDang,HinhAnh,ChiTiet,NguoiDang")] SuKien suKien)
        {
            if (ModelState.IsValid)
            {
                db.SuKien.Add(suKien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NguoiDang = new SelectList(db.TaiKhoan, "MaTaiKhoan", "Email", suKien.NguoiDang);
            return View(suKien);
        }

        // GET: SuKiensAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuKien suKien = db.SuKien.Find(id);
            if (suKien == null)
            {
                return HttpNotFound();
            }
            ViewBag.NguoiDang = new SelectList(db.TaiKhoan, "MaTaiKhoan", "Email", suKien.NguoiDang);
            return View(suKien);
        }

        // POST: SuKiensAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSuKien,TenSuKien,NgayBatDau,NgayKetThuc,NgayDang,HinhAnh,ChiTiet,NguoiDang")] SuKien suKien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suKien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NguoiDang = new SelectList(db.TaiKhoan, "MaTaiKhoan", "Email", suKien.NguoiDang);
            return View(suKien);
        }

        // GET: SuKiensAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuKien suKien = db.SuKien.Find(id);
            if (suKien == null)
            {
                return HttpNotFound();
            }
            return View(suKien);
        }

        // POST: SuKiensAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuKien suKien = db.SuKien.Find(id);
            db.SuKien.Remove(suKien);
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
