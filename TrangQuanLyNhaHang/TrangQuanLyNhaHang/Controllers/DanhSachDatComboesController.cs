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
    public class DanhSachDatComboesController : Controller
    {
        private NhaHangEntities db = new NhaHangEntities();

        // GET: DanhSachDatComboes
        public ActionResult Index()
        {
            var danhSachDatComboes = db.DanhSachDatComboes.Include(d => d.DatBan).Include(d => d.GoiCombo);
            return View(danhSachDatComboes.ToList());
        }

        // GET: DanhSachDatComboes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSachDatCombo danhSachDatCombo = db.DanhSachDatComboes.Find(id);
            if (danhSachDatCombo == null)
            {
                return HttpNotFound();
            }
            return View(danhSachDatCombo);
        }

        // GET: DanhSachDatComboes/Create
        public ActionResult Create()
        {
            ViewBag.MaDatBan = new SelectList(db.DatBans, "MaDatBan", "MaDatBan");
            ViewBag.MaComBo = new SelectList(db.GoiComboes, "MaCombo", "TenComBo");
            return View();
        }

        // POST: DanhSachDatComboes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaComBo,MaDatBan,SoLuong")] DanhSachDatCombo danhSachDatCombo)
        {
            if (ModelState.IsValid)
            {
                db.DanhSachDatComboes.Add(danhSachDatCombo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDatBan = new SelectList(db.DatBans, "MaDatBan", "MaDatBan", danhSachDatCombo.MaDatBan);
            ViewBag.MaComBo = new SelectList(db.GoiComboes, "MaCombo", "TenComBo", danhSachDatCombo.MaComBo);
            return View(danhSachDatCombo);
        }

        // GET: DanhSachDatComboes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSachDatCombo danhSachDatCombo = db.DanhSachDatComboes.Find(id);
            if (danhSachDatCombo == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDatBan = new SelectList(db.DatBans, "MaDatBan", "MaDatBan", danhSachDatCombo.MaDatBan);
            ViewBag.MaComBo = new SelectList(db.GoiComboes, "MaCombo", "TenComBo", danhSachDatCombo.MaComBo);
            return View(danhSachDatCombo);
        }

        // POST: DanhSachDatComboes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaComBo,MaDatBan,SoLuong")] DanhSachDatCombo danhSachDatCombo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhSachDatCombo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDatBan = new SelectList(db.DatBans, "MaDatBan", "MaDatBan", danhSachDatCombo.MaDatBan);
            ViewBag.MaComBo = new SelectList(db.GoiComboes, "MaCombo", "TenComBo", danhSachDatCombo.MaComBo);
            return View(danhSachDatCombo);
        }

        // GET: DanhSachDatComboes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhSachDatCombo danhSachDatCombo = db.DanhSachDatComboes.Find(id);
            if (danhSachDatCombo == null)
            {
                return HttpNotFound();
            }
            return View(danhSachDatCombo);
        }

        // POST: DanhSachDatComboes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhSachDatCombo danhSachDatCombo = db.DanhSachDatComboes.Find(id);
            db.DanhSachDatComboes.Remove(danhSachDatCombo);
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
