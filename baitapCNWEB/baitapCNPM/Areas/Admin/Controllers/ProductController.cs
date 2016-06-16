using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using baitapCNPM.Models;
using PagedList;
using baitapCNPM.Areas.Admin.Models;
using System.IO;


namespace baitapCNPM.Areas.Admin.Controllers
{
    [Common.CustomAuthorize(Roles = "admin")]
    public class ProductController : Controller
    {
        //
        // GET: /Admin/Product/

        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var model = new ProductDao().getAllProduct(page, pagesize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var dao = new CategoryDao().getAllCategory().Where(m => m.categoryName != null);

            ViewBag.categoryID = new SelectList(dao, "categoryID", "categoryName", null);
            return View();
        }
        [HttpPost]
        public ActionResult Create(product product, HttpPostedFileBase productImage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (productImage == null)
                    {
                        ModelState.AddModelError("File", "Please Upload Your file");
                    }
                    else if (productImage.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(productImage.FileName);

                        var path = Path.Combine(Server.MapPath("~/Content/images/Products"), fileName);
                        productImage.SaveAs(path);

                        product.productImage = "~/Content/images/Products/" + fileName;
                        new ProductDao().Create(product);
                    }

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new CategoryDao().getAllCategory().Where(m => m.categoryName != null);

            ViewBag.categoryID = new SelectList(dao, "categoryID", "categoryName", null);
            var model = new ProductDao().getDeital(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(product product, HttpPostedFileBase Image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Image == null)
                    {
                        ModelState.AddModelError("File", "Please Upload Your file");
                    }
                    else if (Image.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(Image.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/client/images"), fileName);
                        Image.SaveAs(path);
                        product.productImage = "~/Content/client/images" + fileName;



                    }
                    new ProductDao().Edit(product, Image);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit");
            }

        }
        [HttpPost]
        public ActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = new ProductDao().getDeital(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(product cate)
        {

            var x = new ProductDao().Delete(cate.productID);
            if (x != 0)
            {
                return RedirectToAction("Index");
            }
            else

                return RedirectToAction("Delete");
        }

    }
}
