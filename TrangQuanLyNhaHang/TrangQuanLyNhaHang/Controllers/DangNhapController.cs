using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrangQuanLyNhaHang.Models;
using System.IO;
namespace TrangQuanLyNhaHang.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        NhaHangEntities db=new NhaHangEntities();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email,string matKhau)
        {
            var v = db.TaiKhoans.FirstOrDefault(x => x.Email == email && x.MatKhau == matKhau);
            if (v!=null&&(v.LoaiTaiKhoan==1| v.LoaiTaiKhoan == 3))
            {
                Session["MaTaiKhoan"] = v.MaTaiKhoan;
                Session["EmailDangNhap"] = v.Email;
                Session["MatKhauDangNhap"] = v.MatKhau;
                Session["Loai"] = v.LoaiTaiKhoan;
                return RedirectToAction("Index", "QuanLyMonAns");
            }
            Response.StatusCode = 404;
            return null;
        }

        public ActionResult DangKi(TaiKhoan tKhoan, HttpPostedFileBase file)
        {
            //var filename = Path.GetFileName(file.FileName);
            if (ModelState.IsValid)
            {
                //if (filename != null)
                //{
                //    var path = Path.Combine(Server.MapPath("~/Content/img/TaiKhoan"), filename);

                //    if (System.IO.File.Exists(path))
                //    {
                //        filename = "1" + filename;
                //        path = Path.Combine(Server.MapPath("~/Content/img/TaiKhoan"), filename);
                //    }
                //    file.SaveAs(path);
                //}
                if (KiemTra(tKhoan.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại!!");
                }
                else
                {
                    tKhoan.LoaiTaiKhoan = 2;
                    tKhoan.NhoMatKhau = false;
                    //tKhoan.HinhAnh = filename;
                    if (tKhoan.MatKhau == tKhoan.XacNhanMatKhau)
                    {
                        db.TaiKhoans.Add(tKhoan);
                        db.SaveChanges();
                        ViewBag.ThongBao = "Đăng ký tài khoản thành công!!!";
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mật khẩu xác nhận không đúng");

                    }
                }
            }
            return View();
        }
        public bool KiemTra(string email)
        {
            return db.TaiKhoans.Count(n => n.Email == email) > 0;
        }

    }
}