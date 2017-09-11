using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrangQuanLy.Models;
using PagedList;
using PagedList.Mvc;

namespace TrangQuanLy.Controllers
{
    public class DatBansController : Controller
    {
        private NhaHangEntities1 db = new NhaHangEntities1();

        // GET: DatBans
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var datBans = db.DatBans.Include(d => d.KieuDatBan1).Include(d => d.TaiKhoan);
            return View(datBans.ToList().OrderBy(n => n.MaDatBan).ToPagedList(pageNumber, pageSize));
        }

        // GET: DatBans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatBan datBan = db.DatBans.Find(id);
            if (datBan == null)
            {
                return HttpNotFound();
            }
            return View(datBan);
        }

        // GET: DatBans/Create
        public ActionResult Create()
        {
            ViewBag.KieuDatBan = new SelectList(db.KieuDatBans, "MaKieuDatBan", "TenKieuDat");
            ViewBag.MaKhachHang = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Email");
            return View();
        }

        // POST: DatBans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDatBan,NgayDatBan,MaKhachHang,NgayThucHien,KieuDatBan,SoNguoi,TongTien")] DatBan datBan)
        {
            if (ModelState.IsValid)
            {
                db.DatBans.Add(datBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KieuDatBan = new SelectList(db.KieuDatBans, "MaKieuDatBan", "TenKieuDat", datBan.KieuDatBan);
            ViewBag.MaKhachHang = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Email", datBan.MaKhachHang);
            return View(datBan);
        }

        // GET: DatBans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatBan datBan = db.DatBans.Find(id);
            if (datBan == null)
            {
                return HttpNotFound();
            }
            ViewBag.KieuDatBan = new SelectList(db.KieuDatBans, "MaKieuDatBan", "TenKieuDat", datBan.KieuDatBan);
            ViewBag.MaKhachHang = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Email", datBan.MaKhachHang);
            return View(datBan);
        }

        // POST: DatBans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDatBan,NgayDatBan,MaKhachHang,NgayThucHien,KieuDatBan,SoNguoi,TongTien")] DatBan datBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KieuDatBan = new SelectList(db.KieuDatBans, "MaKieuDatBan", "TenKieuDat", datBan.KieuDatBan);
            ViewBag.MaKhachHang = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Email", datBan.MaKhachHang);
            return View(datBan);
        }

        // GET: DatBans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatBan datBan = db.DatBans.Find(id);
            if (datBan == null)
            {
                return HttpNotFound();
            }
            return View(datBan);
        }

        // POST: DatBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatBan datBan = db.DatBans.Find(id);
            db.DatBans.Remove(datBan);
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
