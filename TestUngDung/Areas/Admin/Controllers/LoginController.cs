
//@ Nguyen Cong Thuan

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;
using Models.DAO;
using webCommon.Common;
using TestUngDung.Extensions;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Loign
        [HttpGet]
        public ActionResult Index()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModels model)
        {
            if (ModelState.IsValid)
            {
                var dao = new userDAO();

                string pass_MD5 = Encryptor.MD5Hash(model.PassWord); //Mã hóa mật khẩu về MD5 trước khi truyền vào

                var result = dao.Login(model.UserName, pass_MD5); //Tạo biến kiểm tra đăng nhập
                if (result == 1)
                {
                    //tạo biến user để lấy thông tin cần thiết, sau đó truyền vào session
                    var user = dao.getUserByID(model.UserName);

                    var userSession = new UserLogin
                    {
                        FirstName = user.UserName,
                        UserName = user.UserName
                    };
                    ViewBag.HoTen = user.UserName;
                    Session.Add(Constants.USER_SESSION, userSession); //Session kiểm tra khi vào trang chủ index home
                    Session["FullName"] = user.UserName.ToString(); //Session cho lời chào ở trang index home
                    return RedirectToAction("Index", "Home"); // quay về trang index home
                }
                else if (result == 0)
                {
                    this.AddNotification("Tài khoản không tồn tại!", NotificationType.ERROR);
                }
                else if (result == -1)
                {
                    this.AddNotification("Mật khẩu không chính xác!", NotificationType.ERROR);
                }
                else
                {
                    this.AddNotification("Tên đăng nhập không tồn tại!", NotificationType.ERROR);
                }
            }
            return View("Index"); //Nếu modelstate == false thì ở tại chỗ
        }
    }
}