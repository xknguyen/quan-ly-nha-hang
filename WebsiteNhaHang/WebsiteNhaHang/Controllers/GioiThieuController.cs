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
        NhaHangEntities db=new NhaHangEntities();
        // GET: GioiThieu
        public ActionResult KhongGianNhaHang()
        {
            return View();
        }

        public ActionResult ThongTinNhaHang()
        {
            return View(db.ThongTinNhaHangs.ToList());
        }
    }
}