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
    public class KhuyenMaiAdminController : Controller
    {
        private NhaHangEntities db = new NhaHangEntities();

        // GET: KhuyenMaiAdmin
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var khuyenMai = db.KhuyenMai.Include(k => k.TaiKhoan);
            return View(khuyenMai.ToList().ToPagedList(pageNumber, pageSize));
        }

        // GET: KhuyenMaiAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhuyenMai khuyenMai = db.KhuyenMai.Find(id);
            if (khuyenMai == null)
            {
                return HttpNotFound();
            }
            return View(khuyenMai);
        }

        // GET: KhuyenMaiAdmin/Create
        public ActionResult Create()
        {
            ViewBag.NguoiDang = new SelectList(db.TaiKhoan, "MaTaiKhoan", "Email");
            return View();
        }

        // POST: KhuyenMaiAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhuyenMai,TenKhuyenMai,ChiTietKhuyenMai,HinhAnh,NguoiDang,NgayDang,NgayBatDau,NgayKetThuc,TiLeGiamGia")] KhuyenMai khuyenMai)
        {
            if (ModelState.IsValid)
            {
                db.KhuyenMai.Add(khuyenMai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NguoiDang = new SelectList(db.TaiKhoan, "MaTaiKhoan", "Email", khuyenMai.NguoiDang);
            return View(khuyenMai);
        }

        // GET: KhuyenMaiAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhuyenMai khuyenMai = db.KhuyenMai.Find(id);
            if (khuyenMai == null)
            {
                return HttpNotFound();
            }
            ViewBag.NguoiDang = new SelectList(db.TaiKhoan, "MaTaiKhoan", "Email", khuyenMai.NguoiDang);
            return View(khuyenMai);
        }

        // POST: KhuyenMaiAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhuyenMai,TenKhuyenMai,ChiTietKhuyenMai,HinhAnh,NguoiDang,NgayDang,NgayBatDau,NgayKetThuc,TiLeGiamGia")] KhuyenMai khuyenMai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khuyenMai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NguoiDang = new SelectList(db.TaiKhoan, "MaTaiKhoan", "Email", khuyenMai.NguoiDang);
            return View(khuyenMai);
        }

        // GET: KhuyenMaiAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhuyenMai khuyenMai = db.KhuyenMai.Find(id);
            if (khuyenMai == null)
            {
                return HttpNotFound();
            }
            return View(khuyenMai);
        }

        // POST: KhuyenMaiAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhuyenMai khuyenMai = db.KhuyenMai.Find(id);
            db.KhuyenMai.Remove(khuyenMai);
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
