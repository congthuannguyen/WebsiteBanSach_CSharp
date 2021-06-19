
//@ Nguyen Cong Thuan

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using ModelEF.Model;
using TestUngDung.Extensions;
using PagedList;
using MobilePhoneWord.Areas.Admin.Controllers;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var user = new userDAO();
            var model = user.ListAllPaging(page, pageSize);
            return View(model);
        }
        // tìm kiếm theo userName
        [HttpPost]
        public ActionResult Index(string searchName, int? page)
        {
            var db = new NguyenCongThuanContext();
            int recordsPerPage = 5;

            if (!page.HasValue)
            {
                page = 1; // đặt giá trị trang ban đầu
            }
            ViewBag.Keyword = searchName;

            var listUser = db.UserAccounts.ToList();
            try
            {
                if (!String.IsNullOrEmpty(searchName))
                {
                    listUser = listUser.Where(s => s.UserName.Contains(searchName)).ToList();
                    if(listUser.Count <= 0)
                    {
                        this.AddNotification("Không tìm thấy tài khoản nào!", NotificationType.ERROR);
                    }
                }
            }
            catch (Exception ex) {}
            listUser.OrderBy(v => v.ID);

            var finalList = listUser.ToPagedList(page.Value, recordsPerPage);
            return View(finalList);
        }
        // Xóa
        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new NguyenCongThuanContext();
            var deleting = context.UserAccounts.Find(id);
            
            return View(deleting);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var context = new NguyenCongThuanContext();
                var deleting = context.UserAccounts.Find(id);
                context.UserAccounts.Remove(deleting);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}