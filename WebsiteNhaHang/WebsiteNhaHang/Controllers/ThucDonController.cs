using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteNhaHang.Models;
using PagedList;
using PagedList.Mvc;

namespace WebsiteNhaHang.Controllers
{
    public class ThucDonController : Controller
    {
        NhaHangEntities db=new NhaHangEntities();
        // GET: ThucDon
        public ActionResult ThucDon(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            return View(db.MonAns.ToList().OrderBy(n=>n.TenMon).ToPagedList(pageNumber,pageSize));
        }
        public PartialViewResult MonDuocDatNhieu()
        {
            return PartialView(db.MonAns.Take(3).OrderBy(n => n.SoLuotDat).ToList());
        }
    }
}