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
    public class ComboAdminController : Controller
    {
        private NhaHangEntities db = new NhaHangEntities();

        // GET: GoiComboes
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(db.GoiCombo.ToList().ToPagedList(pageNumber, pageSize));
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
                db.GoiCombo.Add(goiCombo);
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
            GoiCombo goiCombo = db.GoiCombo.Find(id);
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
            if (Convert.ToInt32(Session["LoaiTK"]) == 3)
            {
                return RedirectToAction("Index");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GoiCombo goiCombo = db.GoiCombo.Find(id);
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
            GoiCombo goiCombo = db.GoiCombo.Find(id);
            db.GoiCombo.Remove(goiCombo);
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
