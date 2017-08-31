﻿using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteNhaHang.Models;
using PagedList;
using PagedList.Mvc;
namespace WebsiteNhaHang.Controllers
{
    public class ComboController : Controller
    {
        NhaHangEntities1 db=new NhaHangEntities1();
        // GET: Combo
        public ActionResult GoiCombo(int ?page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 6;
            return View(db.GoiComboes.ToList().OrderBy(n => n.TenComBo).ToPagedList(pageNumber, pageSize));
        }
        public PartialViewResult ComboDatNhieu()
        {
            return PartialView(db.GoiComboes.Take(3).OrderBy(n => n.SoLanDat).ToList());
        }

        public ActionResult DemCombo()
        {
            ViewBag.DemCombo= db.GoiComboes.Count();
            return View();
        }


    }
}