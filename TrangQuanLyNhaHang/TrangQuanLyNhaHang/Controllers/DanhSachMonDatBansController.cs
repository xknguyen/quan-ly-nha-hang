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
    public class DanhSachMonDatBansController : Controller
    {
        private NhaHangEntities db = new NhaHangEntities();

        // GET: DanhSachMonDatBans
        public ActionResult Index()
        {
            var danhSachMonDatBans = db.DanhSachMonDatBans.Include(d => d.DatBan).Include(d => d.MonAn);
            return View(danhSachMonDatBans.ToList());
        }

        // GET: DanhSachMonDatBans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSachMonDatBan danhSachMonDatBan = db.DanhSachMonDatBans.Find(id);
            if (danhSachMonDatBan == null)
            {
                return HttpNotFound();
            }
            return View(danhSachMonDatBan);
        }

        // GET: DanhSachMonDatBans/Create
        public ActionResult Create()
        {
            ViewBag.MaDatBan = new SelectList(db.DatBans, "MaDatBan", "MaDatBan");
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMon", "TenMon");
            return View();
        }

        // POST: DanhSachMonDatBans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDatBan,MaMonAn,SoLuong")] DanhSachMonDatBan danhSachMonDatBan)
        {
            if (ModelState.IsValid)
            {
                db.DanhSachMonDatBans.Add(danhSachMonDatBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDatBan = new SelectList(db.DatBans, "MaDatBan", "MaDatBan", danhSachMonDatBan.MaDatBan);
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMon", "TenMon", danhSachMonDatBan.MaMonAn);
            return View(danhSachMonDatBan);
        }

        // GET: DanhSachMonDatBans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSachMonDatBan danhSachMonDatBan = db.DanhSachMonDatBans.Find(id);
            if (danhSachMonDatBan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDatBan = new SelectList(db.DatBans, "MaDatBan", "MaDatBan", danhSachMonDatBan.MaDatBan);
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMon", "TenMon", danhSachMonDatBan.MaMonAn);
            return View(danhSachMonDatBan);
        }

        // POST: DanhSachMonDatBans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDatBan,MaMonAn,SoLuong")] DanhSachMonDatBan danhSachMonDatBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhSachMonDatBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDatBan = new SelectList(db.DatBans, "MaDatBan", "MaDatBan", danhSachMonDatBan.MaDatBan);
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMon", "TenMon", danhSachMonDatBan.MaMonAn);
            return View(danhSachMonDatBan);
        }

        // GET: DanhSachMonDatBans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSachMonDatBan danhSachMonDatBan = db.DanhSachMonDatBans.Find(id);
            if (danhSachMonDatBan == null)
            {
                return HttpNotFound();
            }
            return View(danhSachMonDatBan);
        }

        // POST: DanhSachMonDatBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhSachMonDatBan danhSachMonDatBan = db.DanhSachMonDatBans.Find(id);
            db.DanhSachMonDatBans.Remove(danhSachMonDatBan);
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
