
//@ Nguyen Cong Thuan

//using Microsoft.VisualStudio.TestPlatform.CoreUtilities;
using MobilePhoneWord.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); //Hủy sesion hiện tại
            return RedirectToAction("Index", "Login"); //Trở về trang login
        }
    }
}