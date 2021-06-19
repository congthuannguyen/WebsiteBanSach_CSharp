
//@ Nguyen Cong Thuan

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.Model;

namespace TestUngDung.Areas.Client.Controllers
{
    public class SalesController : Controller
    {
        NguyenCongThuanContext db;

        public SalesController()
        {
            db = new NguyenCongThuanContext();
        }
        // GET: Client/Products
        public ActionResult Index()
        {

            return View(db.Products.ToList());
        }
    }
}