
//@ Nguyen Cong Thuan

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Office.CustomUI;
using MobilePhoneWord.Areas.Admin.Controllers;
using ModelEF.Model;
using TestUngDung.Areas.Admin.Models;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductsController : BaseController
    {
        private NguyenCongThuanContext db;
        public ProductsController()
        {
            db = new NguyenCongThuanContext();
        }
        // GET: Admin/Products
        public ActionResult Index()
        {
            IEnumerable<Product> result = from s in db.Products
                                          orderby s.Quantity ascending, s.UnitCost descending
                                          select s;
            return View(result.ToList());
        }

        // Xem chi tiết
        public ActionResult Details(int id)
        {
            return View(db.Products.Where(s => s.ID == id).FirstOrDefault());
        }
        // Thêm sản phẩm
        [HttpGet]
        public ActionResult Create()
        {
            Product pro = new Product();

            var listCategory = new SelectList(db.Categories, "ID", "Name");
            ViewBag.IDCategoryNo = listCategory;
            
            return View(pro);
        }

        [HttpPost]
        public ActionResult Create(Product model, HttpPostedFileBase image)
        {
            try
            {
                if(image != null) // có file hình ảnh
                {
                    // lấy tên file lưu vào db
                    string fileName = Path.GetFileNameWithoutExtension(image.FileName);// tên file
                    string extension = Path.GetExtension(image.FileName);//đường dẫn (duoi)
                    fileName = fileName + extension;
                    model.Image = "~/Contents/Images/" + fileName;
                    image.SaveAs(Path.Combine(Server.MapPath("~/Contents/Images/"), fileName)); // mappath lưu vào folder
                }
                db.Products.Add(model);
                db.SaveChanges();

                return RedirectToAction("Index"); // tạo xong điều hường đến trang Index
            }
            catch
            {
                return View();
            }
        }

    }
}