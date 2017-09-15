using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrangQuanLyNhaHang.Models;

namespace TrangQuanLyNhaHang.Content
{
    public class GoiComboesController : Controller
    {
        private NhaHangEntities db = new NhaHangEntities();

        // GET: GoiComboes
        public ActionResult Index()
        {
            return View(db.GoiComboes.ToList());
        }

        // GET: GoiComboes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoiCombo goiCombo = db.GoiComboes.Find(id);
            if (goiCombo == null)
            {
                return HttpNotFound();
            }
            return View(goiCombo);
        }

        // GET: GoiComboes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GoiComboes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCombo,TenComBo,HinhAnh,Gia,GioiThieu,SoLanDat")] GoiCombo goiCombo)
        {
            if (ModelState.IsValid)
            {
                db.GoiComboes.Add(goiCombo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(goiCombo);
        }

        // GET: GoiComboes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoiCombo goiCombo = db.GoiComboes.Find(id);
            if (goiCombo == null)
            {
                return HttpNotFound();
            }
            return View(goiCombo);
        }

        // POST: GoiComboes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCombo,TenComBo,HinhAnh,Gia,GioiThieu,SoLanDat")] GoiCombo goiCombo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goiCombo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goiCombo);
        }

        // GET: GoiComboes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoiCombo goiCombo = db.GoiComboes.Find(id);
            if (goiCombo == null)
            {
                return HttpNotFound();
            }
            return View(goiCombo);
        }

        // POST: GoiComboes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GoiCombo goiCombo = db.GoiComboes.Find(id);
            db.GoiComboes.Remove(goiCombo);
            //db.SaveChanges();
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
