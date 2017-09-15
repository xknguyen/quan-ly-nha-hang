using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrangQuanLyNhaHang.Models;

namespace TrangQuanLyNhaHang.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuenMK()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(TaiKhoan maTaiKhoan)
        {
            NhaHangEntities matk=new NhaHangEntities();
            matk.TaiKhoans.Add(maTaiKhoan);
            matk.SaveChanges();
            string message = string.Empty;
            switch (maTaiKhoan.MaTaiKhoan)
            {
                case -1:
                    message = "Username already exists.\\nPlease choose a different Email.";
                    break;
                case -2:
                    message = "Supplied email address has already been used.";
                    break;
                default:
                    message = "Registration successful.\\nUser Id: " + maTaiKhoan.MaTaiKhoan.ToString();
                    break;
            }
            ViewBag.Message = message;
            return View(maTaiKhoan);
        }

    }
}