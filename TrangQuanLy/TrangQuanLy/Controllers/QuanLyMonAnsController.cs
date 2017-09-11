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
    public class QuanLyMonAnsController : Controller
    {
        private NhaHangEntities1 db = new NhaHangEntities1();

        // GET: QuanLyMonAns
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var monAns = db.MonAns.Include(m => m.LoaiMon1);
            return View(monAns.ToList().OrderBy(n => n.TenMon).ToPagedList(pageNumber, pageSize));
        }

        // GET: QuanLyMonAns/Details/5
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

        // GET: QuanLyMonAns/Create
        public ActionResult Create()
        {
            ViewBag.LoaiMon = new SelectList(db.LoaiMons, "MaLoai", "TenLoai");
            return View();
        }

        // POST: QuanLyMonAns/Create
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

        // GET: QuanLyMonAns/Edit/5
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

        // POST: QuanLyMonAns/Edit/5
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

        // GET: QuanLyMonAns/Delete/5
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

        // POST: QuanLyMonAns/Delete/5
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
