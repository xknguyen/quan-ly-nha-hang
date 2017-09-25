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
    public class QuanLyMonAnsController : Controller
    {
        private NhaHangEntities db = new NhaHangEntities();

        // GET: QuanLyMonAns
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            //using (db)
            //{
            //    var lop = db.MonAns.ToList();
            //    foreach (var id in QuanLyMonAnsController)
            //    {
            //        Console.WriteLine(id.);
            //    }
            //}
            var monAns = db.MonAns;
            return View(monAns.ToList().OrderBy(n => n.TenMon).ToPagedList(pageNumber, pageSize));
        }
        // Ajax POST: /Checkout/UseShippingAddress/5
        [HttpPost]
        public ActionResult UseShippingAddress(int id)
        {
            return Content("It worked!");
        }
        public ActionResult GetData()
        {
            using (NhaHangEntities db = new NhaHangEntities())
            {
                var monAnList = db.MonAns.ToList<MonAn>();
                return Json(new { data = monAnList }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddOrSua(int id = 0)
        {
            return View(new MonAn());
        }
        [HttpPost]
        public ActionResult AddOrSua()
        {
            return View();
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
