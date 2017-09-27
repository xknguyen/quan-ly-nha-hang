using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteNhaHang.Models;

namespace TrangAdmin.Controllers
{
    public class MonAnsController : Controller
    {
        private NhaHangEntities db = new NhaHangEntities();

        // GET: MonAns
        public ActionResult Index()
        {
            var monAn = db.MonAns.Include(m => m.LoaiMon1);
            return View(monAn.ToList());
        }

        // GET: MonAns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            return View(monAn);
        }

        // GET: MonAns/Create
        public ActionResult Create()
        {
            ViewBag.LoaiMon = new SelectList(db.LoaiMons, "MaLoai", "TenLoai");
            return View();
        }

        // POST: MonAns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMon,TenMon,LoaiMon,HinhAnh,Gia,ChiTiet,SoLuotDat")] MonAn monAn)
        {
            if (ModelState.IsValid)
            {
                db.MonAns.Add(monAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoaiMon = new SelectList(db.LoaiMons, "MaLoai", "TenLoai", monAn.LoaiMon);
            return View(monAn);
        }

        // GET: MonAns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiMon = new SelectList(db.LoaiMons, "MaLoai", "TenLoai", monAn.LoaiMon);
            return View(monAn);
        }

        // POST: MonAns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMon,TenMon,LoaiMon,HinhAnh,Gia,ChiTiet,SoLuotDat")] MonAn monAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LoaiMon = new SelectList(db.LoaiMons, "MaLoai", "TenLoai", monAn.LoaiMon);
            return View(monAn);
        }

        // GET: MonAns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            return View(monAn);
        }

        // POST: MonAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MonAn monAn = db.MonAns.Find(id);
            db.MonAns.Remove(monAn);
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
