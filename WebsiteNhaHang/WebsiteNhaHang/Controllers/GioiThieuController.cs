using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteNhaHang.Models;
namespace WebsiteNhaHang.Controllers
{
    public class GioiThieuController : Controller
    {
        NhaHangEntities1 db=new NhaHangEntities1();
        // GET: GioiThieu
        public ActionResult KhongGianNhaHang()
        {   
            return View(db.LoaiKhongGianNhaHangs.OrderBy(n=>n.TenLoai).ToList());
        }

        public ActionResult ThongTinNhaHang()
        {            
            return View(db.ThongTinNhaHangs.ToList());
        }
        public ActionResult ThongTinNhaHang1()
        {
            return View(db.ThongTinNhaHangs.ToList());
        }
    }
}