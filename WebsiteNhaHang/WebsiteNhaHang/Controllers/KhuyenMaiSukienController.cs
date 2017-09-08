using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteNhaHang.Models;

namespace WebsiteNhaHang.Controllers
{
    public class KhuyenMaiSukienController : Controller
    {
        NhaHangEntities db = new NhaHangEntities();
        // GET: KhuyenMai
        public ActionResult KhuyenMai()
        {   
            return View(db.KhuyenMais.OrderBy(n => n.NgayDang).ToList());
        }
        public ActionResult SuKien()
        {
            return PartialView(db.SuKiens.OrderBy(n => n.NgayDang).ToList());
        }
        public ActionResult DemSuKien_KhuyenMai()
        {
            ViewBag.dem= db.KhuyenMais.Count() + db.SuKiens.Count();
            return PartialView();
        }
        public PartialViewResult AnhGioiThieu()
        {
            return  PartialView(db.KhuyenMais.Take(2).ToList());
        }
        public PartialViewResult AnhSuKien()
        {       
            return PartialView(db.SuKiens.Take(2).ToList());
        }
    }
}