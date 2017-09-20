using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteNhaHang.Models;
using System.Web.Script.Serialization;
namespace WebsiteNhaHang.Controllers
{
    public class DatBanController : Controller
    {
        NhaHangEntities db = new NhaHangEntities();
        // GET: DatBan
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            //kiem tra, khoi tao gio hang
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(int iMaSp,int iLoaiDat,string strURL)
        {
            MonAn monAn = db.MonAns.SingleOrDefault(n => n.MaMon == iMaSp);
            GoiCombo goiCombo = db.GoiComboes.SingleOrDefault(n => n.MaCombo == iMaSp);
            if (monAn == null&&iLoaiDat==1)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (iLoaiDat != 1&& iLoaiDat != 2)
            {
                Response.StatusCode = 404;
                return null;
            }
            if (goiCombo == null && iLoaiDat == 2)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanPham = lstGioHang.Find(n => n.iMaSP == iMaSp&&n.iLoaiDat==iLoaiDat);
            if (sanPham == null)
            {
                sanPham = new GioHang(iMaSp,iLoaiDat);
                lstGioHang.Add(sanPham);
                return Redirect(strURL);
            }
            else
            {
                sanPham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        
        [HttpPost]
        public JsonResult CapNhapSoLuong(int iSoLuong,int iMaSP,int iLoaiDat)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaSP == iMaSP&&n.iLoaiDat==iLoaiDat);
            if(sanpham!=null)
            {
                sanpham.iSoLuong = iSoLuong;
            }
            
            return Json(new
            {
                status = true
            });
        }
        [HttpPost]
        public JsonResult XoaGioHang(int iMaSP,int iLoaiDat)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanPham = lstGioHang.SingleOrDefault(n => n.iMaSP == iMaSP&& n.iLoaiDat == iLoaiDat);
            if (sanPham != null)
            {
                lstGioHang.RemoveAll(n => n.iMaSP == iMaSP && n.iLoaiDat == iLoaiDat);
                
            }
            return Json(new
            {
                status = true
            });
        }
        [HttpPost]
        public JsonResult XoaTatCa()
        {
            Session.Remove("GioHang");
            return Json(new
            {
                status = true
            });
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"]==null)
            {
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            ViewBag.TongTien = TongTien();
            return View(lstGioHang);
        }
        private int TongSoLuong()
        {
            int tongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return tongSoLuong;
        }
        private double TongTien()
        {
            double tongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tongTien = lstGioHang.Sum(n => n.dThanhTien);
            }
            return tongTien;
        }
        public PartialViewResult tongSoLuong()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            return PartialView();
        }
        
    }
}