using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteNhaHang.Models;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity;
using System.Net;

namespace WebsiteNhaHang.Controllers
{
    public class TaiKhoanAdminController : Controller
    {
        NhaHangEntities db = new NhaHangEntities();
        // GET: TaiKhoanAdmin
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(string email, string matkhau)
        {
            if (ModelState.IsValid)
            {
                var v = db.TaiKhoans.FirstOrDefault(x => x.Email == email && x.MatKhau == matkhau);
                if (v != null&&v.LoaiTaiKhoan!=2)
                {
                    Session["EmailDangNhap"] = v.Email;
                    Session["MaTaiKhoan"] = v.MaTaiKhoan;
                    Session["LoaiTK"] = v.LoaiTaiKhoan;
                    return Redirect("/TaiKhoanAdmin/TaiKhoanChiTiet");
                }
                ViewBag.Message = "Nhập sai mật khẩu hoặc email!!";
            }

            return View();
        }
        public RedirectResult DangXuat()
        {
            //Session["EmailDangNhap"] = null;
            //Session["MatKhauDangNhap"] = null;
            Session.Remove("EmailDangNhap");
            Session.Remove("MaTaiKhoan");
            Session.Remove("LoaiTK");

            return Redirect("/TaiKhoanAdmin/DangNhap");
        }
        public ActionResult TaiKhoan()
        {
            string email = Session["EmailDangNhap"].ToString();
            var v = db.TaiKhoans.FirstOrDefault(n => n.Email == email);
            //var v = db.TaiKhoans.FirstOrDefault(n => n.MaTaiKhoan == Int32.Parse(Session["MaTaiKhoan"].ToString()));
            if (v == null)
            {
                return null;
            }
            return View(v);
        }
        public ViewResult TaiKhoanChiTiet()
        {
            int c = Convert.ToInt32(Session["MaTaiKhoan"]);
            int b = Convert.ToInt32(Session["LoaiTK"]);
            if (Session["MaTaiKhoan"] == null||b==2)
            {
                Response.StatusCode = 404;
                return null;
            }
            var a=db.TaiKhoans.FirstOrDefault(n => n.MaTaiKhoan == c);
            return View(a);
        }
        public ViewResult DanhSachTaikhoan(int? page)
        {
            if (KiemTraLoai())
            {
                int pageNumber = (page ?? 1);
                int pageSize = 5;
                var taiKhoan = db.TaiKhoans;
                return View(taiKhoan.ToList().OrderBy(n => n.MaTaiKhoan).ToPagedList(pageNumber, pageSize));
            }
            Response.StatusCode = 404;
            return null;
        }
        public ActionResult Create()
        {
            if (KiemTraLoai())
            {
                ViewBag.LoaiTaiKhoan = new SelectList(db.LoaiTaiKhoans, "MaLoaiTaiKhoan", "TenLoaiTaiKhoan");
                return View();
            }
            Response.StatusCode = 404;
            return null;
            
        }

        // POST: TaiKhoans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTaiKhoan,Email,MatKhau,XacNhanMatKhau,NhoMatKhau,LoaiTaiKhoan,TenNguoiDung,HinhAnh,DiaChi,SoDienThoai")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoans.Add(taiKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LoaiTaiKhoan = new SelectList(db.LoaiTaiKhoans, "MaLoaiTaiKhoan", "TenLoaiTaiKhoan", taiKhoan.LoaiTaiKhoan);
            return View(taiKhoan);
        }

        // GET: TaiKhoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null&&KiemTraLoai()==false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaiTaiKhoan = new SelectList(db.LoaiTaiKhoans, "MaLoaiTaiKhoan", "TenLoaiTaiKhoan", taiKhoan.LoaiTaiKhoan);
            return View(taiKhoan);
        }

        // POST: TaiKhoans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTaiKhoan,Email,MatKhau,XacNhanMatKhau,NhoMatKhau,LoaiTaiKhoan,TenNguoiDung,HinhAnh,DiaChi,SoDienThoai")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSachTaikhoan");
            }
            ViewBag.LoaiTaiKhoan = new SelectList(db.LoaiTaiKhoans, "MaLoaiTaiKhoan", "TenLoaiTaiKhoan", taiKhoan.LoaiTaiKhoan);
            return View(taiKhoan);
        }

        // GET: TaiKhoans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null && KiemTraLoai() == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: TaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            db.TaiKhoans.Remove(taiKhoan);
            db.SaveChanges();
            return RedirectToAction("DanhSachTaikhoan");
        }
        public bool KiemTraLoai()
        {
            bool a = int.Parse(Session["LoaiTK"].ToString()) == 1;
            return a;
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