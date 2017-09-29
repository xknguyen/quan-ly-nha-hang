using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteNhaHang.Models;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Net.Mail;
using System.Text;

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
            MonAn monAn = db.MonAn.SingleOrDefault(n => n.MaMon == iMaSp);
            GoiCombo goiCombo = db.GoiCombo.SingleOrDefault(n => n.MaCombo == iMaSp);
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
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            //GioHang sanPham = lstGioHang.SingleOrDefault(n => n.iMaSP == iMaSP&& n.iLoaiDat == iLoaiDat);
            //if (sanPham != null)
            //{
                lstGioHang.RemoveAll(n => n.iMaSP == iMaSP && n.iLoaiDat == iLoaiDat);
                Session["GioHang"] = lstGioHang;
            //}
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
        [HttpPost]
        public ActionResult ThanhToan(int soNguoi, DateTime ngayAn)
        {
            int i = 0;
            if (Session["MaTaiKhoan"] == null)
            {               
                return Json("Bạn cần đăng nhập trước khi đặt bàn!");
            }
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            var datBan = new DatBan();         
            datBan.MaKhachHang = int.Parse(Session["MaTaiKhoan"].ToString());
            datBan.NgayDatBan = DateTime.Now;
            datBan.NgayThucHien = ngayAn;
            datBan.TongTien = TongTien();
            datBan.SoNguoi = soNguoi;
            db.DatBan.Add(datBan);
            db.SaveChanges();
            foreach (var item in lstGioHang)
            {                
                if (item.iLoaiDat == 1)
                {
                    var dsMonAn = new DanhSachMonDatBan();
                    dsMonAn.MaMonAn = item.iMaSP;
                    dsMonAn.SoLuong = item.iSoLuong;
                    dsMonAn.MaDatBan = datBan.MaDatBan;
                    dsMonAn.KieuDatBan = 1;
                    db.DanhSachMonDatBan.Add(dsMonAn);
                    var f = db.MonAn.FirstOrDefault(n => n.MaMon == item.iMaSP);
                    f.SoLuotDat++;
                    db.MonAn.Add(f);
                    db.SaveChanges();
                }
                if (item.iLoaiDat == 2)
                {
                    var dsCombo = new DanhSachDatCombo();
                    dsCombo.MaDatBan = datBan.MaDatBan;
                    dsCombo.MaCombo = item.iMaSP;
                    dsCombo.KieuDatBan = 2;
                    dsCombo.SoLuong = item.iSoLuong;
                    db.DanhSachDatCombo.Add(dsCombo);
                    var d = db.GoiCombo.FirstOrDefault(n => n.MaCombo == item.iMaSP);
                    d.SoLanDat++;
                    db.GoiCombo.Add(d);
                    db.SaveChanges();
                }
            }
            string email = Session["EmailDangNhap"].ToString();
            string nhaHang = db.ThongTinNhaHang.FirstOrDefault().TenNhaHang;
            string soDienThoai = db.TaiKhoan.FirstOrDefault(n => n.MaTaiKhoan == datBan.MaKhachHang).SoDienThoai;
            string diaChi = db.TaiKhoan.FirstOrDefault(n => n.MaTaiKhoan == datBan.MaKhachHang).DiaChi;
            string nguoiDang = db.TaiKhoan.FirstOrDefault(n => n.MaTaiKhoan == datBan.MaKhachHang).TenNguoiDung;
            StringBuilder Body = new StringBuilder();
            Body.Append("<p>Cảm ơn quý khách " + nguoiDang+ " đã sử dụng dịch vụ đặt hàng online của nhà hàng " +nhaHang+"</p>");
            Body.Append("<table>");
            Body.Append("<tr><td colspan='2'><h4>Thông tin hóa đơn:</h4></td></tr>");
            Body.Append("<tr><td>Người đặt:</td><td>"+email+"</td></tr>");
            Body.Append("<tr><td>Số điện thoại:</td><td>"+ soDienThoai+"</td></tr>");
            Body.Append("<tr><td>Địa chỉ:</td><td>"+diaChi+"</td></tr>");
            Body.Append("<tr><td>Ngày đặt:</td><td>" + DateTime.Now + "</td></tr>");
            Body.Append("<tr><td>Ngày đến:</td><td>" + ngayAn + "</td></tr>");
            Body.Append("<tr><td>#</td><td>Loại</td><td>Tên món</td><td>Số lượng</td><td>&nbsp;Thành tiền </td></tr>");

            foreach (var item in lstGioHang)
            {
                string loaiDat = db.KieuDatBan.FirstOrDefault(n => n.MaKieuDatBan == item.iLoaiDat).TenKieuDat;
                i++;
                Body.Append("<tr><td>"+i+ "</td><td>" + loaiDat + "</td><td>" + item.sTenSp + "</td><td><p>&nbsp;&nbsp;" + item.iSoLuong + "</p></td><td>" + item.dThanhTien + " VND &nbsp;</td></tr>");
            }
            Body.Append("<tr><td>Tổng tiền:</td><td>" + TongTien() + " VND</td></tr>");            
            Body.Append("</table>");

            MailMessage mail = new MailMessage();
            string emaiNhaHang = db.ThongTinNhaHang.FirstOrDefault().Email;
            mail.To.Add(email);
            mail.To.Add(emaiNhaHang);
            mail.From = new MailAddress("Chuotdong1995@gmail.com");
            mail.Subject = "Hoá đơn đặt hàng.";//tiêu đề mail
            mail.Body = Body.ToString();// phần thân của mail ở trên
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential("Chuotdong1995@gmail.com", "0979641823");// tài khoản Gmail người gửi
            smtp.EnableSsl = true;
            smtp.Send(mail);
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